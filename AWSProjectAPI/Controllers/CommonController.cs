using AWSProjectAPI.Core.Common;
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
        public IActionResult TotalGlobalNotes(string tabSection, string userId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.TotalGlobalNotes(tabSection, userId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the module list based on user role
        [HttpGet]
        [Route("GetModuleListBasedUserRole")]
        public IActionResult GetModuleListBasedUserRole(string userRole, bool isStatic)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetModuleListBasedUserRole(userRole, isStatic);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the access list based on the user role
        [HttpGet]
        [Route("GetAccessListBasedUserRole")]
        public IActionResult GetAccessListBasedUserRole(string userRole)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAccessListBasedUserRole(userRole);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the access list based on the user role for view
        [HttpGet]
        [Route("GetViewAccessListBasedUserRole")]
        public IActionResult GetViewAccessListBasedUserRole(string userRole)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetViewAccessListBasedUserRole(userRole);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the account details
        [HttpPost]
        [Route("GetAccountDetails")]
        public IActionResult GetAccountDetails([FromBody] Filter filter)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAccountDetails(filter);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the business number type details
        [HttpGet]
        [Route("GetAllBusinessNumberTypes")]
        public IActionResult GetAllBusinessNumberTypes()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllBusinessNumberTypes();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the client size details
        [HttpGet]
        [Route("GetAllClientSizes")]
        public IActionResult GetAllClientSizes()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllClientSizes();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the contact type details
        [HttpGet]
        [Route("GetAllContactTypes")]
        public IActionResult GetAllContactTypes()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllContactTypes();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the country details
        [HttpGet]
        [Route("GetAllCountries")]
        public IActionResult GetAllCountries()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllCountries();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the day details
        [HttpGet]
        [Route("GetAllDays")]
        public IActionResult GetAllDays()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllDays();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the price classfication details
        [HttpGet]
        [Route("GetAllPriceClassifications")]
        public IActionResult GetAllPriceClassifications()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllPriceClassifications();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the rating details
        [HttpGet]
        [Route("GetAllRatings")]
        public IActionResult GetAllRatings()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllRatings();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the social media type details
        [HttpGet]
        [Route("GetAllSocialMediaTypes")]
        public IActionResult GetAllSocialMediaTypes()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllSocialMediaTypes();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the term type details
        [HttpGet]
        [Route("GetAllTermTypes")]
        public IActionResult GetAllTermTypes()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllTermTypes();
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the role details
        [HttpGet]
        [Route("GetAllRoleDetails")]
        public IActionResult GetAllRoleDetails()
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllRoleDetails();
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
