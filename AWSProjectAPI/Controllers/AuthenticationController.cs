using AWSProjectAPI.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        #region Private Properties
        private readonly IAuthenticationService iAuthenticationService;
        #endregion

        // Constructor
        public AuthenticationController(IAuthenticationService iAuthenticationService)
        {
            this.iAuthenticationService = iAuthenticationService;
        }

        // Authenticating the login
        [HttpGet]
        [Route("LoginAuthentication")]
        public IActionResult LoginAuthentication(string email, string password)
        {
            try
            {
                // Declare response
                var response = this.iAuthenticationService.LoginAuthentication(email, password);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Logout user
        [HttpGet]
        [Route("LogoutUser")]
        public IActionResult LogoutUser(string email)
        {
            try
            {
                // Declare response
                var response = this.iAuthenticationService.LogoutUser(email);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the user access level
        [HttpGet]
        [Route("GetUserAccessLevels")]
        public IActionResult GetUserAccessLevels(string userId)
        {
            try
            {
                // Declare response
                var response = this.iAuthenticationService.GetUserAccessLevels(userId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }
    }
}
