using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.Notification;
using AWSProjectAPI.Service.BugFixes;
using AWSProjectAPI.Service.Common;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/BugFixes")]
    public class BugFixesController : Controller
    {
        #region Private Properties
        private readonly IBugFixesService iBugFixesService;
        private readonly ICommonService commonService;
        private IHubContext<NotificationHub, INotificationClient> hubContext;
        #endregion

        // Constructor
        public BugFixesController(IBugFixesService iBugFixesService, IHubContext<NotificationHub, INotificationClient> hubContext, ICommonService commonService)
        {
            this.iBugFixesService = iBugFixesService;
            this.hubContext = hubContext;
            this.commonService = commonService;
        }

        // Set System Enhancement Details
        [HttpPost]
        [Route("SetBugFixesDetails")]
        public IActionResult SetBugFixesDetails([FromBody] BugFix bugFixes, string actionState, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.SetBugFixesDetails(bugFixes, actionState, companyId);
                // Set notification count
                hubContext.Clients.All.NotificationCountGN(commonService.TotalGlobalNotes("TOTAL", userId, companyId));
                hubContext.Clients.All.NotificationCountBF(commonService.TotalGlobalNotes("BGF", userId, companyId));
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
        [Route("GetBugFixesDisplayModules")]
        public IActionResult GetBugFixesDisplayModules([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.GetBugFixesDisplayModules(filter, companyId);
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
        [Route("GetBugFixesDisplayList")]
        public IActionResult GetBugFixesDisplayList([FromBody] Filter filter, string UserId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.GetBugFixesDisplayList(filter, UserId, companyId);
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
        [Route("GetBugFixesDetailsById")]
        public IActionResult GetBugFixesDetailsById(string bugFixesId, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.GetBugFixesDetailsById(bugFixesId, userId, companyId);
                // Set notification count
                hubContext.Clients.All.NotificationCountGN(commonService.TotalGlobalNotes("TOTAL", userId, companyId));
                hubContext.Clients.All.NotificationCountBF(commonService.TotalGlobalNotes("BGF", userId, companyId));
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
        [Route("UpdateBugFixesStatus")]
        public IActionResult UpdateBugFixesStatus(string bugFixesId, int statusId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.UpdateBugFixesStatus(bugFixesId, statusId, companyId);
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
        [Route("SetBugFixesChangeDate")]
        public IActionResult SetBugFixesChangeDate([FromBody] BugFixChangeDate bugFixesChangeDate, string actionState, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.SetBugFixesChangeDate(bugFixesChangeDate, actionState, companyId);
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
        [Route("GetBugFixesChangeDate")]
        public IActionResult GetBugFixesChangeDate([FromBody] Filter filter, string bugFixesId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.GetBugFixesChangeDate(filter, bugFixesId, companyId);
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
        [Route("SetBugFixesComment")]
        public IActionResult SetBugFixesComment([FromBody] BugFixComment bugFixComment, string actionState, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.SetBugFixesComment(bugFixComment, actionState, companyId);
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
        [Route("GetBugFixesComment")]
        public IActionResult GetBugFixesComment([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.GetBugFixesComment(filter, companyId);
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
                var response = this.iBugFixesService.GetStatBoxes(companyId);
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
        public IActionResult ApprovalChangeDate(int BugFixChangeHistoryId, string approval, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.ApprovalChangeDate(BugFixChangeHistoryId, approval, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Adding the view Id for the bug fixes
        [HttpGet]
        [Route("AddViewId")]
        public IActionResult AddViewId(string itemId, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iBugFixesService.AddViewId(itemId, userId, companyId);
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

