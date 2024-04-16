using AWSProjectAPI.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Authentication
{
    public interface IAuthenticationService
    {
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
        string LoginAuthentication(string email, string password);

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
    }
}
