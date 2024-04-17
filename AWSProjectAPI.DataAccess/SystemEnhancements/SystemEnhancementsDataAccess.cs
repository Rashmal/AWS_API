using AWSProjectAPI.Core.SystemEnhancements;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.Authentication;

namespace AWSProjectAPI.DataAccess.SystemEnhancements
{
    public class SystemEnhancementsDataAccess : ISystemEnhancementsDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        #endregion

        // Constructor
        public SystemEnhancementsDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            this.AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
        }

        // AddSystemEnhancementDetails
        /// <summary>
        /// Adding System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        public string AddSystemEnhancementDetails(SystemEnhancement systemEnhancement)
        {
            // Declare the return value
            string newIdValue = "";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter PriorityIdParameter = sqlCommandToken.Parameters.Add("@PriorityId", SqlDbType.Int);
                        PriorityIdParameter.Value = systemEnhancement.PriorityId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = systemEnhancement.StatusId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = systemEnhancement.ModuleId;
                        SqlParameter AddedUserIdParameter = sqlCommandToken.Parameters.Add("@AddedUserId", SqlDbType.VarChar, 5000);
                        AddedUserIdParameter.Value = systemEnhancement.AddedUserId;
                        SqlParameter EstimatedHoursParameter = sqlCommandToken.Parameters.Add("@EstimatedHours", SqlDbType.Int);
                        EstimatedHoursParameter.Value = systemEnhancement.EstimatedHours;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar, 1000);
                        TitleParameter.Value = systemEnhancement.Title;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = systemEnhancement.Description;
                        SqlParameter StartDateParameter = sqlCommandToken.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        StartDateParameter.Value = systemEnhancement.StartDate;
                        SqlParameter EndDateParameter = sqlCommandToken.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        EndDateParameter.Value = systemEnhancement.EndDate;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newIdValue = resultToken["NewId"].ToString();
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_AddSystemEnhancementDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // UpdateSystemEnhancementDetails
        /// <summary>
        /// Updating System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        public string UpdateSystemEnhancementDetails(SystemEnhancement systemEnhancement)
        {
            // Declare the return value
            string newIdValue = "";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter PriorityIdParameter = sqlCommandToken.Parameters.Add("@PriorityId", SqlDbType.Int);
                        PriorityIdParameter.Value = systemEnhancement.PriorityId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = systemEnhancement.StatusId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = systemEnhancement.ModuleId;
                        SqlParameter AddedUserIdParameter = sqlCommandToken.Parameters.Add("@AddedUserId", SqlDbType.VarChar, 5000);
                        AddedUserIdParameter.Value = systemEnhancement.AddedUserId;
                        SqlParameter EstimatedHoursParameter = sqlCommandToken.Parameters.Add("@EstimatedHours", SqlDbType.Int);
                        EstimatedHoursParameter.Value = systemEnhancement.EstimatedHours;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar, 1000);
                        TitleParameter.Value = systemEnhancement.Title;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = systemEnhancement.Description;
                        SqlParameter StartDateParameter = sqlCommandToken.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        StartDateParameter.Value = systemEnhancement.StartDate;
                        SqlParameter EndDateParameter = sqlCommandToken.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        EndDateParameter.Value = systemEnhancement.EndDate;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancement.Id;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newIdValue = systemEnhancement.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_UpdateSystemEnhancementDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // DeleteSystemEnhancementDetails
        /// <summary>
        /// Removing System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        public string DeleteSystemEnhancementDetails(string systemEnhancementId)
        {
            // Declare the return value
            string newIdValue = "";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "DLT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newIdValue = systemEnhancementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_DeleteSystemEnhancementDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // DeleteSystemEnhancementAssignedStaff
        /// <summary>
        /// Removing System Enhancement related assigned staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// </remarks>
        public string DeleteSystemEnhancementAssignedStaff(string systemEnhancementId)
        {
            // Declare the return value
            string newIdValue = "SUCCESS";
            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsAssignedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_DeleteSystemEnhancementAssignedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // DeleteSystemEnhancementRequestedStaff
        /// <summary>
        /// Removing System Enhancement related requested staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// </remarks>
        public string DeleteSystemEnhancementRequestedStaff(string systemEnhancementId)
        {
            // Declare the return value
            string newIdValue = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsRequestedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_DeleteSystemEnhancementRequestedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // AddSystemEnhancementAssignedStaff
        /// <summary>
        /// Adding System Enhancement related assigned staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// staffId -> string value
        /// </remarks>
        public string AddSystemEnhancementAssignedStaff(string systemEnhancementId, string staffId)
        {
            // Declare the return value
            string newIdValue = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsAssignedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = staffId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_AddSystemEnhancementAssignedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // AddSystemEnhancementRequestedStaff
        /// <summary>
        /// Adding System Enhancement related requested staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// staffId -> string value
        /// </remarks>
        public string AddSystemEnhancementRequestedStaff(string systemEnhancementId, string staffId)
        {
            // Declare the return value
            string newIdValue = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsRequestedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = staffId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                newIdValue = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_AddSystemEnhancementRequestedStaff ! :" + ex);
            }

            return newIdValue;
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
            // Declare the value list
            List<DisplayModule> displayModules = new List<DisplayModule>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = filter.ModuleId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SE$MD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            displayModules.Add(new DisplayModule()
                            {
                                Id = Convert.ToInt32(resultToken["ModuleId"].ToString()),
                                Name = resultToken["ModuleName"].ToString(),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEnhancementDisplayModules ! :" + ex);
            }

            // Return the values
            return displayModules;
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
        public List<ViewSystemEnhancement> GetSystemEnhancementDisplayList(Filter filter)
        {
            // Declare the value list
            List<ViewSystemEnhancement> viewSystemEnhancementList = new List<ViewSystemEnhancement>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter StaffIdParameter = sqlCommandToken.Parameters.Add("@StaffId", SqlDbType.VarChar);
                        StaffIdParameter.Value = filter.StaffId;
                        SqlParameter PriorityIdParameter = sqlCommandToken.Parameters.Add("@PriorityId", SqlDbType.Int);
                        PriorityIdParameter.Value = filter.PriorityId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = filter.StatusId;
                        SqlParameter SearchQueryParameter = sqlCommandToken.Parameters.Add("@SearchQuery", SqlDbType.VarChar, 500);
                        SearchQueryParameter.Value = filter.SearchQuery;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = filter.ModuleId;
                        SqlParameter StartDateParameter = sqlCommandToken.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        StartDateParameter.Value = filter.StartDate;
                        SqlParameter EndDateParameter = sqlCommandToken.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        EndDateParameter.Value = filter.EndDate;
                        SqlParameter SortColumnParameter = sqlCommandToken.Parameters.Add("@SortColumn", SqlDbType.VarChar);
                        SortColumnParameter.Value = filter.SortColumn;
                        SqlParameter SortDirectionParameter = sqlCommandToken.Parameters.Add("@SortDirection", SqlDbType.VarChar);
                        SortDirectionParameter.Value = filter.SortDirection;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "VIEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            viewSystemEnhancementList.Add(new ViewSystemEnhancement()
                            {
                                Title = resultToken["Title"].ToString(),
                                StatusName = resultToken["StatusName"].ToString(),
                                StartDate = Convert.ToDateTime(resultToken["StartDate"].ToString()),
                                EndDate = Convert.ToDateTime(resultToken["EndDate"].ToString()),
                                PriorityName = resultToken["PriorityName"].ToString(),
                                EstimatedHours = Convert.ToInt32(resultToken["EstimatedHours"].ToString()),
                                Id = resultToken["Id"].ToString(),
                                RequestedStaffList = new List<BasicUserDetails>(),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEnhancementDisplayList ! :" + ex);
            }

            // Return the values
            return viewSystemEnhancementList;
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
        public SystemEnhancement GetSystemEnhancementDetailsById(string systemEnhancementId)
        {
            // Declare the value list
            SystemEnhancement systemEnhancement = new SystemEnhancement();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = systemEnhancementId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "BY$ID";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            systemEnhancement = new SystemEnhancement()
                            {
                                Id = resultToken["Id"].ToString(),
                                Title = resultToken["Title"].ToString(),
                                Description = resultToken["Description"].ToString(),
                                StatusId = Convert.ToInt32(resultToken["StatusId"].ToString()),
                                PriorityId = Convert.ToInt32(resultToken["PriorityId"].ToString()),
                                ModuleId = Convert.ToInt32(resultToken["ModuleId"].ToString()),
                                StartDate = Convert.ToDateTime(resultToken["StartDate"].ToString()),
                                EndDate = Convert.ToDateTime(resultToken["EndDate"].ToString()),
                                AddedUserId = resultToken["AddedUserId"].ToString(),
                                EstimatedHours = Convert.ToInt32(resultToken["EstimatedHours"].ToString()),
                                AssignedStaffList = new List<Core.Authentication.BasicUserDetails>(),
                                RequestedStaffList = new List<Core.Authentication.BasicUserDetails>()
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEnhancementDetailsById ! :" + ex);
            }

            // Return the values
            return systemEnhancement;
        }

        // GetSystemEnhancementAssignedStaff
        /// <summary>
        /// Getting the system enhancements assigned staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        public List<BasicUserDetails> GetSystemEnhancementAssignedStaff(string systemEnhancementId)
        {
            // Declare the value list
            List<BasicUserDetails> basicUserDetaislList = new List<BasicUserDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsAssignedStaffs_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            basicUserDetaislList.Add(new BasicUserDetails()
                            {
                                Id = resultToken["Id"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                Avatar = resultToken["Avatar"].ToString(),
                                Email = resultToken["Email"].ToString(),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEnhancementAssignedStaff ! :" + ex);
            }

            // Return the values
            return basicUserDetaislList;
        }

        // GetSystemEnhancementRequestedStaff
        /// <summary>
        /// Getting the system enhancements requested staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        public List<BasicUserDetails> GetSystemEnhancementRequestedStaff(string systemEnhancementId)
        {
            // Declare the value list
            List<BasicUserDetails> basicUserDetaislList = new List<BasicUserDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsRequestedStaffs_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            basicUserDetaislList.Add(new BasicUserDetails()
                            {
                                Id = resultToken["Id"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                Avatar = resultToken["Avatar"].ToString(),
                                Email = resultToken["Email"].ToString(),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEnhancementRequestedStaff ! :" + ex);
            }

            // Return the values
            return basicUserDetaislList;
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
            // Declare the value list
            bool resultStatus = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = statusId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE@STS";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = true;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = false;
                throw new Exception("Error in SystemEnhancementsDataAccess_UpdateSystemEnhancementStatus ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // AddSystemEnhancementChangeDate
        /// <summary>
        /// Adding the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        public string AddSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate)
        {
            // Declare the value list
            string resultStatus = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementChangeDate.SystemEnhancementId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = systemEnhancementChangeDate.UserId;
                        SqlParameter OldFromDateParameter = sqlCommandToken.Parameters.Add("@OldFromDate", SqlDbType.DateTime);
                        OldFromDateParameter.Value = systemEnhancementChangeDate.OldFromDate;
                        SqlParameter OldToDateParameter = sqlCommandToken.Parameters.Add("@OldToDate", SqlDbType.DateTime);
                        OldToDateParameter.Value = systemEnhancementChangeDate.OldToDate;
                        SqlParameter OldDurationParameter = sqlCommandToken.Parameters.Add("@OldDuration", SqlDbType.Int);
                        OldDurationParameter.Value = systemEnhancementChangeDate.OldDuration;
                        SqlParameter NewFromDateParameter = sqlCommandToken.Parameters.Add("@NewFromDate", SqlDbType.DateTime);
                        NewFromDateParameter.Value = systemEnhancementChangeDate.NewFromDate;
                        SqlParameter NewToDateParameter = sqlCommandToken.Parameters.Add("@NewToDate", SqlDbType.DateTime);
                        NewToDateParameter.Value = systemEnhancementChangeDate.NewToDate;
                        SqlParameter NewDurationParameter = sqlCommandToken.Parameters.Add("@NewDuration", SqlDbType.Int);
                        NewDurationParameter.Value = systemEnhancementChangeDate.NewDuration;
                        SqlParameter ReasonParameter = sqlCommandToken.Parameters.Add("@Reason", SqlDbType.VarChar);
                        ReasonParameter.Value = systemEnhancementChangeDate.Reason;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "SUCCESS";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_AddSystemEnhancementChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // UpdateSystemEnhancementChangeDate
        /// <summary>
        /// Upadating the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        public string UpdateSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate)
        {
            // Declare the value list
            string resultStatus = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE";
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = systemEnhancementChangeDate.Id;
                        SqlParameter ReasonParameter = sqlCommandToken.Parameters.Add("@Reason", SqlDbType.VarChar);
                        ReasonParameter.Value = systemEnhancementChangeDate.Reason;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "SUCCESS";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_UpdateSystemEnhancementChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // DeleteSystemEnhancementChangeDate
        /// <summary>
        /// Removing the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        public string DeleteSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate)
        {
            // Declare the value list
            string resultStatus = "SUCCESS";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = systemEnhancementChangeDate.Id;

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "SUCCESS";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "ERROR";
                throw new Exception("Error in SystemEnhancementsDataAccess_DeleteSystemEnhancementChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
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
            // Declare the value list
            List<ViewSystemEnhancementChangeDate> viewSystemEnhancementChangeDateList = new List<ViewSystemEnhancementChangeDate>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsChangeHistory_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementId;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            viewSystemEnhancementChangeDateList.Add(new ViewSystemEnhancementChangeDate()
                            {
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                ChangedDate = Convert.ToDateTime(resultToken["ChangedDate"].ToString()),
                                NewDuration = Convert.ToInt32(resultToken["NewDuration"].ToString()),
                                NewFromDate = Convert.ToDateTime(resultToken["NewFromDate"].ToString()),
                                NewToDate = Convert.ToDateTime(resultToken["NewToDate"].ToString()),
                                Reason = resultToken["Reason"].ToString(),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEhancementChangeDate ! :" + ex);
            }

            // Return the values
            return viewSystemEnhancementChangeDateList;
        }

        // AddSystemEhancementComment
        /// <summary>
        /// Adding System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        public string AddSystemEhancementComment(SystemEnhancementComment systemEnhancementComment)
        {
            // Declare the value list
            string resultStatus = "false";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = systemEnhancementComment.SystemEnhancementId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = systemEnhancementComment.UserId;
                        SqlParameter ParentIdParameter = sqlCommandToken.Parameters.Add("@ParentId", SqlDbType.Int);
                        ParentIdParameter.Value = systemEnhancementComment.ParentId;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = systemEnhancementComment.Description;

                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "True";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "False";
                throw new Exception("Error in SystemEnhancementsDataAccess_AddSystemEhancementComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // UpdateSystemEhancementComment
        /// <summary>
        /// Update System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        public string UpdateSystemEhancementComment(SystemEnhancementComment systemEnhancementComment)
        {
            // Declare the value list
            string resultStatus = "false";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = systemEnhancementComment.Id;

                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "True";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "False";
                throw new Exception("Error in SystemEnhancementsDataAccess_UpdateSystemEhancementComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // DeleteSystemEhancementComment
        /// <summary>
        /// Removing System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        public string DeleteSystemEhancementComment(SystemEnhancementComment systemEnhancementComment)
        {
            // Declare the value list
            string resultStatus = "false";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = systemEnhancementComment.Id;

                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        resultStatus = "True";
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultStatus = "False";
                throw new Exception("Error in SystemEnhancementsDataAccess_DeleteSystemEhancementComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
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
            // Declare the value list
            List<ViewSystemEnhancementComment> viewSystemEnhancementCommentList = new List<ViewSystemEnhancementComment>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("SystemEnhancementsComments_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SystemEnhancementIdParameter = sqlCommandToken.Parameters.Add("@SystemEnhancementId", SqlDbType.VarChar);
                        SystemEnhancementIdParameter.Value = filter.Id;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter ParentIdParameter = sqlCommandToken.Parameters.Add("@ParentId", SqlDbType.Int);
                        ParentIdParameter.Value = filter.ParentId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            viewSystemEnhancementCommentList.Add(new ViewSystemEnhancementComment()
                            {
                                Description = resultToken["Description"].ToString(),
                                HasReply = Convert.ToBoolean(resultToken["HasReply"].ToString()),
                                AddedDate = Convert.ToDateTime(resultToken["ChangedDate"].ToString()),
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
                throw new Exception("Error in SystemEnhancementsDataAccess_GetSystemEhancementComment ! :" + ex);
            }

            // Return the values
            return viewSystemEnhancementCommentList;
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
            // Declare the value list
            List<StatisticsBoxData> statisticsBoxDataList = new List<StatisticsBoxData>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("Statistics_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL$SE";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            statisticsBoxDataList.Add(new StatisticsBoxData()
                            {
                                LabelName = resultToken["Name"].ToString(),
                                LabelColorCode = resultToken["ColorCode"].ToString(),
                                LabelValue = Convert.ToInt32(resultToken["StatCount"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in SystemEnhancementsDataAccess_GetStatBoxes ! :" + ex);
            }

            // Return the values
            return statisticsBoxDataList;
        }
    }
}
