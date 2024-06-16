using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.ClientDetails;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.DataAccess.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Staff
{
    public class StaffService : IStaffService
    {
        #region Private Properties
        private readonly IStaffDataAccess iStaffDataAccess;
        protected string GLOBAL_FILES_PATH { get; set; }
        protected string AVATAR_FILES_PATH { get; set; }
        protected string IMAGE_DOC_FILES_PATH { get; set; }
        protected string CLIENT_REQ_FILES_PATH { get; set; }
        protected string IMAGE_LIVE_URL { get; set; }
        private readonly ICommonDataAccess iCommonDataAccess;
        #endregion

        // Constructor
        public StaffService(IConfiguration configurationString, IStaffDataAccess iStaffDataAccess,
            ICommonDataAccess iCommonDataAccess)
        {
            // Intantiating the object
            this.iStaffDataAccess = iStaffDataAccess;
            this.iCommonDataAccess = iCommonDataAccess;
            this.GLOBAL_FILES_PATH = configurationString.GetConnectionString("GLOBAL_FILES_PATH");
            this.AVATAR_FILES_PATH = configurationString.GetConnectionString("AVATAR_FILES_PATH");
            this.IMAGE_DOC_FILES_PATH = configurationString.GetConnectionString("IMAGE_DOC_FILES_PATH");
            this.CLIENT_REQ_FILES_PATH = configurationString.GetConnectionString("CLIENT_REQ_FILES_PATH");
            this.IMAGE_LIVE_URL = configurationString.GetConnectionString("IMAGE_LIVE_URL");
        }

        // GetAllUserRoles
        /// <summary>
        /// Getting all the user roles
        /// </summary>
        /// <returns>
        /// UserRole object list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// </remarks>
        public List<UserRole> GetAllUserRoles(int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetAllUserRoles(connectionString);
        }

        // SetUserRoles
        /// <summary>
        /// Setting all the user roles
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// userRole -> UserRole
        /// actionType -> string
        /// </remarks>
        public int SetUserRoles(UserRole userRole, int companyId, string actionType)
        {
            // Declare the status
            int newId = 0;
            int prevId = 0;

            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Checking the action type
            switch (actionType)
            {
                case "NEW":
                    // Inserting and getting the new Id
                    newId = this.iStaffDataAccess.AddNewUserRoles(userRole, connectionString);
                    // Adding the default settings
                    this.SetDefaultAccessForNewUserRole(newId, companyId);
                    break;
                case "UPDATE":
                    // Updating and getting the new Id
                    newId = this.iStaffDataAccess.UpdateUserRoles(userRole, connectionString);
                    break;
                case "DELETE":
                    // Removing and getting the new Id
                    newId = this.iStaffDataAccess.RemoveUserRoles(userRole.Id, connectionString);
                    break;
                case "DUPLICATE":
                    // Setting the previous id
                    prevId = userRole.Id;
                    // Inserting and getting the new Id
                    newId = this.iStaffDataAccess.DuplicateUserRoles(userRole, connectionString);
                    // Setting the duplicated access roles
                    this.SetDefaultDuplicatedAccessForNewUserRole(newId, prevId, companyId);
                    break;
            }
            // End of Checking the action type

            // Return the status
            return newId;
        }

        // GetAllModulesbasedUserRole
        /// <summary>
        /// Getting all the modules based on user role
        /// </summary>
        /// <returns>
        /// Module List
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// userRoleId -> number
        /// </remarks>
        public List<Module> GetAllModulesbasedUserRole(int userRoleId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetAllModulesbasedUserRole(userRoleId, connectionString);
        }

        // SetModuleAccess
        /// <summary>
        /// Setting the module access
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public bool SetModuleAccess(int moduleId, bool moduleAccess, int userRoleId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.SetModuleAccess(moduleId, moduleAccess, userRoleId, connectionString);
        }

        // GetAccessibleModules
        /// <summary>
        /// Getting all the accessible modules
        /// </summary>
        /// <returns>
        /// Module list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public List<Module> GetAccessibleModules(int userRoleId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetAccessibleModules(userRoleId, connectionString);
        }

        // GetTabDetailaBasedOnModuleUserRole
        /// <summary>
        /// Getting all the tab details based on
        /// </summary>
        /// <returns>
        /// SubTabDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public List<SubTabDetails> GetTabDetailaBasedOnModuleUserRole(Filter filter, int userRoleId, int moduleId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            List<SubTabDetails> subTabList = this.iStaffDataAccess.GetTabDetailaBasedOnModuleUserRole(filter, userRoleId, moduleId, connectionString);

            // Loop through the sub tab list
            for (int i = 0; i < subTabList.Count; i++)
            {
                // Getting the feature list
                subTabList[i].AccessLevelFeatureDetailsList = this.iStaffDataAccess.GetSubTabFeaureAccessList(subTabList[i].Id, connectionString);
            }
            // End of Loop through the sub tab list

            // Return the list
            return subTabList;
        }

        // SetTabDetailaAccessLevelBasedOnModuleUserRole
        /// <summary>
        /// Setting all the tab access level
        /// </summary>
        /// <returns>
        /// SubTabDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public bool SetTabDetailaAccessLevelBasedOnModuleUserRole(int subTabId, bool accessLevel, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the sub feature list
            List<AccessLevelFeatureDetails> AccessLevelFeatureDetailsList = this.iStaffDataAccess.GetSubTabFeaureAccessList(subTabId, connectionString);

            // Loop through the sub feature list
            for (int i = 0; i < AccessLevelFeatureDetailsList.Count; i++)
            {
                this.iStaffDataAccess.SetSubTabFeatureAccessLevel(AccessLevelFeatureDetailsList[i].Id, accessLevel, accessLevel, accessLevel, connectionString);
            }
            // End of Loop through the sub feature list

            // Getting the result
            return this.iStaffDataAccess.SetTabDetailaAccessLevelBasedOnModuleUserRole(subTabId, accessLevel, connectionString);
        }

        // SetSubTabFeatureAccessLevel
        /// <summary>
        /// Setting the sub tab feature access level
        /// </summary>
        /// <returns>
        /// SubTabDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public bool SetSubTabFeatureAccessLevel(int subTabFeatureId, bool addAccessLevel, bool editAccessLevel, bool deleteAccessLevel, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.SetSubTabFeatureAccessLevel(subTabFeatureId, addAccessLevel, editAccessLevel, deleteAccessLevel, connectionString);
        }

        // SetDefaultModuleAccessForNewUserRole
        /// <summary>
        /// Setting the default module access for new user role
        /// </summary>
        /// <returns>
        /// SubTabDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public bool SetDefaultAccessForNewUserRole(int userRoleId, int companyId)
        {
            // Declare the status
            bool status = false;
            // Getting all the companies
            List<ParentGroup> ParentGroupList = this.iStaffDataAccess.GetAllParentGroups();

            // Loop through the companies
            for (int i = 0; i < ParentGroupList.Count; i++)
            {
                // Getting the Connection string
                ConnectionString connectionString = iCommonDataAccess.GetConnectionString(ParentGroupList[i].Id, "AWS");
                // Getting the result
                status = this.iStaffDataAccess.SetDefaultAccessForNewUserRole(userRoleId, connectionString);
            }
            // End of Loop through the companies

            // Getting the result
            return status;
        }

        // SetDefaultDuplicatedAccessForNewUserRole
        /// <summary>
        /// Setting the default module access for new user role
        /// </summary>
        /// <returns>
        /// SubTabDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public bool SetDefaultDuplicatedAccessForNewUserRole(int newId, int prevId, int companyId)
        {
            // Declare the status
            bool status = false;
            // Getting all the companies
            List<ParentGroup> ParentGroupList = this.iStaffDataAccess.GetAllParentGroups();

            // Loop through the companies
            for (int i = 0; i < ParentGroupList.Count; i++)
            {
                // Getting the Connection string
                ConnectionString connectionString = iCommonDataAccess.GetConnectionString(ParentGroupList[i].Id, "AWS");
                // Getting the result
<<<<<<< HEAD
=======

>>>>>>> a2dd1e56480fd0dc37c12ac214acca960dfc7567
                //status = this.iStaffDataAccess.SetDefaultAccessForNewUserRole(newId, c
                //
                //onnectionString);
                // Setting the duplicated access levels
                //this.iStaffDataAccess.SetDefaultDuplicatedAccessForNewUserRole(newId, prevId, companyId, connectionString);

                //status = this.iStaffDataAccess.SetDefaultAccessForNewUserRole(newId, connectionString);
                //Check connection string not null
                if (connectionString != null)
                {
                    // Setting the duplicated access levels
                    this.iStaffDataAccess.SetDefaultDuplicatedAccessForNewUserRole(newId, prevId, companyId, connectionString);
                }

            }
            // End of Loop through the companies

            // Getting the result
            return status;
        }

        // SetStaffDetails
        /// <summary>
        /// Setting the basic information of the user
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public string SetStaffDetails(StaffDetails staffDetails, int companyId, string loggedUserId, string actionType)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Declare the variable
            string staffId = "";

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    staffId = this.iStaffDataAccess.SetStaffDetails(staffDetails, loggedUserId, connectionString);
                    staffDetails.Id = staffId;
                    staffId = this.iStaffDataAccess.SetStaffAddressDetails(staffDetails, connectionString);
                    // Remove all the user roles
                    this.iStaffDataAccess.RemoveAllUserRoles(staffId, connectionString);
                    // Loop through the user roles
                    for (int i = 0; i < staffDetails.UserRoleList.Count; i++)
                    {
                        // Insert the user role
                        this.iStaffDataAccess.InsertUserRoles(staffId, staffDetails.UserRoleList[i], connectionString);
                    }
                    // End of Loop through the user roles
                    break;
                case "UPDATE":
                    staffId = this.iStaffDataAccess.SetStaffDetails(staffDetails, loggedUserId, connectionString);
                    staffId = this.iStaffDataAccess.SetStaffAddressDetails(staffDetails, connectionString);
                    // Remove all the user roles
                    this.iStaffDataAccess.RemoveAllUserRoles(staffId, connectionString);
                    // Loop through the user roles
                    for (int i = 0; i < staffDetails.UserRoleList.Count; i++)
                    {
                        // Insert the user role
                        this.iStaffDataAccess.InsertUserRoles(staffId, staffDetails.UserRoleList[i], connectionString);
                    }
                    // End of Loop through the user roles
                    break;
                case "DELETE":
                    staffId = this.iStaffDataAccess.RemoveStaffDetails(staffDetails.Id, connectionString);
                    break;
            }
            // End of Check the action type

            // Return the list
            return staffId;
        }

        // UpdateStaffPassword
        /// <summary>
        /// Setting the basic information of the user
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        public string UpdateStaffPassword(string newPassword, string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Updating the password
            return this.iStaffDataAccess.UpdateStaffPassword(staffId, newPassword, connectionString);
        }

        // UploadStaffAvatar
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// file -> IFormFile
        /// </remarks>
        public string UploadStaffAvatar(List<IFormFile> files, string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Store the return value
            string uploadStatus = "ERROR";

            // Uploading the file
            try
            {
                for (int i = 0; i < files.Count; i++)
                {

                    // Getting the file path
                    string folderName = this.AVATAR_FILES_PATH;
                    IFormFile file = files[i];
                    // Check the file length
                    if (file.Length > 0)
                    {
                        // File name
                        var fileName = file.FileName;

                        // Reading the extenstion
                        string fileExt = System.IO.Path.GetExtension(file.FileName);

                        // Updating the file name
                        folderName = folderName + "\\" + RandomStringOnly(5);

                        // Path
                        var pathToSave = Path.Combine(folderName);

                        // Check the directory
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        // End of Check the directory

                        // Setting the full path
                        string fullPath = Path.Combine(pathToSave, fileName);

                        // Getting the live url
                        string liveUrl = this.IMAGE_LIVE_URL + fullPath.Replace("D:\\iitcapi", "").Replace("\\", "//");

                        // Check if file exists with its full path
                        if (File.Exists(fullPath))
                        {
                            // If file found, delete it  
                            File.Delete(fullPath);
                        }
                        // End of Check if file exists with its full path

                        // Upload the file
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // End of Upload the file

                        // Writing to the DB
                        string newUploadedFileId = this.iStaffDataAccess.UpdateStaffAvatar(staffId, liveUrl, connectionString);

                        if (newUploadedFileId != "")
                        {
                            uploadStatus = "SUCCESS";
                        }
                    }

                }
                // End of Check the file length
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UploadStaffAvatar ! :" + ex);
            }
            // End of Uploading the file

            // Return the value
            return uploadStatus;
        }

        private static string RandomStringOnly(int length)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            const string pool = "abcdefghijklmnopqrstuvwxyz";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        // GetStaffPassword
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public string GetStaffPassword(string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetStaffPassword(staffId, connectionString);
        }

        // GetDisplayStaffDetails
        /// <summary>
        /// Get Display staff details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public List<DisplayStaffDetails> GetDisplayStaffDetails(Filter filter, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            List<DisplayStaffDetails> displayStaffList = this.iStaffDataAccess.GetDisplayStaffDetails(filter, connectionString);

            // Loop through the list
            for (int i = 0; i < displayStaffList.Count; i++)
            {
                // Getting all the user roles list
                displayStaffList[i].UserRoleList = this.iStaffDataAccess.GetAllUserRolesbasedUser(displayStaffList[i].Id, connectionString);
            }
            // End of Loop through the list

            // Return the list
            return displayStaffList;
        }

        // GetAllUserRolesbasedUser
        /// <summary>
        /// Get Display staff details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public List<UserRole> GetAllUserRolesbasedUser(string userId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetAllUserRolesbasedUser(userId, connectionString);
        }

        // GetStaffDetails
        /// <summary>
        /// Getting the basic information of the user
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public StaffDetails GetStaffDetails(string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            StaffDetails staffDetails = this.iStaffDataAccess.GetStaffDetails(staffId, connectionString);
            // Getting the address details
            staffDetails.BusinessAddress = this.iStaffDataAccess.GetStaffAddessDetails(staffId, connectionString);
            // Getting the user roles
            staffDetails.UserRoleList = this.iStaffDataAccess.GetAllUserRolesIdsOnlybasedUser(staffId, connectionString);

            // Return the result
            return staffDetails;
        }

        // GetStaffAvatar
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public string GetStaffAvatar(string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.GetStaffAvatar(staffId, connectionString);
        }

        // RemoveStaffAvatar
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public bool RemoveStaffAvatar(string staffId, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.RemoveStaffAvatar(staffId, connectionString);
        }
    }
}
