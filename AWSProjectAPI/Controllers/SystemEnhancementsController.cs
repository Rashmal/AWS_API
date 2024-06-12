using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.Notification;
using AWSProjectAPI.Service.Common;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SystemEnhancement")]
    public class SystemEnhancementsController : Controller
    {
        #region Private Properties
        private readonly ISystemEnhancementsService iSystemEnhancementsService;
        private readonly ICommonService commonService;
        private IHubContext<NotificationHub, INotificationClient> hubContext;
        #endregion

        // Constructor
        public SystemEnhancementsController(ISystemEnhancementsService iSystemEnhancementsService, IHubContext<NotificationHub, INotificationClient> hubContext, ICommonService commonService)
        {
            this.iSystemEnhancementsService = iSystemEnhancementsService;
            this.hubContext = hubContext;
            this.commonService = commonService;
        }

        // Set System Enhancement Details
        [HttpPost]
        [Route("SetSystemEnhancementDetails")]
        public IActionResult SetSystemEnhancementDetails([FromBody] SystemEnhancement systemEnhancement, string actionState, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEnhancementDetails(systemEnhancement, actionState, companyId);
                // Set notification count
                hubContext.Clients.All.NotificationCountGN(commonService.TotalGlobalNotes("TOTAL", userId, companyId));
                hubContext.Clients.All.NotificationCountSE(commonService.TotalGlobalNotes("SE", userId, companyId));
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
        public IActionResult GetSystemEnhancementDisplayModules([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDisplayModules(filter, companyId);
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
        public IActionResult GetSystemEnhancementDisplayList([FromBody] Filter filter, string UserId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDisplayList(filter, UserId, companyId);
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
        public IActionResult GetSystemEnhancementDetailsById(string systemEnhancementId, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEnhancementDetailsById(systemEnhancementId, userId, companyId);
                // Set notification count
                hubContext.Clients.All.NotificationCountGN(commonService.TotalGlobalNotes("TOTAL", userId, companyId));
                hubContext.Clients.All.NotificationCountSE(commonService.TotalGlobalNotes("SE", userId, companyId));
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
        public IActionResult UpdateSystemEnhancementStatus(string systemEnhancementId, int statusId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.UpdateSystemEnhancementStatus(systemEnhancementId, statusId, companyId);
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
        public IActionResult SetSystemEhancementChangeDate([FromBody] SystemEnhancementChangeDate systemEnhancementChangeDate, string actionState, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEhancementChangeDate(systemEnhancementChangeDate, actionState, companyId);
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
        public IActionResult GetSystemEhancementChangeDate([FromBody] Filter filter, string systemEnhancementId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEhancementChangeDate(filter, systemEnhancementId, companyId);
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
        public IActionResult SetSystemEhancementComment([FromBody] SystemEnhancementComment systemEnhancementComment, string actionState, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.SetSystemEhancementComment(systemEnhancementComment, actionState, companyId);
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
        public IActionResult GetSystemEhancementComment([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetSystemEhancementComment(filter, companyId);
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
        public IActionResult GetStatBoxes(int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.GetStatBoxes(companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Approval of change date history
        [HttpGet]
        [Route("ApprovalChangeDate")]
        public IActionResult ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.ApprovalChangeDate(SystemEnhancementsChangeHistoryId, approval, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Adding the view Id for the system enhancement
        [HttpGet]
        [Route("AddViewId")]
        public IActionResult AddViewId(string itemId, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iSystemEnhancementsService.AddViewId(itemId, userId, companyId);
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
