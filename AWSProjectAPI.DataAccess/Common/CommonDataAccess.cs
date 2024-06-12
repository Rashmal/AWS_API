using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.Common
{
    public class CommonDataAccess : ICommonDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        protected string AWS_COMMON_DBConnectionString { get; set; }
        protected string AWS_ACCOUNT_DBConnectionString { get; set; }
        #endregion

        // Constructor
        public CommonDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            this.AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
            this.AWS_COMMON_DBConnectionString = configurationString.GetConnectionString("AWS_COMMON_DBString");
            this.AWS_ACCOUNT_DBConnectionString = configurationString.GetConnectionString("AWS_ACCOUNT_DBString");
        }

        // CheckEmailExists
        /// <summary>
        /// 
        /// Check if the email exists
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// userEmail -> string
        /// </remarks>
        public bool CheckEmailExists(string userEmail)
        {
            // Declare the token
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("User_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter EmailParameter = sqlCommandToken.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = userEmail;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "EML$EXS";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            status = Convert.ToBoolean(resultToken["Valid"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_CheckEmailExists ! :" + ex);
            }

            // Return the token
            return status;
        }

        // GetPriorityList
        /// <summary>
        /// Getting the priority list
        /// </summary>
        /// <returns>
        /// Priority object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Priority> GetPriorityList(ConnectionString connectionString)
        {
            // Declare the return value
            List<Priority> priorities = new List<Priority>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("Priorities_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            priorities.Add(new Priority()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetPriorityList ! :" + ex);
            }

            // Return the values
            return priorities;
        }

        // GetStatusList
        /// <summary>
        /// Getting the status list
        /// </summary>
        /// <returns>
        /// Status object list value
        /// </returns>
        /// <remarks>
        /// moduleCode -> string value
        /// </remarks>
        public List<Status> GetStatusList(string moduleCode, ConnectionString connectionString)
        {
            // Declare the return value
            List<Status> statusList = new List<Status>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("Statuses_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";
                        SqlParameter ModuleCodeParameter = sqlCommandToken.Parameters.Add("@ModuleCode", SqlDbType.VarChar, 500);
                        ModuleCodeParameter.Value = moduleCode;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            statusList.Add(new Status()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString(),
                                ColorCode = resultToken["ColorCode"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetStatusList ! :" + ex);
            }

            // Return the values
            return statusList;
        }

        // GetModuleList
        /// <summary>
        /// Getting the module list
        /// </summary>
        /// <returns>
        /// Module object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetModuleList(ConnectionString connectionString)
        {
            // Declare the return value
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("Modules_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";

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
                throw new Exception("Error in CommonDataAccess_GetModuleList ! :" + ex);
            }

            // Return the values
            return moduleList;
        }

        // GetAllStaffList
        /// <summary>
        /// Getting all the staff list
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<BasicUserDetails> GetAllStaffList(ConnectionString connectionString)
        {
            // Declare the return value
            List<BasicUserDetails> staffList = new List<BasicUserDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("User_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            staffList.Add(new BasicUserDetails()
                            {
                                Id = resultToken["Id"].ToString(),
                                Avatar = "",
                                Email = resultToken["Email"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                FullName = resultToken["FirstName"].ToString() + " " + resultToken["LastName"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllStaffList ! :" + ex);
            }

            // Return the values
            return staffList;
        }

        // TotalGlobalNotes
        /// <summary>
        /// Getting the total of global notes
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public int TotalGlobalNotes(string userId, ConnectionString connectionString)
        {
            // Declare the return value
            int totalCount = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "TOT$CNT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            totalCount = Convert.ToInt32(resultToken["TotalCount"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_TotalGlobalNotes ! :" + ex);
            }

            // Return the values
            return totalCount;
        }

        // TotalSE
        /// <summary>
        /// Getting the total of global notes
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public int TotalSE(string userId, ConnectionString connectionString)
        {
            // Declare the return value
            int totalCount = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "TOT$SE$CNT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            totalCount = Convert.ToInt32(resultToken["TotalCount"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_TotalSE ! :" + ex);
            }

            // Return the values
            return totalCount;
        }

        // TotalBG
        /// <summary>
        /// Getting the total of global notes
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public int TotalBG(string userId, ConnectionString connectionString)
        {
            // Declare the return value
            int totalCount = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "TOT$BG$CNT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            totalCount = Convert.ToInt32(resultToken["TotalCount"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_TotalBG ! :" + ex);
            }

            // Return the values
            return totalCount;
        }

        // GetModuleListBasedUserRole
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetModuleListBasedUserRole(string userRole, bool isStatic, ConnectionString connectionString)
        {
            // Declare the return value
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("Modules_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$BUR";
                        SqlParameter UserRoleCodeParameter = sqlCommandToken.Parameters.Add("@UserRoleCode", SqlDbType.VarChar, 50);
                        UserRoleCodeParameter.Value = userRole;
                        SqlParameter IsStaticParameter = sqlCommandToken.Parameters.Add("@IsStatic", SqlDbType.Bit);
                        IsStaticParameter.Value = isStatic;

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
                throw new Exception("Error in CommonDataAccess_GetModuleListBasedUserRole ! :" + ex);
            }

            // Return the values
            return moduleList;
        }

        // GetAccessListBasedUserRole
        /// <summary>
        /// Getting all the access list based on the user role
        /// </summary>
        /// <returns>
        /// UserRoleAccessDetail object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<UserRoleAccessDetail> GetAccessListBasedUserRole(string userRole, ConnectionString connectionString)
        {
            // Declare the return value
            List<UserRoleAccessDetail> userRoleAccessDetailList = new List<UserRoleAccessDetail>();

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
                        SqlParameter UserRoleCodeParameter = sqlCommandToken.Parameters.Add("@UserRoleCode", SqlDbType.VarChar, 50);
                        UserRoleCodeParameter.Value = userRole;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            userRoleAccessDetailList.Add(new UserRoleAccessDetail()
                            {
                                AccessList = resultToken["AccessList"].ToString(),
                                ModuleCode = resultToken["ModuleCode"].ToString(),
                                ModuleId = Convert.ToInt32(resultToken["ModuleId"].ToString()),
                                ModuleName = resultToken["ModuleName"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAccessListBasedUserRole ! :" + ex);
            }

            // Return the values
            return userRoleAccessDetailList;
        }

        // Getting all the access list based on the user role for view
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetViewAccessListBasedUserRole(string userRole, ConnectionString connectionString)
        {
            // Declare the return value
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
                        UserParameter.Value = "GET$VIEW";
                        SqlParameter UserRoleCodeParameter = sqlCommandToken.Parameters.Add("@UserRoleCode", SqlDbType.VarChar, 50);
                        UserRoleCodeParameter.Value = userRole;

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
                throw new Exception("Error in CommonDataAccess_GetModuleListBasedUserRole ! :" + ex);
            }

            // Return the values
            return moduleList;
        }

        // GetAccountDetails
        /// <summary>
        /// Getting all the account details
        /// </summary>
        /// <returns>
        /// AccountDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<AccountDetails> GetAccountDetails(Filter filter)
        {
            // Declare the return value
            List<AccountDetails> accountDetailsList = new List<AccountDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_Account_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            accountDetailsList.Add(new AccountDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Total = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAccountDetails ! :" + ex);
            }

            // Return the values
            return accountDetailsList;
        }

        // GetAllBusinessNumberTypes
        /// <summary>
        /// Getting all the business number type details
        /// </summary>
        /// <returns>
        /// BusinessNumberType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<BusinessNumberType> GetAllBusinessNumberTypes()
        {
            // Declare the return value
            List<BusinessNumberType> businessNumberTypeList = new List<BusinessNumberType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_BusinessNumberTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            businessNumberTypeList.Add(new BusinessNumberType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllBusinessNumberTypes ! :" + ex);
            }

            // Return the values
            return businessNumberTypeList;
        }

        // GetAllClientSizes
        /// <summary>
        /// Getting all the client size details
        /// </summary>
        /// <returns>
        /// ClientSize object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ClientSize> GetAllClientSizes()
        {
            // Declare the return value
            List<ClientSize> clientSizeseList = new List<ClientSize>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ClientSizes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            clientSizeseList.Add(new ClientSize()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllClientSizes ! :" + ex);
            }

            // Return the values
            return clientSizeseList;
        }

        // GetAllContactTypes
        /// <summary>
        /// Getting all the contact type details
        /// </summary>
        /// <returns>
        /// ContactType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ContactType> GetAllContactTypes()
        {
            // Declare the return value
            List<ContactType> contactTypesList = new List<ContactType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ContactTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            contactTypesList.Add(new ContactType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllContactTypes ! :" + ex);
            }

            // Return the values
            return contactTypesList;
        }

        // GetAllCountries
        /// <summary>
        /// Getting all the country details
        /// </summary>
        /// <returns>
        /// Country object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Country> GetAllCountries()
        {
            // Declare the return value
            List<Country> countryList = new List<Country>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_Country_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            countryList.Add(new Country()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString(),
                                FlagIcon = resultToken["FlagIcon"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllCountries ! :" + ex);
            }

            // Return the values
            return countryList;
        }

        // GetAllDays
        /// <summary>
        /// Getting all the day details
        /// </summary>
        /// <returns>
        /// DayDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<DayDetails> GetAllDays()
        {
            // Declare the return value
            List<DayDetails> dayList = new List<DayDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_Days_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            dayList.Add(new DayDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllDays ! :" + ex);
            }

            // Return the values
            return dayList;
        }

        // GetAllPriceClassifications
        /// <summary>
        /// Getting all the price classfication details
        /// </summary>
        /// <returns>
        /// PriceClassification object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<PriceClassification> GetAllPriceClassifications()
        {
            // Declare the return value
            List<PriceClassification> priceClassificationList = new List<PriceClassification>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_PriceClassifications_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            priceClassificationList.Add(new PriceClassification()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllPriceClassifications ! :" + ex);
            }

            // Return the values
            return priceClassificationList;
        }

        // GetAllRatings
        /// <summary>
        /// Getting all the rating details
        /// </summary>
        /// <returns>
        /// RatingDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<RatingDetails> GetAllRatings()
        {
            // Declare the return value
            List<RatingDetails> ratingDetailsList = new List<RatingDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_Ratings_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            ratingDetailsList.Add(new RatingDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllRatings ! :" + ex);
            }

            // Return the values
            return ratingDetailsList;
        }

        // GetAllSocialMediaTypes
        /// <summary>
        /// Getting all the social media type details
        /// </summary>
        /// <returns>
        /// SocialMediaType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<SocialMediaType> GetAllSocialMediaTypes()
        {
            // Declare the return value
            List<SocialMediaType> socialMediTypeList = new List<SocialMediaType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_SocialMediaTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            socialMediTypeList.Add(new SocialMediaType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllSocialMediaTypes ! :" + ex);
            }

            // Return the values
            return socialMediTypeList;
        }

        // GetAllTermTypes
        /// <summary>
        /// Getting all the term type details
        /// </summary>
        /// <returns>
        /// TermType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<TermType> GetAllTermTypes()
        {
            // Declare the return value
            List<TermType> termTypeList = new List<TermType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_TermTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            termTypeList.Add(new TermType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllTermTypes ! :" + ex);
            }

            // Return the values
            return termTypeList;
        }

        // GetAllRoleDetails
        /// <summary>
        /// Getting all the role details
        /// </summary>
        /// <returns>
        /// RoleDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<RoleDetails> GetAllRoleDetails()
        {
            // Declare the return value
            List<RoleDetails> roleDetailsList = new List<RoleDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_COMMON_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_RoleDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            roleDetailsList.Add(new RoleDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                Code = resultToken["Code"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllRoleDetails ! :" + ex);
            }

            // Return the values
            return roleDetailsList;
        }

        // GetConnectionString
        /// <summary>
        /// Getting all the connection details
        /// </summary>
        /// <returns>
        /// ConnectionString object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public ConnectionString GetConnectionString(int parentGroupId, string moduleCode)
        {
            // Declare the return value
            List<ConnectionString> ConnectionStringList = new List<ConnectionString>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("GroupConnectionString_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$BU";
                        SqlParameter ParentGroupIdParameter = sqlCommandToken.Parameters.Add("@ParentGroupId", SqlDbType.Int);
                        ParentGroupIdParameter.Value = parentGroupId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            ConnectionStringList.Add(new ConnectionString()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["DatabaseName"].ToString(),
                                DatabaseConfig = resultToken["ConnectionString"].ToString().Replace("\\\\","\\")
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetConnectionString ! :" + ex);
            }

            // Return the values
            return ConnectionStringList.Find(obj => obj.Name.ToUpper() == moduleCode.ToUpper());
        }

        // GetAllParentGroupsDetailsByEmail
        /// <summary>
        /// Getting all the parent groups by email
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ParentGroup> GetAllParentGroupsDetailsByEmail(string email)
        {
            // Declare the return value
            List<ParentGroup> parentGroupList = new List<ParentGroup>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("ParentGroupNames_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "PR$GR$EM";
                        SqlParameter EmailParameter = sqlCommandToken.Parameters.Add("@Email", SqlDbType.VarChar);
                        EmailParameter.Value = email;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            parentGroupList.Add(new ParentGroup()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllParentGroupsDetailsByEmail ! :" + ex);
            }

            // Return the values
            return parentGroupList;
        }

        // GetAllParentGroupsDetailsById
        /// <summary>
        /// Getting all the parent groups by id
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ParentGroup> GetAllParentGroupsDetailsById(string userId)
        {
            // Declare the return value
            List<ParentGroup> parentGroupList = new List<ParentGroup>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWS_ACCOUNT_DBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("ParentGroupNames_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "PR$GR$ID";
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = userId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            parentGroupList.Add(new ParentGroup()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllParentGroupsDetailsById ! :" + ex);
            }

            // Return the values
            return parentGroupList;
        }

        // GetAllModulesByUserId
        /// <summary>
        /// Getting all the modules by user id
        /// </summary>
        /// <returns>
        /// Module object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetAllModulesByUserId(string userId, ConnectionString connectionString = null)
        {
            // Declare the return value
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("User_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$ACL";
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = userId;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            moduleList.Add(new Module()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                ModuleCode = resultToken["ModuleCode"].ToString(),
                                ModuleIcon = resultToken["ModuleIcon"].ToString(),
                                RedirectUrl = resultToken["RedirectUrl"].ToString(),
                                IsDisable = Convert.ToBoolean(resultToken["IsDisabled"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_GetAllModulesByUserId ! :" + ex);
            }

            // Return the values
            return moduleList;
        }
    }
}
