using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Service.ClientDetails;
using AWSProjectAPI.Service.Staff;
using Microsoft.AspNetCore.Mvc;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Staff")]
    public class StaffController : Controller
    {
        #region Private Properties
        private readonly IStaffService iStaffService;
        #endregion

        // Constructor
        public StaffController(IStaffService iStaffService)
        {
            this.iStaffService = iStaffService;
        }

        // Getting all the user roles
        [HttpGet]
        [Route("GetAllUserRoles")]
        public IActionResult GetAllUserRoles(int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetAllUserRoles(companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting all the user roles
        [HttpPost]
        [Route("SetUserRoles")]
        public IActionResult SetUserRoles([FromBody] UserRole userRole, int companyId, string actionType)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.SetUserRoles(userRole, companyId, actionType);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the modules based on user role
        [HttpGet]
        [Route("GetAllModulesbasedUserRole")]
        public IActionResult GetAllModulesbasedUserRole(int userRoleId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetAllModulesbasedUserRole(userRoleId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the module access
        [HttpGet]
        [Route("SetModuleAccess")]
        public IActionResult SetModuleAccess(int moduleId, bool moduleAccess, int userRoleId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.SetModuleAccess(moduleId, moduleAccess, userRoleId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the accessible modules
        [HttpGet]
        [Route("GetAccessibleModules")]
        public IActionResult GetAccessibleModules(int userRoleId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetAccessibleModules(userRoleId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the tab details based on
        [HttpPost]
        [Route("GetTabDetailaBasedOnModuleUserRole")]
        public IActionResult GetTabDetailaBasedOnModuleUserRole([FromBody] Filter filter, int userRoleId, int moduleId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetTabDetailaBasedOnModuleUserRole(filter, userRoleId, moduleId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting all the tab access level
        [HttpGet]
        [Route("SetTabDetailaAccessLevelBasedOnModuleUserRole")]
        public IActionResult SetTabDetailaAccessLevelBasedOnModuleUserRole(int subTabId, bool accessLevel, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.SetTabDetailaAccessLevelBasedOnModuleUserRole(subTabId, accessLevel, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the sub tab feature access level
        [HttpGet]
        [Route("SetSubTabFeatureAccessLevel")]
        public IActionResult SetSubTabFeatureAccessLevel(int subTabFeatureId, bool addAccessLevel, bool editAccessLevel, bool deleteAccessLevel, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.SetSubTabFeatureAccessLevel(subTabFeatureId, addAccessLevel, editAccessLevel, deleteAccessLevel, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the basic information of the user
        [HttpPost]
        [Route("SetStaffDetails")]
        public IActionResult SetStaffDetails([FromBody] StaffDetails staffDetails, int companyId, string loggedUserId, string actionType)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.SetStaffDetails(staffDetails, companyId, loggedUserId, actionType);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the staff password details
        [HttpGet]
        [Route("UpdateStaffPassword")]
        public IActionResult UpdateStaffPassword(string newPassword, string staffId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.UpdateStaffPassword(newPassword, staffId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Updating the staff avatar
        [HttpPost]
        [Route("UploadStaffAvatar")]
        public IActionResult UploadStaffAvatar(string staffId, int companyId)
        {
            // Declare form list
            List<IFormFile> files = (List<IFormFile>)Request.Form.Files;

            // Declare response
            var response = this.iStaffService.UploadStaffAvatar(files, staffId, companyId);

            // Returning the result
            return Json(response);
        }

        // Getting the staff password
        [HttpGet]
        [Route("GetStaffPassword")]
        public IActionResult GetStaffPassword(string staffId, int companyId)
        {
            // Declare response
            var response = this.iStaffService.GetStaffPassword(staffId, companyId);

            // Returning the result
            return Json(response);
        }

        // Get Display staff details
        [HttpPost]
        [Route("GetDisplayStaffDetails")]
        public IActionResult GetDisplayStaffDetails([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetDisplayStaffDetails(filter, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the basic information of the user
        [HttpGet]
        [Route("GetStaffDetails")]
        public IActionResult GetStaffDetails(string staffId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iStaffService.GetStaffDetails(staffId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the staff avatar
        [HttpGet]
        [Route("GetStaffAvatar")]
        public IActionResult GetStaffAvatar(string staffId, int companyId)
        {
            // Declare response
            var response = this.iStaffService.GetStaffAvatar(staffId, companyId);

            // Returning the result
            return Json(response);
        }

        // Remove the staff avatar
        [HttpGet]
        [Route("RemoveStaffAvatar")]
        public IActionResult RemoveStaffAvatar(string staffId, int companyId)
        {
            // Declare response
            var response = this.iStaffService.RemoveStaffAvatar(staffId, companyId);

            // Returning the result
            return Json(response);
        }

    }
}
