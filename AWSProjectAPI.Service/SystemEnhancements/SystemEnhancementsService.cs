using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.DataAccess.SystemEnhancements;
using AWSProjectAPI.Service.Authentication;
using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.SystemEnhancements
{
    public class SystemEnhancementsService : ISystemEnhancementsService
    {
        #region Private Properties
        private readonly ISystemEnhancementsDataAccess iSystemEnhancementsDataAccess;
        private readonly IAuthenticationService iAuthenticationService;
        private readonly ICommonService iCommonService;
        #endregion

        // Constructor
        public SystemEnhancementsService(ISystemEnhancementsDataAccess iSystemEnhancementsDataAccess, IAuthenticationService iAuthenticationService,
            ICommonService iCommonService)
        {
            this.iSystemEnhancementsDataAccess = iSystemEnhancementsDataAccess;
            this.iAuthenticationService = iAuthenticationService;
            this.iCommonService = iCommonService;
        }

        // SetSystemEnhancementDetails
        /// <summary>
        /// Set System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// actionState -> string
        /// </remarks>
        public string SetSystemEnhancementDetails(SystemEnhancement systemEnhancement, string actionState)
        {
            // Declare the new ID
            string newId = "";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the new system enhancement
                    newId = this.iSystemEnhancementsDataAccess.AddSystemEnhancementDetails(systemEnhancement);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < systemEnhancement.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iSystemEnhancementsDataAccess.AddSystemEnhancementAssignedStaff(newId, systemEnhancement.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < systemEnhancement.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iSystemEnhancementsDataAccess.AddSystemEnhancementRequestedStaff(newId, systemEnhancement.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaff, taskAddRequestedStaff);

                    // Getting the user details
                    UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(systemEnhancement.AddedUserId);
                    // Sending the emails
                    sendAddedEmail(systemEnhancement, addedUserDetails, addedUserDetails);
                    break;
                case "UPDATE":
                    // Updating the new system enhancement
                    newId = this.iSystemEnhancementsDataAccess.UpdateSystemEnhancementDetails(systemEnhancement);
                    // Remove all the assigned and requested staff
                    Task taskRemoveAssignedStaffUpdate = Task.Factory.StartNew(() => this.iSystemEnhancementsDataAccess.DeleteSystemEnhancementAssignedStaff(newId));
                    Task taskRemoveRequestedStaffUpdate = Task.Factory.StartNew(() => this.iSystemEnhancementsDataAccess.DeleteSystemEnhancementRequestedStaff(newId));
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskRemoveAssignedStaffUpdate, taskRemoveRequestedStaffUpdate);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < systemEnhancement.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iSystemEnhancementsDataAccess.AddSystemEnhancementAssignedStaff(newId, systemEnhancement.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < systemEnhancement.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iSystemEnhancementsDataAccess.AddSystemEnhancementRequestedStaff(newId, systemEnhancement.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaffUpdate, taskAddRequestedStaffUpdate);
                    break;
                case "DELETE":
                    // Deleting the new system enhancement
                    newId = this.iSystemEnhancementsDataAccess.DeleteSystemEnhancementDetails(systemEnhancement.Id);
                    break;
            }
            // End of Check the action state

            // Return the value
            return newId;
        }

        // GetSystemEnhancementDisplayModules
        /// <summary>
        /// Getting the system enhancements modules to display
        /// </summary>
        /// <returns>
        /// DisplayModule object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<DisplayModule> GetSystemEnhancementDisplayModules(Filter filter)
        {
            return this.iSystemEnhancementsDataAccess.GetSystemEnhancementDisplayModules(filter);
        }

        // GetSystemEnhancementDisplayList
        /// <summary>
        /// Getting the system enhancements display list
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancement object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<ViewSystemEnhancement> GetSystemEnhancementDisplayList(Filter filter, string UserId)
        {
            // Declare the object
            List<ViewSystemEnhancement> systemEnhancementList = new List<ViewSystemEnhancement>();
            // Getting the list
            systemEnhancementList = this.iSystemEnhancementsDataAccess.GetSystemEnhancementDisplayList(filter, UserId);
            // Loop through the list
            for (int i = 0; i < systemEnhancementList.Count; i++)
            {
                // Setting the requested staff list
                systemEnhancementList[i].RequestedStaffList = this.iSystemEnhancementsDataAccess.GetSystemEnhancementRequestedStaff(systemEnhancementList[i].Id);
            }
            // End of Loop through the list

            // return the value
            return systemEnhancementList;
        }

        // GetSystemEnhancementDetailsById
        /// <summary>
        /// Getting the system enhancements details based on the Id
        /// </summary>
        /// <returns>
        /// SystemEnhancement object
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        public SystemEnhancement GetSystemEnhancementDetailsById(string systemEnhancementId, string userId)
        {
            // Declare the object
            SystemEnhancement systemEnhancement = new SystemEnhancement();
            // Getting the basic details
            systemEnhancement = this.iSystemEnhancementsDataAccess.GetSystemEnhancementDetailsById(systemEnhancementId, userId);
            // Getting the assigned staff details
            systemEnhancement.AssignedStaffList = this.iSystemEnhancementsDataAccess.GetSystemEnhancementAssignedStaff(systemEnhancementId);
            // Getting the requested staff details
            systemEnhancement.RequestedStaffList = this.iSystemEnhancementsDataAccess.GetSystemEnhancementRequestedStaff(systemEnhancementId);
            // return the value
            return systemEnhancement;
        }

        // UpdateSystemEnhancementStatus
        /// <summary>
        /// Updating the status of the system enhancement
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// statusId -> Int value
        /// </remarks>
        public bool UpdateSystemEnhancementStatus(string systemEnhancementId, int statusId)
        {
            return this.iSystemEnhancementsDataAccess.UpdateSystemEnhancementStatus(systemEnhancementId, statusId);
        }

        // SetSystemEhancementChangeDate
        /// <summary>
        /// Set System Enhancement Change date history
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// actionState -> String value
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        public string SetSystemEhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate, string actionState)
        {
            // Declare the variable
            string status = "false";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement change date history
                    status = this.iSystemEnhancementsDataAccess.AddSystemEnhancementChangeDate(systemEnhancementChangeDate);
                    break;
                case "UPDATE":
                    // Updating the system ehancement change date history
                    status = this.iSystemEnhancementsDataAccess.UpdateSystemEnhancementChangeDate(systemEnhancementChangeDate);
                    break;
                case "DELETE":
                    // Deleting the history record
                    status = this.iSystemEnhancementsDataAccess.DeleteSystemEnhancementChangeDate(systemEnhancementChangeDate);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

        // GetSystemEhancementChangeDate
        /// <summary>
        /// Get System Enhancement Change date history
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancementChangeDate object list value
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// filter -> Filter object value
        /// </remarks>
        public List<ViewSystemEnhancementChangeDate> GetSystemEhancementChangeDate(Filter filter, string systemEnhancementId)
        {
            return this.iSystemEnhancementsDataAccess.GetSystemEhancementChangeDate(filter, systemEnhancementId);
        }

        // SetSystemEhancementComment
        /// <summary>
        /// Set System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// actionState -> string value
        /// </remarks>
        public string SetSystemEhancementComment(SystemEnhancementComment systemEnhancementComment, string actionState)
        {
            // Declare the variable
            string status = "false";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement comment
                    status = this.iSystemEnhancementsDataAccess.AddSystemEhancementComment(systemEnhancementComment);
                    break;
                case "UPDATE":
                    // Updating the system ehancement comment
                    status = this.iSystemEnhancementsDataAccess.UpdateSystemEhancementComment(systemEnhancementComment);
                    break;
                case "DELETE":
                    // Deleting the comment
                    status = this.iSystemEnhancementsDataAccess.DeleteSystemEhancementComment(systemEnhancementComment);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

        // GetSystemEhancementComment
        /// <summary>
        /// Get System Enhancement Comment
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancementComment object list value
        /// </returns>
        /// <remarks>
        /// filter -> Filter object value
        /// </remarks>
        public List<ViewSystemEnhancementComment> GetSystemEhancementComment(Filter filter)
        {
            return this.iSystemEnhancementsDataAccess.GetSystemEhancementComment(filter);
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
            return this.iSystemEnhancementsDataAccess.GetStatBoxes();
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
            return this.iSystemEnhancementsDataAccess.ApprovalChangeDate(SystemEnhancementsChangeHistoryId, approval);
        }

        // AddViewId
        /// <summary>
        /// Setting the view ID for the system enhancement
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
            SystemEnhancement systemEnhancement = this.iSystemEnhancementsDataAccess.GetSystemEnhancementDetailsById(itemId, userId);

            // Check if the ID is added
            if (systemEnhancement.IsNew == true) {
                status = this.iSystemEnhancementsDataAccess.AddViewId(itemId, userId);
                // Getting the user details
                UserDetails userDetails = iAuthenticationService.GetUserDetailsByUserId(userId);
                // Getting the user details
                UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(systemEnhancement.AddedUserId);
                // Sending the emails
                sendViewedEmail(systemEnhancement, userDetails, addedUserDetails);
            }
            else
            {
                status = true;
            }

            // Return the value
            return status;
        }

        public void sendAddedEmail(SystemEnhancement systemEnhancement, UserDetails userDetails, UserDetails addedUserDetails)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Top part of the email
            string emailBody = "<div>" +
                "<div style='background:#2867af;text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;'></div>" +
                "<div style='padding:10px'>" +
                "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>System Enhancement has been added by " + userDetails.FirstName + " " + userDetails.LastName + ":</span></div>" +
                "<div style='font-weight:bold;text-align:center;'><span>" + systemEnhancement.Title + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>" + systemEnhancement.Description + "</span></div>" +
                //"<div style='padding-bottom:5px;text-align:center;'><span>Added by: " + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
                "</div>" +
                "</div>";

            // Setting the email body
            EmailBodyDetails internelEmailObject = new EmailBodyDetails()
            {
                AttachmentPath = new List<string>(),
                Content = emailBody,
                Subject = "SystemEnhancement: " + systemEnhancement.Title + " is added",
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

        public void sendViewedEmail(SystemEnhancement systemEnhancement, UserDetails userDetails, UserDetails addedUserDetails)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Top part of the email
            string emailBody = "<div>" +
                "<div style='background:#2867af;text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;'></div>" +
                "<div style='padding:10px'>" +
                "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>System Enhancement has been viewed by " + userDetails.FirstName + " " + userDetails.LastName + ":</span></div>" +
                "<div style='font-weight:bold;text-align:center;'><span>" + systemEnhancement.Title + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>" + systemEnhancement.Description + "</span></div>" +
                "<div style='padding-bottom:5px;text-align:center;'><span>Added by: " + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
                "</div>" +
                "</div>";

            // Setting the email body
            EmailBodyDetails internelEmailObject = new EmailBodyDetails()
            {
                AttachmentPath = new List<string>(),
                Content = emailBody,
                Subject = "SystemEnhancement: " + systemEnhancement.Title + " is viwed",
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
