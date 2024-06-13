using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.ClientDetails;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.DataAccess.Staff;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Staff
{
    public class StaffService : IStaffService
    {
        #region Private Properties
        private readonly IStaffDataAccess iStaffDataAccess;
        protected string GLOBAL_FILES_PATH { get; set; }
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
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Getting the result
            return this.iStaffDataAccess.SetDefaultAccessForNewUserRole(userRoleId, connectionString);
        }
    }
}
