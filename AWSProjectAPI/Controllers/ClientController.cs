using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Notification;
using AWSProjectAPI.Service.BugFixes;
using AWSProjectAPI.Service.ClientDetails;
using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.Design;

namespace AWSProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : Controller
    {
        #region Private Properties
        private readonly IClientService iClientService;
        #endregion

        // Constructor
        public ClientController(IClientService iClientService)
        {
            this.iClientService = iClientService;
        }

        // Get Display client details
        [HttpPost]
        [Route("GetDisplayClientDetails")]
        public IActionResult GetDisplayClientDetails([FromBody] Filter filter, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetDisplayClientDetails(filter, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Get all the contact list
        [HttpGet]
        [Route("GetAllContactList")]
        public IActionResult GetAllContactList(int clientId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetAllContactList(clientId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the client customer
        [HttpPost]
        [Route("SetClientCustomer")]
        public IActionResult SetClientCustomer([FromBody] ClientCustomer clientCustomer, string staffId, string actionType, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetClientCustomer(clientCustomer, staffId, actionType, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the client customer
        [HttpGet]
        [Route("GetClientCustomer")]
        public IActionResult GetClientCustomer(int clientId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetClientCustomer(clientId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the billing address
        [HttpPost]
        [Route("SetBillingAddress")]
        public IActionResult SetBillingAddress([FromBody] BusinessAddress businessAddress, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetBillingAddress(businessAddress, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the billing address
        [HttpGet]
        [Route("GetBillingAddress")]
        public IActionResult GetBillingAddress(int clientId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetBillingAddress(clientId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the Contact details
        [HttpPost]
        [Route("SetContactDetails")]
        public IActionResult SetContactDetails([FromBody] Contact contact, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetContactDetails(contact, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the Contact list details
        [HttpPost]
        [Route("GetContactListDetails")]
        public IActionResult GetContactListDetails([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetContactListDetails(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the social media details
        [HttpPost]
        [Route("SetSocialMediaDetails")]
        public IActionResult SetSocialMediaDetails([FromBody] SocialMedia socialMedia, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetSocialMediaDetails(socialMedia, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the relationship details
        [HttpPost]
        [Route("SetRelationshipDetails")]
        public IActionResult SetRelationshipDetails([FromBody] RelationshipDetails relationshipDetails, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetRelationshipDetails(relationshipDetails, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the relationship details
        [HttpGet]
        [Route("GetRelationshipDetails")]
        public IActionResult GetRelationshipDetails(int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetRelationshipDetails(customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the other rates details
        [HttpPost]
        [Route("SetOtherRateDetails")]
        public IActionResult SetOtherRateDetails([FromBody] HourlyOtherRates hourlyOtherRates, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetOtherRateDetails(hourlyOtherRates, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the Hourly Other Rate details
        [HttpPost]
        [Route("GetHourlyOtherRateListDetails")]
        public IActionResult GetHourlyOtherRateListDetails([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetHourlyOtherRateListDetails(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the global files
        [HttpPost]
        [Route("GetAllFilesList")]
        public IActionResult GetAllFilesList([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetAllFilesList(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Removing global files
        [HttpGet]
        [Route("RemoveGlobalFile")]
        public IActionResult RemoveGlobalFile(int globalFileId, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.RemoveGlobalFile(globalFileId, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Upload global file
        [HttpPost]
        [Route("UploadGlobalFile")]
        public IActionResult UploadGlobalFile(int customerId, int companyId)
        {
            // Declare form list
            List<IFormFile> files = (List<IFormFile>)Request.Form.Files;

            // Declare response
            var response = this.iClientService.UploadGlobalFile(files, customerId, companyId);

            // Returning the result
            return Json(response);
        }

        // Getting all the resource files
        [HttpGet]
        [Route("GetAllResourceFiles")]
        public IActionResult GetAllResourceFiles(int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetAllResourceFiles(customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting all the resource files
        [HttpPost]
        [Route("GetAllResourceFilesWithPagination")]
        public IActionResult GetAllResourceFilesWithPagination([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetAllResourceFilesWithPagination(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the resource type details
        [HttpPost]
        [Route("SetResourceTypeDetails")]
        public IActionResult SetResourceTypeDetails([FromBody] ResourceType resourceType, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetResourceTypeDetails(resourceType, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the image doc files
        [HttpPost]
        [Route("UploadImageDocFile")]
        public IActionResult UploadImageDocFile(int customerId, int companyId, int resourceTypeId)
        {
            // Declare form list
            List<IFormFile> files = (List<IFormFile>)Request.Form.Files;

            // Declare response
            var response = this.iClientService.UploadImageDocFile(files, customerId, companyId, resourceTypeId);

            // Returning the result
            return Json(response);
        }

        // Updating the image doc files
        [HttpPost]
        [Route("UpdateImageDocFile")]
        public IActionResult UpdateImageDocFile([FromBody]ImageFiles imageFiles, int customerId, int companyId)
        {

            // Declare response
            var response = this.iClientService.SetUpdateImageDocFile(imageFiles, customerId, companyId);

            // Returning the result
            return Json(response);
        }

        // Removing the image doc files
        [HttpGet]
        [Route("RemoveImageDocFile")]
        public IActionResult RemoveImageDocFile(int imageFilesId, int customerId, int companyId)
        {

            // Declare response
            var response = this.iClientService.RemoveImageDocFile(imageFilesId, customerId, companyId);

            // Returning the result
            return Json(response);
        }

        // Getting all the image doc files
        [HttpPost]
        [Route("GetAllImageDocFiles")]
        public IActionResult GetAllImageDocFiles([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetAllImageDocFiles(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the client requirement
        [HttpPost]
        [Route("SetClientRequirement")]
        public IActionResult SetClientRequirement([FromBody] ClientRequirement clientRequirement, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetClientRequirement(clientRequirement, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the client requirement file
        [HttpPost]
        [Route("SetClientRequirementFile")]
        public IActionResult SetClientRequirementFile(int clientRequirementId, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare form list
                List<IFormFile> files = (List<IFormFile>)Request.Form.Files;
                // Declare response
                var response = this.iClientService.SetClientRequirementFile(files, clientRequirementId, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Removing the client requirement file
        [HttpGet]
        [Route("RemoveClientRequirementFile")]
        public IActionResult RemoveClientRequirementFile(int clientRequirementFileId, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.RemoveClientRequirementFile(clientRequirementFileId, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Updating the client requirement ranking
        [HttpGet]
        [Route("UpdateClientRequirementRanking")]
        public IActionResult UpdateClientRequirementRanking(int clientRequirementId, string moveDirection, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.UpdateClientRequirementRanking(clientRequirementId, moveDirection, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Setting the client requirement
        [HttpPost]
        [Route("SetGlobalClientRequirement")]
        public IActionResult SetGlobalClientRequirement([FromBody] ClientRequirement clientRequirement, string actionType, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.SetGlobalClientRequirement(clientRequirement, actionType, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the client requirement
        [HttpPost]
        [Route("GetGlobalClientRequirement")]
        public IActionResult GetGlobalClientRequirement([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetGlobalClientRequirement(filter, customerId, companyId);
                // Returning the result
                return Json(response);
            }
            catch (Exception ex)
            {
                // Returning the exception
                return Json("System Failed: " + ex.Message);
            }
        }

        // Getting the client requirement
        [HttpPost]
        [Route("GetClientRequirement")]
        public IActionResult GetClientRequirement([FromBody] Filter filter, int customerId, int companyId)
        {
            try
            {
                // Declare response
                var response = this.iClientService.GetClientRequirement(filter, customerId, companyId);
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
