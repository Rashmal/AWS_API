using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.DataAccess.BugFixes;
using AWSProjectAPI.DataAccess.Common;
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
        private readonly ICommonDataAccess iCommonDataAccess;
        private readonly ICommonService iCommonService;
        private readonly IAuthenticationService iAuthenticationService;
        #endregion

        // Constructor
        public BugFixesService(IBugFixesDataAccess iBugFixesDataAccess, ICommonService iCommonService, IAuthenticationService iAuthenticationService, ICommonDataAccess iCommonDataAccess)
        {
            this.iBugFixesDataAccess = iBugFixesDataAccess;
            this.iCommonService = iCommonService;
            this.iAuthenticationService = iAuthenticationService;
            this.iCommonDataAccess = iCommonDataAccess;
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
        public string SetBugFixesDetails(BugFix bugFix, string actionState, int companyId)
        {
            // Declare the new ID
            string newId = "";

            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the new Bug Fixes
                    newId = this.iBugFixesDataAccess.AddBugFixesDetails(bugFix, connectionString);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id, connectionString);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id, connectionString);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaff, taskAddRequestedStaff);
                    // Getting the user details
                    UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(bugFix.AddedUserId, companyId);
                    // Sending the emails
                    sendAddedEmail(bugFix, addedUserDetails, addedUserDetails, companyId);
                    break;
                case "UPDATE":
                    // Updating the new Bug Fixes
                    newId = this.iBugFixesDataAccess.UpdateBugFixesDetails(bugFix, connectionString);
                    // Remove all the assigned and requested staff
                    Task taskRemoveAssignedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesAssignedStaff(newId, connectionString));
                    Task taskRemoveRequestedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesRequestedStaff(newId, connectionString));
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskRemoveAssignedStaffUpdate, taskRemoveRequestedStaffUpdate);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id, connectionString);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id, connectionString);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaffUpdate, taskAddRequestedStaffUpdate);
                    break;
                case "DELETE":
                    // Deleting the new Bug Fixes
                    newId = this.iBugFixesDataAccess.DeleteBugFixesDetails(bugFix.Id, connectionString);
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
        public List<DisplayModule> GetBugFixesDisplayModules(Filter filter, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.GetBugFixesDisplayModules(filter, connectionString);
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
        public List<ViewBugFix> GetBugFixesDisplayList(Filter filter, string UserId, int companyId)
        {
            // Declare the object
            List<ViewBugFix> bugFixesList = new List<ViewBugFix>();
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the list
            bugFixesList = this.iBugFixesDataAccess.GetBugFixesDisplayList(filter, UserId, connectionString);
            // Loop through the list
            for (int i = 0; i < bugFixesList.Count; i++)
            {
                // Setting the requested staff list
                bugFixesList[i].RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesList[i].Id, connectionString);
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
        public BugFix GetBugFixesDetailsById(string bugFixesId, string userId, int companyId)
        {
            // Declare the object
            BugFix BugFixes = new BugFix();
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            // Getting the basic details
            BugFixes = this.iBugFixesDataAccess.GetBugFixesDetailsById(bugFixesId, connectionString, userId);
            // Getting the assigned staff details
            BugFixes.AssignedStaffList = this.iBugFixesDataAccess.GetBugFixesAssignedStaff(bugFixesId, connectionString);
            // Getting the requested staff details
            BugFixes.RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesId, connectionString);
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
        public bool UpdateBugFixesStatus(string bugFixesId, int statusId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.UpdateBugFixesStatus(bugFixesId, statusId, connectionString);
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
        public string SetBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, string actionState, int companyId)
        {
            // Declare the variable
            string status = "ERROR";
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement change date history
                    status = this.iBugFixesDataAccess.AddBugFixesChangeDate(bugFixesChangeDate, connectionString);
                    break;
                case "UPDATE":
                    // Updating the system ehancement change date history
                    status = this.iBugFixesDataAccess.UpdateBugFixesChangeDate(bugFixesChangeDate, connectionString);
                    break;
                case "DELETE":
                    // Deleting the history record
                    status = this.iBugFixesDataAccess.DeleteBugFixesChangeDate(bugFixesChangeDate, connectionString);
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
        public List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixesId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.GetBugFixesChangeDate(filter, bugFixesId, connectionString);
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
        public string SetBugFixesComment(BugFixComment bugFixesComment, string actionState, int companyId)
        {
            // Declare the variable
            string status = "false";
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement comment
                    status = this.iBugFixesDataAccess.AddBugFixesComment(bugFixesComment, connectionString);
                    break;
                case "UPDATE":
                    // Updating the system ehancement comment
                    status = this.iBugFixesDataAccess.UpdateBugFixesComment(bugFixesComment, connectionString);
                    break;
                case "DELETE":
                    // Deleting the comment
                    status = this.iBugFixesDataAccess.DeleteBugFixesComment(bugFixesComment, connectionString);
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
        public List<ViewBugFixComment> GetBugFixesComment(Filter filter, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.GetBugFixesComment(filter, connectionString);
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
        public List<StatisticsBoxData> GetStatBoxes(int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.GetStatBoxes(connectionString);
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
        public bool ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return this.iBugFixesDataAccess.ApprovalChangeDate(SystemEnhancementsChangeHistoryId, approval, connectionString);
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
        public bool AddViewId(string itemId, string userId, int companyId)
        {
            // Status
            bool status = false;
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the system enhancement ID details
            BugFix bugFix = this.iBugFixesDataAccess.GetBugFixesDetailsById(itemId, connectionString, userId);

            // Check if the ID is added
            if (bugFix.IsNew == true)
            {
                status = this.iBugFixesDataAccess.AddViewId(itemId, userId, connectionString);
                // Getting the user details
                UserDetails userDetails = iAuthenticationService.GetUserDetailsByUserId(userId, companyId);
                // Getting the user details
                UserDetails addedUserDetails = iAuthenticationService.GetUserDetailsByUserId(bugFix.AddedUserId, companyId);
                // Sending the emails
                sendViewedEmail(bugFix, userDetails, addedUserDetails, companyId);
            }
            else
            {
                status = true;
            }

            // Return the value
            return status;
        }

        public void sendAddedEmail(BugFix bugFix, UserDetails userDetails, UserDetails addedUserDetails, int companyId)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Getting all the modules list
            List<Module> modulesList = this.iCommonService.GetModuleList(companyId);
            // Getting the module index
            int moduleIndex = modulesList.FindIndex(obj => obj.Id == bugFix.ModuleId);
            // Getting the module name
            string moduleName = (moduleIndex == -1) ? "None" : modulesList[moduleIndex].Name;
            // Getting all the priority list
            List<Priority> priorityList = this.iCommonService.GetPriorityList(companyId);
            // Getting the priority index
            int priorityIndex = priorityList.FindIndex(obj => obj.Id == bugFix.PriorityId);
            // Getting the priority name
            string priorityName = (priorityIndex == -1) ? "None" : priorityList[moduleIndex].Name;
            // Getitng the current date
            DateTime today = DateTime.Today;
            // Getting the priority color
            string priorityColor = (priorityList[priorityIndex].Code == "UG") ? "#ff5757" : (priorityList[moduleIndex].Code == "NM") ? "#ebb32c" : "#21ba45";

            // Top part of the email
            string emailBody = "<div>" +
              "<div style='text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;object-fit: contain;'></div>" +
              "<div style='padding:10px'>" +
              "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>A New Bug Fix has been added</span></div><br/>" +
              "<div style='text-align:left;'><span>Requested By:" + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
              "<div style='text-align:left;'><span>Requested On:" + today.ToString("dd-MMM-yyyy") + "</span></div>" +
              "<div style='text-align:left;'><span>Module:" + moduleName + "</span></div>" +
              "<div style='text-align:left;'><span style='color:" + priorityColor + "'>Priority:" + priorityName + "</span></div>" +
              "<div style='text-align:left;'><span>Estimated Hours:" + bugFix.EstimatedHours + "</span></div>" +
              "<div style='text-align:left;'><span>Started:" + bugFix.StartDate.ToString("dd-MMM-yyyy") + "</span></div>" +
              "<div style='text-align:left;'><span>Title:" + bugFix.Title + "</span></div>" +
              "<div style='text-align:left;'><span>Description:" + bugFix.Description + "</span></div>" +
              //"<div style='padding-bottom:5px;text-align:center;'><span>" + systemEnhancement.Description + "</span></div>" +
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

        public void sendViewedEmail(BugFix bugFix, UserDetails userDetails, UserDetails addedUserDetails, int companyId)
        {
            // Getting the company details by company domain
            //CompanyDetails companyDetails = i_Service.GetCompanyDetailsByDomain(companyDomain);

            // Getting all the modules list
            List<Module> modulesList = this.iCommonService.GetModuleList(companyId);
            // Getting the module index
            int moduleIndex = modulesList.FindIndex(obj => obj.Id == bugFix.ModuleId);
            // Getting the module name
            string moduleName = (moduleIndex == -1) ? "None" : modulesList[moduleIndex].Name;
            // Getting all the priority list
            List<Priority> priorityList = this.iCommonService.GetPriorityList(companyId);
            // Getting the priority index
            int priorityIndex = priorityList.FindIndex(obj => obj.Id == bugFix.PriorityId);
            // Getting the priority name
            string priorityName = (priorityIndex == -1) ? "None" : priorityList[moduleIndex].Name;
            // Getitng the current date
            DateTime today = DateTime.Today;
            // Getting the priority color
            string priorityColor = (priorityList[priorityIndex].Code == "UG") ? "#ff5757" : (priorityList[moduleIndex].Code == "NM") ? "#ebb32c" : "#21ba45";

            // Top part of the email
            string emailBody = "<div>" +
              "<div style='text-align:center;padding:10px;'><img src='https://iitcdemo.com/assets/images/logo_aws.png' style='width:300px;height:50px;object-fit: contain;'></div>" +
              "<div style='padding:10px'>" +
              "<div style='padding:10px;text-align:center;font-size:30px;font-weight:bold;'><span>A Bug Fix has been viewed</span></div><br/>" +
              "<div style='text-align:left;'><span>Requested By:" + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
              "<div style='text-align:left;'><span>Requested On:" + today.ToString("dd-MMM-yyyy") + "</span></div>" +
              "<div style='text-align:left;'><span>Module:" + moduleName + "</span></div>" +
              "<div style='text-align:left;'><span style='color:" + priorityColor + "'>Priority:" + priorityName + "</span></div>" +
              "<div style='text-align:left;'><span>Estimated Hours:" + bugFix.EstimatedHours + "</span></div>" +
              "<div style='text-align:left;'><span>Started:" + bugFix.StartDate.ToString("dd-MMM-yyyy") + "</span></div>" +
              "<div style='text-align:left;'><span>Title:" + bugFix.Title + "</span></div>" +
              "<div style='text-align:left;'><span>Description:" + bugFix.Description + "</span></div>" +
              //"<div style='padding-bottom:5px;text-align:center;'><span>" + systemEnhancement.Description + "</span></div>" +
              //"<div style='padding-bottom:5px;text-align:center;'><span>Added by: " + addedUserDetails.FirstName + " " + addedUserDetails.LastName + "</span></div>" +
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
