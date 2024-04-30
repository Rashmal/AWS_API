using AWSProjectAPI.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.Authentication
{
    public interface IAuthenticationDataAccess
    {
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
        bool LoginAuthentication(string email, string password);

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
        UserDetails GetUserDetailsByEmail(string email);

        // GetUserJWTToken
        /// <summary>
        /// Getting the JWT token for the user
        /// </summary>
        /// <returns>
        /// String value of the token
        /// </returns>
        /// <remarks>
        /// <param name="userID">string value.</param>
        /// </remarks>
        string GetUserJWTToken(string userID);

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
        bool SetUserJWTToken(string jwtToken, string userId);

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
        bool LogoutUser(string email);

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
        List<AccessLevel> GetUserAccessLevels(string userId);

        /// <summary>
        /// Getting the user detailsbased on the id
        /// </summary>
        /// <returns>
        /// UserDetails object
        /// </returns>
        /// <remarks>
        /// email -> string
        /// </remarks>
        UserDetails GetUserDetailsByUserId(string userId);
    }
}
