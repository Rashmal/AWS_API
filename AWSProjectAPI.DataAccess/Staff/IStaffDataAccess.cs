﻿using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.Staff
{
    public interface IStaffDataAccess
    {
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
        List<UserRole> GetAllUserRoles(ConnectionString connectionString);

        // AddNewUserRoles
        /// <summary>
        /// Setting all the user roles
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// connectionString -> ConnectionString
        /// userRole -> UserRole
        /// actionType -> string
        /// </remarks>
        int AddNewUserRoles(UserRole userRole, ConnectionString connectionString);

        // UpdateUserRoles
        /// <summary>
        /// Updating the user roles
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// connectionString -> ConnectionString
        /// userRole -> UserRole
        /// actionType -> string
        /// </remarks>
        int UpdateUserRoles(UserRole userRole, ConnectionString connectionString);

        // RemoveUserRoles
        /// <summary>
        /// Updating the user roles
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// connectionString -> ConnectionString
        /// userRoleId -> int
        /// actionType -> string
        /// </remarks>
        int RemoveUserRoles(int userRoleId, ConnectionString connectionString);

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
        List<Module> GetAllModulesbasedUserRole(int userRoleId, ConnectionString connectionString);

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
        bool SetModuleAccess(int moduleId, bool moduleAccess, int userRoleId, ConnectionString connectionString);

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
        List<Module> GetAccessibleModules(int userRoleId, ConnectionString connectionString);

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
        List<SubTabDetails> GetTabDetailaBasedOnModuleUserRole(Filter filter, int userRoleId, int moduleId, ConnectionString connectionString);

        // GetSubTabFeaureAccessList
        /// <summary>
        /// Getting all the sub tab feaure access list
        /// </summary>
        /// <returns>
        /// AccessLevelFeatureDetails list
        /// </returns>
        /// <remarks>
        /// companyId -> number
        /// moduleAccess -> bool
        /// moduleId -> number
        /// </remarks>
        List<AccessLevelFeatureDetails> GetSubTabFeaureAccessList(int subTabId, ConnectionString connectionString);

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
        bool SetTabDetailaAccessLevelBasedOnModuleUserRole(int subTabId, bool accessLevel, ConnectionString connectionString);

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
        bool SetSubTabFeatureAccessLevel(int subTabFeatureId, bool addAccessLevel, bool editAccessLevel, bool deleteAccessLevel, ConnectionString connectionString);

        // SetDefaultAccessForNewUserRole
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
        bool SetDefaultAccessForNewUserRole(int userRoleId, ConnectionString connectionString);

        // DuplicateUserRoles
        /// <summary>
        /// Duplicating the user roles
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// connectionString -> ConnectionString
        /// userRole -> UserRole
        /// actionType -> string
        /// </remarks>
        int DuplicateUserRoles(UserRole userRole, ConnectionString connectionString);

        // GetAllParentGroups
        /// <summary>
        /// Getting all the parent groups by id
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<ParentGroup> GetAllParentGroups();

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
        bool SetDefaultDuplicatedAccessForNewUserRole(int newId, int prevId, int prevCompanyId, ConnectionString connectionString);
    }
}
