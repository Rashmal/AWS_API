using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Common")]
    public class CommonController : Controller
    {
        #region Private Properties
        private readonly ICommonService iCommonService;
        #endregion

        // Constructor
        public CommonController(ICommonService iCommonService)
        {
            this.iCommonService = iCommonService;
        }

        // Check if the email exists
        [HttpGet]
        [Route("CheckEmailExists")]
        public IActionResult CheckEmailExists(string userEmail)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.CheckEmailExists(userEmail);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the priority list
        [HttpGet]
        [Route("GetPriorityList")]
        public IActionResult GetPriorityList()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetPriorityList();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the status list
        [HttpGet]
        [Route("GetStatusList")]
        public IActionResult GetStatusList(string moduleCode)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetStatusList(moduleCode);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the module list
        [HttpGet]
        [Route("GetModuleList")]
        public IActionResult GetModuleList()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetModuleList();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the staff list
        [HttpGet]
        [Route("GetAllStaffList")]
        public IActionResult GetAllStaffList()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllStaffList();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the total of global notes
        [HttpGet]
        [Route("TotalGlobalNotes")]
        public IActionResult TotalGlobalNotes(string tabSection)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.TotalGlobalNotes(tabSection);
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
