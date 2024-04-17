using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWSProjectAPI.Core.BugFixes;

namespace AWSProjectAPI.DataAccess.BugFixes
{
    public class BugFixesDataAccess: IBugFixesDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        #endregion

        // Constructor
        public BugFixesDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            this.AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
        }

        // AddBugFixesDetails
        /// <summary>
        /// Adding Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        public string AddBugFixesDetails(BugFix bugFixes)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter PriorityIdParameter = sqlCommandToken.Parameters.Add("@PriorityId", SqlDbType.Int);
                        PriorityIdParameter.Value = bugFixes.PriorityId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = bugFixes.StatusId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = bugFixes.ModuleId;
                        SqlParameter AddedUserIdParameter = sqlCommandToken.Parameters.Add("@AddedUserId", SqlDbType.VarChar, 5000);
                        AddedUserIdParameter.Value = bugFixes.AddedUserId;
                        SqlParameter EstimatedHoursParameter = sqlCommandToken.Parameters.Add("@EstimatedHours", SqlDbType.Int);
                        EstimatedHoursParameter.Value = bugFixes.EstimatedHours;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar, 1000);
                        TitleParameter.Value = bugFixes.Title;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = bugFixes.Description;
                        SqlParameter StartDateParameter = sqlCommandToken.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        StartDateParameter.Value = bugFixes.StartDate;
                        SqlParameter EndDateParameter = sqlCommandToken.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        EndDateParameter.Value = bugFixes.EndDate;
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
                throw new Exception("Error in BugFixesDataAcces_AddBugFixesDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // UpdateBugFixesDetails
        /// <summary>
        /// Updating Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        public string UpdateBugFixesDetails(BugFix bugFixes)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter PriorityIdParameter = sqlCommandToken.Parameters.Add("@PriorityId", SqlDbType.Int);
                        PriorityIdParameter.Value = bugFixes.PriorityId;
                        SqlParameter StatusIdParameter = sqlCommandToken.Parameters.Add("@StatusId", SqlDbType.Int);
                        StatusIdParameter.Value = bugFixes.StatusId;
                        SqlParameter ModuleIdParameter = sqlCommandToken.Parameters.Add("@ModuleId", SqlDbType.Int);
                        ModuleIdParameter.Value = bugFixes.ModuleId;
                        SqlParameter AddedUserIdParameter = sqlCommandToken.Parameters.Add("@AddedUserId", SqlDbType.VarChar, 5000);
                        AddedUserIdParameter.Value = bugFixes.AddedUserId;
                        SqlParameter EstimatedHoursParameter = sqlCommandToken.Parameters.Add("@EstimatedHours", SqlDbType.Int);
                        EstimatedHoursParameter.Value = bugFixes.EstimatedHours;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar, 1000);
                        TitleParameter.Value = bugFixes.Title;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = bugFixes.Description;
                        SqlParameter StartDateParameter = sqlCommandToken.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        StartDateParameter.Value = bugFixes.StartDate;
                        SqlParameter EndDateParameter = sqlCommandToken.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        EndDateParameter.Value = bugFixes.EndDate;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = bugFixes.Id;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newIdValue = bugFixes.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BugFixesDataAcces_UpdateBugFixesDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // DeleteBugFixesDetails
        /// <summary>
        /// Removing Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        public string DeleteBugFixesDetails(string bugFixesId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = bugFixesId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "DLT";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newIdValue = bugFixesId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BugFixesDataAcces_DeleteBugFixesDetails ! :" + ex);
            }

            // Return the token
            return newIdValue;
        }

        // DeleteBugFixesAssignedStaff
        /// <summary>
        /// Removing Bug Fixes related Assigned staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// </remarks>
        public string DeleteBugFixesAssignedStaff(string bugFixesId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesAssignedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        IdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_DeleteBugFixesAssignedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // DeleteBugFixesRequestedStaff
        /// <summary>
        /// Removing Bug Fixes related requested staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// </remarks>
        public string DeleteBugFixesRequestedStaff(string bugFixesId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesRequestedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        IdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_DeleteBugFixesRequestedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // AddBugFixesAssignedStaff
        /// <summary>
        /// Adding Bug Fixes related Assigned staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// staffId -> string value
        /// </remarks>
        public string AddBugFixesAssignedStaff(string bugFixesId, string staffId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesAssignedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        IdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_AddBugFixesAssignedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // AddBugFixesRequestedStaff
        /// <summary>
        /// Adding Bug Fixes related requested staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// staffId -> string value
        /// </remarks>
        public string AddBugFixesRequestedStaff(string bugFixesId, string staffId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesRequestedStaffs_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        IdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_AddBugFixesRequestedStaff ! :" + ex);
            }

            return newIdValue;
        }

        // GetBugFixesDisplayModules
        /// <summary>
        /// Getting the Bug Fixes modules to display
        /// </summary>
        /// <returns>
        /// DisplayModule object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<DisplayModule> GetBugFixesDisplayModules(Filter filter)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
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
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesDisplayModules ! :" + ex);
            }

            // Return the values
            return displayModules;
        }

        // GetBugFixesDisplayList
        /// <summary>
        /// Getting the Bug Fixes display list
        /// </summary>
        /// <returns>
        /// ViewBugFixes object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        public List<ViewBugFix> GetBugFixesDisplayList(Filter filter)
        {
            // Declare the value list
            List<ViewBugFix> viewBugFixesList = new List<ViewBugFix>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
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
                            viewBugFixesList.Add(new ViewBugFix()
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
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesDisplayList ! :" + ex);
            }

            // Return the values
            return viewBugFixesList;
        }

        // GetBugFixesDetailsById
        /// <summary>
        /// Getting the Bug Fixes details based on the Id
        /// </summary>
        /// <returns>
        /// BugFixes object
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        public BugFix GetBugFixesDetailsById(string BugFixesId)
        {
            // Declare the value list
            BugFix bugFixes = new BugFix();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        IdParameter.Value = BugFixesId;
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "BY$ID";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            bugFixes = new BugFix()
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
                                AssignedStaffList = new List<BasicUserDetails>(),
                                RequestedStaffList = new List<BasicUserDetails>()
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesDetailsById ! :" + ex);
            }

            // Return the values
            return bugFixes;
        }

        // GetBugFixesAssignedStaff
        /// <summary>
        /// Getting the Bug Fixes Assigned staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        public List<BasicUserDetails> GetBugFixesAssignedStaff(string bugFixesId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesAssignedStaffs_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = bugFixesId;
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
                                FullName = resultToken["FirstName"].ToString() +" " + resultToken["LastName"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesAssignedStaff ! :" + ex);
            }

            // Return the values
            return basicUserDetaislList;
        }

        // GetBugFixesRequestedStaff
        /// <summary>
        /// Getting the Bug Fixes requested staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        public List<BasicUserDetails> GetBugFixesRequestedStaff(string bugFixesId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesRequestedStaffs_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesRequestedStaff ! :" + ex);
            }

            // Return the values
            return basicUserDetaislList;
        }

        // UpdateBugFixestatus
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
        public bool UpdateBugFixesStatus(string bugFixesId, int statusId)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = bugFixesId;
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
                throw new Exception("Error in BugFixesDataAcces_UpdateBugFixestatus ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // AddBugFixesChangeDate
        /// <summary>
        /// Adding the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        public string AddBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = bugFixesChangeDate.BugFixesId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = bugFixesChangeDate.UserId;
                        SqlParameter OldFromDateParameter = sqlCommandToken.Parameters.Add("@OldFromDate", SqlDbType.DateTime);
                        OldFromDateParameter.Value = bugFixesChangeDate.OldFromDate;
                        SqlParameter OldToDateParameter = sqlCommandToken.Parameters.Add("@OldToDate", SqlDbType.DateTime);
                        OldToDateParameter.Value = bugFixesChangeDate.OldToDate;
                        SqlParameter OldDurationParameter = sqlCommandToken.Parameters.Add("@OldDuration", SqlDbType.Int);
                        OldDurationParameter.Value = bugFixesChangeDate.OldDuration;
                        SqlParameter NewFromDateParameter = sqlCommandToken.Parameters.Add("@NewFromDate", SqlDbType.DateTime);
                        NewFromDateParameter.Value = bugFixesChangeDate.NewFromDate;
                        SqlParameter NewToDateParameter = sqlCommandToken.Parameters.Add("@NewToDate", SqlDbType.DateTime);
                        NewToDateParameter.Value = bugFixesChangeDate.NewToDate;
                        SqlParameter NewDurationParameter = sqlCommandToken.Parameters.Add("@NewDuration", SqlDbType.Int);
                        NewDurationParameter.Value = bugFixesChangeDate.NewDuration;
                        SqlParameter ReasonParameter = sqlCommandToken.Parameters.Add("@Reason", SqlDbType.VarChar);
                        ReasonParameter.Value = bugFixesChangeDate.Reason;
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
                throw new Exception("Error in BugFixesDataAcces_AddBugFixesChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // UpdateBugFixesChangeDate
        /// <summary>
        /// Upadating the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        public string UpdateBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPDATE";
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = bugFixesChangeDate.Id;
                        SqlParameter ReasonParameter = sqlCommandToken.Parameters.Add("@Reason", SqlDbType.VarChar);
                        ReasonParameter.Value = bugFixesChangeDate.Reason;

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
                throw new Exception("Error in BugFixesDataAcces_UpdateBugFixesChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // DeleteBugFixesChangeDate
        /// <summary>
        /// Removing the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        public string DeleteBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesChangeHistory_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = bugFixesChangeDate.Id;

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
                throw new Exception("Error in BugFixesDataAcces_DeleteBugFixesChangeDate ! :" + ex);
            }

            // Return the values
            return resultStatus;
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
        public List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string BugFixesId)
        {
            // Declare the value list
            List<ViewBugFixChangeDate> viewBugFixesChangeDateList = new List<ViewBugFixChangeDate>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesChangeHistory_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = BugFixesId;
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
                            viewBugFixesChangeDateList.Add(new ViewBugFixChangeDate()
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
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesChangeDate ! :" + ex);
            }

            // Return the values
            return viewBugFixesChangeDateList;
        }

        // AddBugFixesComment
        /// <summary>
        /// Adding Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        public string AddBugFixesComment(BugFixComment bugFixesComment)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = bugFixesComment.BugFixesId;
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = bugFixesComment.UserId;
                        SqlParameter ParentIdParameter = sqlCommandToken.Parameters.Add("@ParentId", SqlDbType.Int);
                        ParentIdParameter.Value = bugFixesComment.ParentId;
                        SqlParameter DescriptionParameter = sqlCommandToken.Parameters.Add("@Description", SqlDbType.VarChar);
                        DescriptionParameter.Value = bugFixesComment.Description;

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
                throw new Exception("Error in BugFixesDataAcces_AddBugFixesComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // UpdateBugFixesComment
        /// <summary>
        /// Update Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        public string UpdateBugFixesComment(BugFixComment bugFixesComment)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = bugFixesComment.Id;

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
                throw new Exception("Error in BugFixesDataAcces_UpdateBugFixesComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
        }

        // DeleteBugFixesComment
        /// <summary>
        /// Removing Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        public string DeleteBugFixesComment(BugFixComment bugFixesComment)
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
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesComments_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = bugFixesComment.Id;

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
                throw new Exception("Error in BugFixesDataAcces_DeleteBugFixesComment ! :" + ex);
            }

            // Return the values
            return resultStatus;
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
        public List<ViewBugFixComment> GetBugFixesComment(Filter filter)
        {
            // Declare the value list
            List<ViewBugFixComment> viewBugFixesCommentList = new List<ViewBugFixComment>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("BugFixesComments_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BugFixesIdParameter = sqlCommandToken.Parameters.Add("@BugFixesId", SqlDbType.VarChar);
                        BugFixesIdParameter.Value = filter.Id;
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
                            viewBugFixesCommentList.Add(new ViewBugFixComment()
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
                throw new Exception("Error in BugFixesDataAcces_GetBugFixesComment ! :" + ex);
            }

            // Return the values
            return viewBugFixesCommentList;
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
                throw new Exception("Error in BugFixesDataAcces_GetStatBoxes ! :" + ex);
            }

            // Return the values
            return statisticsBoxDataList;
        }
    }
}
