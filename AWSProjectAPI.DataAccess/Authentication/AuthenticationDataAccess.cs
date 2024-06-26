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

namespace AWSProjectAPI.DataAccess.Authentication
{
    public class AuthenticationDataAccess : IAuthenticationDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        protected string AWS_ACCOUNT_DBConnectionString { get; set; }
        #endregion

        // Constructor
        public AuthenticationDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            this.AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
            this.AWS_ACCOUNT_DBConnectionString = configurationString.GetConnectionString("AWS_ACCOUNT_DBString");
        }

        // LoginAuthentication
        /// <summary>
        /// Authenticating the login
        /// </summary>
        /// <returns>
        /// boolean value for validation
        /// </returns>
        /// <remarks>
        /// email -> string
        /// password -> string
        /// </remarks>
        public bool LoginAuthentication(string email, string password, ConnectionString connectionString)
        {
            // Declare the token
            bool status = false;

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
                        SqlParameter EmailParameter = sqlCommandToken.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = email;
                        SqlParameter PasswordParameter = sqlCommandToken.Parameters.Add("@Password", SqlDbType.VarChar, 500);
                        PasswordParameter.Value = password;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "VLD$LGN";

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
                throw new Exception("Error in AuthenticationDataAccess_LoginAuthentication ! :" + ex);
            }

            // Return the token
            return status;
        }

        // GetUserDetailsByEmail
        /// <summary>
        /// Getting the user detailsbased on the email
        /// </summary>
        /// <returns>
        /// UserDetails object
        /// </returns>
        /// <remarks>
        /// email -> string
        /// </remarks>
        public UserDetails GetUserDetailsByEmail(string email, ConnectionString connectionString = null)
        {
            // Declare return value
            UserDetails userDetails = new UserDetails();

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
                        SqlParameter EmailParameter = sqlCommandToken.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = email;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$US$BE";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            userDetails = new UserDetails()
                            {
                                UserId = resultToken["Id"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                Email = resultToken["Email"].ToString(),
                                Avatar = resultToken["Avatar"].ToString(),
                                Password = resultToken["Password"].ToString(),
                                RoleName = resultToken["RoleName"].ToString(),
                                RoleCode = resultToken["RoleCode"].ToString()
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AuthenticationDataAccess_GetUserDetailsByEmail ! :" + ex);
            }

            // Return the value
            return userDetails;
        }

        // GetUserJWTToken
        /// <summary>
        /// Getting the JWT token for the user
        /// </summary>
        /// <returns>
        /// String value of the token
        /// </returns>
        /// <remarks>
        /// <param name="basicUserDetails">A type of  BasicUserDetails.</param>
        /// </remarks>
        public string GetUserJWTToken(string userID, ConnectionString connectionString = null)
        {
            // Declare the token
            string token = "";

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("JWTToken_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar, 1000);
                        UserIdParameter.Value = userID;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "EXSITS";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            token = resultToken["Token"].ToString();
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AuthenticationDataAccess_GetUserJWTToken ! :" + ex);
            }

            // Return the token
            return token;
        }

        // SetUserJWTToken
        /// <summary>
        /// Setting the JWT token for the user
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// <param name="jwtToken">string value.</param>
        /// <param name="userId">string value.</param>
        /// </remarks>
        public bool SetUserJWTToken(string jwtToken, string userId, ConnectionString connectionString = null)
        {
            // Declare the token
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("JWTToken_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "NEW$JWT";
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar, 1000);
                        UserIdParameter.Value = userId;
                        SqlParameter UserJWTTokenParameter = sqlCommandToken.Parameters.Add("@JWTToken", SqlDbType.VarChar);
                        UserJWTTokenParameter.Value = jwtToken;


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
                status = false;
                throw new Exception("Error in AuthenticationDataAccess_SetUserJWTToken ! :" + ex);
            }

            // Return the token
            return status;
        }

        // LogoutUser
        /// <summary>
        /// Logout the user
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        /// <remarks>
        /// email -> string value
        /// </remarks>
        public bool LogoutUser(string email, ConnectionString connectionString = null)
        {
            // Declare the token
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("JWTToken_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "REMOVE";
                        SqlParameter UserEmailParameter = sqlCommandToken.Parameters.Add("@UserEmail", SqlDbType.VarChar, 500);
                        UserEmailParameter.Value = email;


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
                status = false;
                throw new Exception("Error in AuthenticationDataAccess_LogoutUser ! :" + ex);
            }

            // Return the token
            return status;
        }

        // GetUserAccessLevels
        /// <summary>
        /// Getting the user access level
        /// </summary>
        /// <returns>
        /// AccessLevel object list
        /// </returns>
        /// <remarks>
        /// userId -> string value
        /// </remarks>
        public List<AccessLevel> GetUserAccessLevels(string userId)
        {
            // Declare the return value
            List<AccessLevel> accessLevels = new List<AccessLevel>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(this.AWSDBConnectionString))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("UserAccessLevels_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar, 1000);
                        UserIdParameter.Value = userId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$UAL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            accessLevels.Add(new AccessLevel()
                            {
                                AccessLevels = resultToken["AccessLevel"].ToString(),
                                ModuleCode = resultToken["ModuleCode"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AuthenticationDataAccess_GetUserAccessLevels ! :" + ex);
            }

            // Return the value
            return accessLevels;
        }

        /// <summary>
        /// Getting the user detailsbased on the id
        /// </summary>
        /// <returns>
        /// UserDetails object
        /// </returns>
        /// <remarks>
        /// email -> string
        /// </remarks>
        public UserDetails GetUserDetailsByUserId(string userId, ConnectionString connectionString)
        {
            // Declare return value
            UserDetails userDetails = new UserDetails();

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
                        SqlParameter UserIdParameter = sqlCommandToken.Parameters.Add("@UserId", SqlDbType.VarChar);
                        UserIdParameter.Value = userId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$US$BID";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            userDetails = new UserDetails()
                            {
                                UserId = resultToken["Id"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                LastName = resultToken["LastName"].ToString(),
                                Email = resultToken["Email"].ToString(),
                                Avatar = resultToken["Avatar"].ToString(),
                                Password = resultToken["Password"].ToString(),
                                RoleName = resultToken["RoleName"].ToString(),
                                RoleCode = resultToken["RoleCode"].ToString()
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AuthenticationDataAccess_GetUserDetailsByUserId ! :" + ex);
            }

            // Return the value
            return userDetails;
        }
    }
}
