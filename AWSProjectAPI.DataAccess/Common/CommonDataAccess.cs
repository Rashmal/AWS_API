﻿using AWSProjectAPI.Core.Authentication;
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
        #endregion

        // Constructor
        public CommonDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            this.AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
        }

        // CheckEmailExists
        /// <summary>
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
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
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
        public List<Priority> GetPriorityList()
        {
            // Declare the return value
            List<Priority> priorities = new List<Priority>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
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
        public List<Status> GetStatusList(string moduleCode)
        {
            // Declare the return value
            List<Status> statusList = new List<Status>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
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
        public List<Module> GetModuleList()
        {
            // Declare the return value
            List<Module> moduleList = new List<Module>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
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
        public List<BasicUserDetails> GetAllStaffList()
        {
            // Declare the return value
            List<BasicUserDetails> staffList = new List<BasicUserDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
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
    }
}
