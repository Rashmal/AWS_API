﻿using AWSProjectAPI.Core.Common;
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
        public IActionResult GetPriorityList(int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetPriorityList(companyId);
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
        public IActionResult GetStatusList(string moduleCode, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetStatusList(moduleCode, companyId);
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
        public IActionResult GetModuleList(int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetModuleList(companyId);
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
        public IActionResult GetAllStaffList(int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllStaffList(companyId);
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
        public IActionResult TotalGlobalNotes(string tabSection, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.TotalGlobalNotes(tabSection, userId, companyId);
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
        public IActionResult GetModuleListBasedUserRole(string userRole, bool isStatic, int companyId, string userId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetModuleListBasedUserRole(userRole, isStatic, companyId, userId);
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
        public IActionResult GetAccessListBasedUserRole(string userRole, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAccessListBasedUserRole(userRole, companyId);
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
        public IActionResult GetViewAccessListBasedUserRole(string userRole, string userId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetViewAccessListBasedUserRole(userRole, companyId, userId);
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

        // Getting the file blob data
        [HttpGet]
        [Route("GetFileBlobData")]
        public IActionResult GetFileBlobData(string fileUrl, string fileName)
        {
            try
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(fileUrl, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;

                return File(memory, GetContentType(fileUrl), fileName);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        private string GetContentType(string path)
        {
            var types = new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };

            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types.ContainsKey(ext) ? types[ext] : "application/octet-stream";
        }

        // Getting all the parent groups by email
        [HttpGet]
        [Route("GetAllParentGroupsDetailsByEmail")]
        public IActionResult GetAllParentGroupsDetailsByEmail(string email)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllParentGroupsDetailsByEmail(email);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the parent groups by id
        [HttpGet]
        [Route("GetAllParentGroupsDetailsById")]
        public IActionResult GetAllParentGroupsDetailsById(string userId)
        {
            try
            {
                // Declare response
                var response = this.iCommonService.GetAllParentGroupsDetailsById(userId);
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
