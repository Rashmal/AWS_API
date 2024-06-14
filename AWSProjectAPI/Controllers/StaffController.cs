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


    }
}
