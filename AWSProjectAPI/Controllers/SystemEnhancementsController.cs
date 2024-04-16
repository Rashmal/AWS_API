using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.Service.Common;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Mvc;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SystemEnhancement")]
    public class SystemEnhancementsController : Controller
    {
        #region Private Properties
        private readonly ISystemEnhancementsService iSystemEnhancementsService;
        #endregion

        // Constructor
        public SystemEnhancementsController(ISystemEnhancementsService iSystemEnhancementsService)
        {
            this.iSystemEnhancementsService = iSystemEnhancementsService;
        }

        // Set System Enhancement Details
        [HttpPost]
        [Route("SetSystemEnhancementDetails")]
        public IActionResult SetSystemEnhancementDetails([FromBody] SystemEnhancement systemEnhancement, string actionState)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEnhancementDetails(systemEnhancement, actionState);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the system enhancements modules to display
        [HttpPost]
        [Route("GetSystemEnhancementDisplayModules")]
        public IActionResult GetSystemEnhancementDisplayModules([FromBody] Filter filter)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDisplayModules(filter);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the system enhancements display list
        [HttpPost]
        [Route("GetSystemEnhancementDisplayList")]
        public IActionResult GetSystemEnhancementDisplayList([FromBody] Filter filter)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDisplayList(filter);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the system enhancements details based on the Id
        [HttpGet]
        [Route("GetSystemEnhancementDetailsById")]
        public IActionResult GetSystemEnhancementDetailsById(string systemEnhancementId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDetailsById(systemEnhancementId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Updating the status of the system enhancement
        [HttpGet]
        [Route("UpdateSystemEnhancementStatus")]
        public IActionResult UpdateSystemEnhancementStatus(string systemEnhancementId, int statusId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.UpdateSystemEnhancementStatus(systemEnhancementId, statusId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Set System Enhancement Change date history
        [HttpPost]
        [Route("SetSystemEhancementChangeDate")]
        public IActionResult SetSystemEhancementChangeDate([FromBody] SystemEnhancementChangeDate systemEnhancementChangeDate, string actionState)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEhancementChangeDate(systemEnhancementChangeDate, actionState);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Get System Enhancement Change date history
        [HttpPost]
        [Route("GetSystemEhancementChangeDate")]
        public IActionResult GetSystemEhancementChangeDate([FromBody] Filter filter, string systemEnhancementId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEhancementChangeDate(filter, systemEnhancementId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Set System Enhancement Comment
        [HttpPost]
        [Route("SetSystemEhancementComment")]
        public IActionResult SetSystemEhancementComment([FromBody] SystemEnhancementComment systemEnhancementComment, string actionState)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEhancementComment(systemEnhancementComment, actionState);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Get System Enhancement Comment
        [HttpPost]
        [Route("GetSystemEhancementComment")]
        public IActionResult GetSystemEhancementComment([FromBody] Filter filter)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEhancementComment(filter);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the stat boxes
        [HttpGet]
        [Route("GetStatBoxes")]
        public IActionResult GetStatBoxes()
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetStatBoxes();
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
