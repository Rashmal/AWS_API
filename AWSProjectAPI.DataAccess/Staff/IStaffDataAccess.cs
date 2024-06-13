using AWSProjectAPI.Core.Client;
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
    }
}
