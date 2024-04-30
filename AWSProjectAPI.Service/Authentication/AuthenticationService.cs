using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.DataAccess.Authentication;
using AWSProjectAPI.DataAccess.Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Properties
        private readonly IAuthenticationDataAccess iAuthenticationDataAccess;
        #endregion

        // Constructor
        public AuthenticationService(IAuthenticationDataAccess iAuthenticationDataAccess)
        {
            this.iAuthenticationDataAccess = iAuthenticationDataAccess;
        }

        // LoginAuthentication
        /// <summary>
        /// Authenticating the login
        /// </summary>
        /// <returns>
        /// String value for token
        /// </returns>
        /// <remarks>
        /// email -> string
        /// password -> string
        /// </remarks>
        public string LoginAuthentication(string email, string password)
        {
            // Declare the token
            string token = "";

            // Getting the login validation
            bool authLogin = iAuthenticationDataAccess.LoginAuthentication(email, password);

            // Check if the login is successfull
            if (authLogin)
            {
                // Declare the user details object
                UserDetails userDetails = new UserDetails();

                // Getting the user details by email
                userDetails = iAuthenticationDataAccess.GetUserDetailsByEmail(email);

                // Getting the token
                token = GenerateJWTToken(userDetails, userDetails.UserId);
            }
            else
            {
                token = "ERROR";
            }
            // End of Check if the login is successfull

            // Return the token
            return token;
        }

        // GenerateJWTToken
        /// <summary>
        /// Getting the JWT token
        /// </summary>
        /// <return>
        /// </return>
        /// <param name="userDetails"> UserDetails object value </param>
        /// <param name="newUserId"> string value </param>
        public string GenerateJWTToken(UserDetails userDetails, string newUserId)
        {
            // Store the initial token
            string initialToken = string.Empty;

            try
            {
                // Creating the secret key
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"));
                // Generating the signed credentials
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

                // Getting the token
                string currentToken = this.iAuthenticationDataAccess.GetUserJWTToken(newUserId);

                // Check if the token exists
                if (currentToken != "")
                {
                    initialToken = currentToken;
                }
                else
                {
                    // Creating the new JWT token
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Aud, initialToken),
                        new Claim(JwtRegisteredClaimNames.Email, (userDetails.Email == null)?"":userDetails.Email),
                        new Claim(JwtRegisteredClaimNames.Acr, (userDetails.FirstName + " "+userDetails.LastName == null)?"": userDetails.FirstName + " "+userDetails.LastName),
                        new Claim(JwtRegisteredClaimNames.NameId, userDetails.UserId),
                        new Claim(JwtRegisteredClaimNames.Amr, userDetails.RoleCode),
                        //new Claim(JwtRegisteredClaimNames.Azp, basicUserDetails.CompanyName),
                        //new Claim(JwtRegisteredClaimNames.Iat, basicUserDetails.CompanyTypeCode),
                        //new Claim(JwtRegisteredClaimNames.Sub, basicUserDetails.UserTypeId.ToString())
                     };
                    var tokeOptions = new JwtSecurityToken(
                               issuer: "https://iitcdemoapi.com/AWSAPI",
                               audience: "https://iitcdemoapi.com/AWSAPI",
                               claims: claims,
                               expires: DateTime.Now.AddMinutes(60),
                               signingCredentials: signinCredentials
                           );
                    initialToken = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    // End of Creating the new JWT token

                    // insert to the db
                    this.iAuthenticationDataAccess.SetUserJWTToken(initialToken, newUserId);
                }
                // End of Check if the token exists

            }
            catch (Exception ex)
            {
                throw new Exception("Error in AuthenticationService_GenerateJWTToken ! :" + ex);
            }

            // Return the token
            return initialToken;
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
        public bool LogoutUser(string email)
        {
            return iAuthenticationDataAccess.LogoutUser(email);
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
            return iAuthenticationDataAccess.GetUserAccessLevels(userId);
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
        public UserDetails GetUserDetailsByUserId(string userId)
        {
            return iAuthenticationDataAccess.GetUserDetailsByUserId(userId);
        }
    }
}
