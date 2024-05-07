using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.DataAccess.BugFixes;
using AWSProjectAPI.Service.Authentication;
using AWSProjectAPI.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.BugFixes
{
    public class BugFixesService: IBugFixesService
    {
        #region Private Properties
        private readonly IBugFixesDataAccess iBugFixesDataAccess;
        private readonly ICommonService iCommonService;
        private readonly IAuthenticationService iAuthenticationService;
        #endregion

        // Constructor
        public BugFixesService(IBugFixesDataAccess iBugFixesDataAccess, ICommonService iCommonService, IAuthenticationService iAuthenticationService)
        {
            this.iBugFixesDataAccess = iBugFixesDataAccess;
            this.iCommonService = iCommonService;
            this.iAuthenticationService = iAuthenticationService;
        }

        // SetBugFixesDetails
        /// <summary>
        /// Set Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// actionState -> string
        /// </remarks>
        public string SetBugFixesDetails(BugFix bugFix, string actionState)
        {
            // Declare the new ID
            string newId = "";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the new Bug Fixes
                    newId = this.iBugFixesDataAccess.AddBugFixesDetails(bugFix);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaff, taskAddRequestedStaff);
                    // Getting the user details
                    UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(bugFix.AddedUserId);
                    // Sending the emails
                    sendAddedEmail(bugFix, addedUserDetails, addedUserDetails);
                    break;
                case "UPDATE":
                    // Updating the new Bug Fixes
                    newId = this.iBugFixesDataAccess.UpdateBugFixesDetails(bugFix);
                    // Remove all the assigned and requested staff
                    Task taskRemoveAssignedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesAssignedStaff(newId));
                    Task taskRemoveRequestedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesRequestedStaff(newId));
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskRemoveAssignedStaffUpdate, taskRemoveRequestedStaffUpdate);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaffUpdate, taskAddRequestedStaffUpdate);
                    break;
                case "DELETE":
                    // Deleting the new Bug Fixes
                    newId = this.iBugFixesDataAccess.DeleteBugFixesDetails(bugFix.Id);
                    break;
            }
            // End of Check the action state

            // Return the value
            return newId;
        }

        // GetBugFixesDisplayModules
        /// <summary>
        /// Getting the Bug Fixess modules to display
        /// </summary>
        /// <returns>
        /// DisplayModule object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<DisplayModule> GetBugFixesDisplayModules(Filter filter)
        {
            return this.iBugFixesDataAccess.GetBugFixesDisplayModules(filter);
        }

        // GetBugFixesDisplayList
        /// <summary>
        /// Getting the Bug Fixess display list
        /// </summary>
        /// <returns>
        /// ViewBugFixes object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<ViewBugFix> GetBugFixesDisplayList(Filter filter, string UserId)
        {
            // Declare the object
            List<ViewBugFix> bugFixesList = new List<ViewBugFix>();
            // Getting the list
            bugFixesList = this.iBugFixesDataAccess.GetBugFixesDisplayList(filter, UserId);
            // Loop through the list
            for (int i = 0; i < bugFixesList.Count; i++)
            {
                // Setting the requested staff list
                bugFixesList[i].RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesList[i].Id);
            }
            // End of Loop through the list

            // return the value
            return bugFixesList;
        }

        // GetBugFixesDetailsById
        /// <summary>
        /// Getting the Bug Fixess details based on the Id
        /// </summary>
        /// <returns>
        /// BugFixes object
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        public BugFix GetBugFixesDetailsById(string bugFixesId, string userId)
        {
            // Declare the object
            BugFix BugFixes = new BugFix();
            // Getting the basic details
            BugFixes = this.iBugFixesDataAccess.GetBugFixesDetailsById(bugFixesId, userId);
            // Getting the assigned staff details
            BugFixes.AssignedStaffList = this.iBugFixesDataAccess.GetBugFixesAssignedStaff(bugFixesId);
            // Getting the requested staff details
            BugFixes.RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesId);
            // return the value
            return BugFixes;
        }

        // UpdateBugFixesStatus
        /// <summary>
        /// Updating the status of the Bug Fixes
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// statusId -> Int value
        /// </remarks>
        public bool UpdateBugFixesStatus(string bugFixesId, int statusId)
        {
            return this.iBugFixesDataAccess.UpdateBugFixesStatus(bugFixesId, statusId);
        }

        // SetBugFixesChangeDate
        /// <summary>
        /// Set Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// actionState -> String value
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        public string SetBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, string actionState)
        {
            // Declare the variable
            string status = "ERROR";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement change date history
                    status = this.iBugFixesDataAccess.AddBugFixesChangeDate(bugFixesChangeDate);
                    break;
                case "UPDATE":
                    // Updating the system ehancement change date history
                    status = this.iBugFixesDataAccess.UpdateBugFixesChangeDate(bugFixesChangeDate);
                    break;
                case "DELETE":
                    // Deleting the history record
                    status = this.iBugFixesDataAccess.DeleteBugFixesChangeDate(bugFixesChangeDate);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

        // GetBugFixesChangeDate
        /// <summary>
        /// Get Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// ViewBugFixesChangeDate object list value
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// filter -> Filter object value
        /// </remarks>
        public List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixesId)
        {
            return this.iBugFixesDataAccess.GetBugFixesChangeDate(filter, bugFixesId);
        }

        // SetBugFixesComment
        /// <summary>
        /// Set Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// actionState -> string value
        /// </remarks>
        public string SetBugFixesComment(BugFixComment bugFixesComment, string actionState)
        {
            // Declare the variable
            string status = "false";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement comment
                    status = this.iBugFixesDataAccess.AddBugFixesComment(bugFixesComment);
                    break;
                case "UPDATE":
                    // Updating the system ehancement comment
                    status = this.iBugFixesDataAccess.UpdateBugFixesComment(bugFixesComment);
                    break;
                case "DELETE":
                    // Deleting the comment
                    status = this.iBugFixesDataAccess.DeleteBugFixesComment(bugFixesComment);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

        // GetBugFixesComment
        /// <summary>
        /// Get Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// ViewBugFixesComment object list value
        /// </returns>
        /// <remarks>
        /// filter -> Filter object value
        /// </remarks>
        public List<ViewBugFixComment> GetBugFixesComment(Filter filter)
        {
            return this.iBugFixesDataAccess.GetBugFixesComment(filter);
        }

        // GetStatBoxes
        /// <summary>
        /// Getting the stat boxes
        /// </summary>
        /// <returns>
        /// StatisticsBoxData object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<StatisticsBoxData> GetStatBoxes()
        {
            return this.iBugFixesDataAccess.GetStatBoxes();
        }

        // ApprovalChangeDate
        /// <summary>
        /// Getting the approval change date
        /// </summary>
        /// <returns>
        /// SystemEnhancementsChangeHistoryId int value
        /// approval string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public bool ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval)
        {
            return this.iBugFixesDataAccess.ApprovalChangeDate(SystemEnhancementsChangeHistoryId, approval);
        }

        // AddViewId
        /// <summary>
        /// Setting the view ID for the bug fixes
        /// </summary>
        /// <returns>
        /// itemId string value
        /// userId string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public bool AddViewId(string itemId, string userId)
        {
            // Status
            bool status = false;

            // Getting the system enhancement ID details
            BugFix bugFix = this.iBugFixesDataAccess.GetBugFixesDetailsById(itemId, userId);

            // Check if the ID is added
            if (bugFix.IsNew == true)
            {
                status = this.iBugFixesDataAccess.AddViewId(itemId, userId);
                // Getting the user details
                UserDetails userDetails = iAuthenticationService.GetUserDetailsByUserId(userId);
                // Getting the user details
                UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(bugFix.AddedUserId);
                // Sending the emails
                sendViewedEmail(bugFix, userDetails, addedUserDetails);
            }
            else
            {
                status = true;
            }

            // Return the value
            return status;
        }

        public void sendAddedEmail(BugFix bugFix, UserDetails userDetails, UserDetails addedUserDetails)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Top part of the email
            string emailBody = "<div>" +
                "<div style='background:#2867af;text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;'></div>" +
                "<div style='padding:10px'>" +
                "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>Bug Fix has been added by " + userDetails.FirstName + " " + userDetails.LastName + ":</span></div>" +
                "<div style='font-weight:bold;text-align:center;'><span>" + bugFix.Title + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>" + bugFix.Description + "</span></div>" +
                //"<div style='padding-bottom:5px;text-align:center;'><span>Added by: " + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
                "</div>" +
                "</div>";

            // Setting the email body
            EmailBodyDetails internelEmailObject = new EmailBodyDetails()
            {
                AttachmentPath = new List<string>(),
                Content = emailBody,
                Subject = "Bug Fix: " + bugFix.Title + " is added",
                FromAddress = new EmailAddress()
                {
                    Address = "iitcglobalmail@gmail.com",
                    Name = ""
                },
                ToAddressList = new List<EmailAddress>(),
                BCCAddressList = new List<EmailAddress>(),
                CCAddressList = new List<EmailAddress>()
            };
            //internelEmailObject.ToAddressList.Add(new EmailAddress()
            //{
            //    Address = receiverEmail,
            //    Name = receiverName
            //});
            internelEmailObject.ToAddressList.Add(new EmailAddress()
            {
                Address = "testuser@iitcglobal.com",
                Name = "testuser"
            });
            internelEmailObject.CCAddressList.Add(new EmailAddress()
            {
                Address = "leo@iitcglobal.com",
                Name = "leo"
            });
            internelEmailObject.CCAddressList.Add(new EmailAddress()
            {
                Address = "rashmalat@gmail.com",
                Name = "Rashmal"
            });

            // Sending the email
            string emailResponse = iCommonService.SendEmailLocally(internelEmailObject);
        }

        public void sendViewedEmail(BugFix bugFix, UserDetails userDetails, UserDetails addedUserDetails)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Top part of the email
            string emailBody = "<div>" +
                "<div style='background:#2867af;text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;'></div>" +
                "<div style='padding:10px'>" +
                "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>Bug Fix has been viewed by " + userDetails.FirstName + " " + userDetails.LastName + ":</span></div>" +
                "<div style='font-weight:bold;text-align:center;'><span>" + bugFix.Title + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>" + bugFix.Description + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>Added by: " + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
                "</div>" +
                "</div>";

            // Setting the email body
            EmailBodyDetails internelEmailObject = new EmailBodyDetails()
            {
                AttachmentPath = new List<string>(),
                Content = emailBody,
                Subject = "Bug Fix: " + bugFix.Title + " is viwed",
                FromAddress = new EmailAddress()
                {
                    Address = "iitcglobalmail@gmail.com",
                    Name = ""
                },
                ToAddressList = new List<EmailAddress>(),
                BCCAddressList = new List<EmailAddress>(),
                CCAddressList = new List<EmailAddress>()
            };
            //internelEmailObject.ToAddressList.Add(new EmailAddress()
            //{
            //    Address = receiverEmail,
            //    Name = receiverName
            //});
            internelEmailObject.ToAddressList.Add(new EmailAddress()
            {
                Address = "testuser@iitcglobal.com",
                Name = "testuser"
            });
            internelEmailObject.CCAddressList.Add(new EmailAddress()
            {
                Address = "leo@iitcglobal.com",
                Name = "leo"
            });
            internelEmailObject.CCAddressList.Add(new EmailAddress()
            {
                Address = "rashmalat@gmail.com",
                Name = "Rashmal"
            });

            // Sending the email
            string emailResponse = iCommonService.SendEmailLocally(internelEmailObject);
        }
    }
}
