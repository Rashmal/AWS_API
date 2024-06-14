using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using AWSProjectAPI.Core.Authentication;
using Module = AWSProjectAPI.Core.Common.Module;

namespace AWSProjectAPI.DataAccess.Staff
{
    public class StaffDataAccess : IStaffDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        protected string AWS_CLIENT_DBConnectionString { get; set; }
        protected string AWS_ACCOUNT_DBString { get; set; }
        #endregion

        // Constructor
        public StaffDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
            AWS_CLIENT_DBConnectionString = configurationString.GetConnectionString("AWS_CLIENT_DBString");
            AWS_ACCOUNT_DBString = configurationString.GetConnectionString("AWS_ACCOUNT_DBString");
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
        public List<UserRole> GetAllUserRoles(ConnectionString connectionString)
        {
            // Declare the value list
            List<UserRole> userRoleList = new List<UserRole>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            userRoleList.Add(new UserRole()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["RoleName"].ToString()
                            });
                        }
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_GetAllUserRoles ! :" + ex);
            }

            // Return the values
            return userRoleList;
        }

        // AddNewUserRoles
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
        public int AddNewUserRoles(UserRole userRole, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";
                        SqlParameter NameParameter = sqlCommandToken.Parameters.Add("@Name", SqlDbType.VarChar, 500);
                        NameParameter.Value = userRole.Name;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_AddNewUserRoles ! :" + ex);
            }

            // Return the values
            return newId;
        }

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
        public int UpdateUserRoles(UserRole userRole, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = userRole.Id;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPD";
                        SqlParameter NameParameter = sqlCommandToken.Parameters.Add("@Name", SqlDbType.VarChar, 500);
                        NameParameter.Value = userRole.Name;
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRole.Id;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_UpdateUserRoles ! :" + ex);
            }

            // Return the values
            return newId;
        }

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
        public int RemoveUserRoles(int userRoleId, ConnectionString connectionString)
        {
            // Declare the value list
            int newID = userRoleId;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRoleId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_RemoveUserRoles ! :" + ex);
            }

            // Return the values
            return newID;
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
        public List<Module> GetAllModulesbasedUserRole(int userRoleId, ConnectionString connectionString)
        {
            // Declare the value list
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoleAccessDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRoleId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            moduleList.Add(new Module()
                            {
                                Id = Convert.ToInt32(resultToken["ModuleId"].ToString()),
                                Name = resultToken["ModuleName"].ToString(),
                                ModuleCode = resultToken["ModuleCode"].ToString(),
                                ModuleIcon = "",
                                RedirectUrl = "",
                                IsDisable = Convert.ToBoolean(resultToken["IsEnable"].ToString())
                            });
                        }
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_GetAllModulesbasedUserRole ! :" + ex);
            }

            // Return the values
            return moduleList;
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
        public bool SetModuleAccess(int moduleId, bool moduleAccess, int userRoleId, ConnectionString connectionString)
        {
            // Declare the value list
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoleAccessDetails_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SURM";
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRoleId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = moduleId;
                        SqlParameter ModuleAccessParameter = sqlCommandToken.Parameters.Add("@ActionState", SqlDbType.Bit);
                        ModuleAccessParameter.Value = moduleAccess;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        status = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_SetModuleAccess ! :" + ex);
            }

            // Return the values
            return status;
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
        public List<Module> GetAccessibleModules(int userRoleId, ConnectionString connectionString)
        {
            // Declare the value list
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoleAccessDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ACS";
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRoleId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            moduleList.Add(new Module()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                ModuleCode = resultToken["ModuleCode"].ToString(),
                                Name = resultToken["Name"].ToString(),
                                ModuleIcon = resultToken["ModuleIcon"].ToString(),
                                IsDisable = Convert.ToBoolean(resultToken["IsDisabled"].ToString()),
                                RedirectUrl = resultToken["RedirectUrl"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAccessibleModules ! :" + ex);
            }

            // Return the values
            return moduleList;
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
        public List<SubTabDetails> GetTabDetailaBasedOnModuleUserRole(Filter filter,int userRoleId, int moduleId, ConnectionString connectionString)
        {
            // Declare the value list
            List<SubTabDetails> subTabDetailsList = new List<SubTabDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SubTabAccessDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";
                        SqlParameter UserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        UserRoleIdParameter.Value = userRoleId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = moduleId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            subTabDetailsList.Add(new SubTabDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["SubTabName"].ToString(),
                                EnableAccess = Convert.ToBoolean(resultToken["IsEnabled"].ToString()),
                                AccessLevelFeatureDetailsList = new List<AccessLevelFeatureDetails>()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetTabDetailaBasedOnModuleUserRole ! :" + ex);
            }

            // Return the values
            return subTabDetailsList;
        }

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
        public List<AccessLevelFeatureDetails> GetSubTabFeaureAccessList(int subTabId, ConnectionString connectionString)
        {
            // Declare the value list
            List<AccessLevelFeatureDetails> accessLevelFeatureDetailsList = new List<AccessLevelFeatureDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SubTabFeatureAccessDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";
                        SqlParameter SubTabIdParameter = sqlCommandToken.Parameters.Add("@SubTabId", SqlDbType.Int);
                        SubTabIdParameter.Value = subTabId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            accessLevelFeatureDetailsList.Add(new AccessLevelFeatureDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["FeatureName"].ToString(),
                                AddAccess = Convert.ToBoolean(resultToken["AddAccess"].ToString()),
                                EditAccess = Convert.ToBoolean(resultToken["EditAccess"].ToString()),
                                DeleteAccess = Convert.ToBoolean(resultToken["DeleteAccess"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetSubTabFeaureAccessList ! :" + ex);
            }

            // Return the values
            return accessLevelFeatureDetailsList;
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
        public bool SetTabDetailaAccessLevelBasedOnModuleUserRole(int subTabId, bool accessLevel, ConnectionString connectionString)
        {
            // Declare the value list
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SubTabAccessDetails_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET";
                        SqlParameter TabIdParameter = sqlCommandToken.Parameters.Add("@TabId", SqlDbType.Int);
                        TabIdParameter.Value = subTabId;
                        SqlParameter TabStateParameter = sqlCommandToken.Parameters.Add("@TabState", SqlDbType.Bit);
                        TabStateParameter.Value = accessLevel;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        status = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetTabDetailaAccessLevelBasedOnModuleUserRole ! :" + ex);
            }

            // Return the values
            return status;
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
        public bool SetSubTabFeatureAccessLevel(int subTabFeatureId, bool addAccessLevel, bool editAccessLevel, bool deleteAccessLevel, ConnectionString connectionString)
        {
            // Declare the value list
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SubTabFeatureAccessDetails_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET";
                        SqlParameter SubTabFeatureIdParameter = sqlCommandToken.Parameters.Add("@SubTabFeatureId", SqlDbType.Int);
                        SubTabFeatureIdParameter.Value = subTabFeatureId;
                        SqlParameter AddAccessParameter = sqlCommandToken.Parameters.Add("@AddAccess", SqlDbType.Bit);
                        AddAccessParameter.Value = addAccessLevel;
                        SqlParameter EditAccessParameter = sqlCommandToken.Parameters.Add("@EditAccess", SqlDbType.Bit);
                        EditAccessParameter.Value = editAccessLevel;
                        SqlParameter DeleteAccessParameter = sqlCommandToken.Parameters.Add("@DeleteAccess", SqlDbType.Bit);
                        DeleteAccessParameter.Value = deleteAccessLevel;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        status = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetSubTabFeatureAccessLevel ! :" + ex);
            }

            // Return the values
            return status;
        }

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
        public bool SetDefaultAccessForNewUserRole(int userRoleId, ConnectionString connectionString)
        {
            // Declare the value list
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("DefaultuserRole_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "DEFLT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        status = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetDefaultAccessForNewUserRole ! :" + ex);
            }

            // Return the values
            return status;
        }

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
        public int DuplicateUserRoles(UserRole userRole, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "DUP";
                        SqlParameter NameParameter = sqlCommandToken.Parameters.Add("@Name", SqlDbType.VarChar, 500);
                        NameParameter.Value = userRole.Name;
                        SqlParameter NameUserRoleIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.Int);
                        NameUserRoleIdParameter.Value = userRole.Id;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }
                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in StaffDataAccess_AddNewUserRoles ! :" + ex);
            }

            // Return the values
            return newId;
        }

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
        public List<ParentGroup> GetAllParentGroups()
        {
            // Declare the return value
            List<ParentGroup> parentGroupList = new List<ParentGroup>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("ParentGroupNames_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            parentGroupList.Add(new ParentGroup()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["ParentGroupName"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllParentGroups ! :" + ex);
            }

            // Return the values
            return parentGroupList;
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
        public bool SetDefaultDuplicatedAccessForNewUserRole(int newId, int prevId, int prevCompanyId, ConnectionString connectionString)
        {
            // Declare the value list
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("DefaultuserRole_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "DUP$ACC";
                        SqlParameter PrevCompanyIdParameter = sqlCommandToken.Parameters.Add("@PrevCompanyId", SqlDbType.Int);
                        PrevCompanyIdParameter.Value = prevCompanyId;
                        SqlParameter PreUserRoleIdParameter = sqlCommandToken.Parameters.Add("@PreUserRoleId", SqlDbType.BigInt);
                        PreUserRoleIdParameter.Value = prevId;
                        SqlParameter newIdParameter = sqlCommandToken.Parameters.Add("@UserRoleId", SqlDbType.BigInt);
                        newIdParameter.Value = newId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        status = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetDefaultDuplicatedAccessForNewUserRole ! :" + ex);
            }

            // Return the values
            return status;
        }
    }
}
