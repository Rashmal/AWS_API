using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.ClientDetails
{
    public interface IClientDataAccess
    {
        // GetDisplayClientDetails
        /// <summary>
        /// Get Display client details
        /// </summary>
        /// <returns>
        /// DisplayClientDetails object list value of the Id
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// companyId -> number
        /// </remarks>
        List<DisplayClientDetails> GetDisplayClientDetails(Filter filter, int companyId);

        // GetAllContactList
        /// <summary>
        /// Get all the contact list
        /// </summary>
        /// <returns>
        /// Contact object list value of the Id
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        List<Contact> GetAllContactList(Filter filter, int clientId, int companyId);

        // SetClientCustomer
        /// <summary>
        /// Setting the client customer
        /// </summary>
        /// <returns>
        /// int new Id
        /// </returns>
        /// <remarks>
        /// clientCustomer -> ClientCustomer object
        /// companyId -> number
        /// </remarks>
        int SetClientCustomer(ClientCustomer clientCustomer, string staffId, string actionType, int companyId);

         // GetClientCustomer
        /// <summary>
        /// Getting the client customer
        /// </summary>
        /// <returns>
        /// ClientCustomer object
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        ClientCustomer GetClientCustomer(int clientId, int companyId);

        // SetBillingAddress
        /// <summary>
        /// Setting the billing address
        /// </summary>
        /// <returns>
        /// int new Id
        /// </returns>
        /// <remarks>
        /// businessAddress -> BusinessAddress object
        /// actionType -> string
        /// companyId -> number
        /// </remarks>
        int SetBillingAddress(BusinessAddress businessAddress, string actionType, int customerId, int companyId);

        // GetBillingAddress
        /// <summary>
        /// Getting the billing address
        /// </summary>
        /// <returns>
        /// BusinessAddress object
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        BusinessAddress GetBillingAddress(int clientId, int companyId);

        // SetNewContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        int SetNewContactDetails(Contact contact, int customerId, int companyId);

        // SetUpdateContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        int SetUpdateContactDetails(Contact contact, int customerId, int companyId);

        // SetRemoveContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contactId -> number
        /// </remarks>
        int SetRemoveContactDetails(int contactId, int customerId, int companyId);

        // GetContactListDetails
        /// <summary>
        /// Getting the Contact list details
        /// </summary>
        /// <returns>
        /// Contact list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        List<Contact> GetContactListDetails(Filter filter, int customerId, int companyId);

        // SetNewSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        int SetNewSocialMediaDetails(SocialMedia socialMedia, int customerId, int companyId);

        // SetUpdateSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        int SetUpdateSocialMediaDetails(SocialMedia socialMedia, int customerId, int companyId);

        // SetRemoveSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        int SetRemoveSocialMediaDetails(int sociamMediaId, int customerId, int companyId);

        // GetSocialMediaListDetails
        /// <summary>
        /// Getting the Social media list details
        /// </summary>
        /// <returns>
        /// SocialMedia list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        List<SocialMedia> GetSocialMediaListDetails(Filter filter, int customerId, int companyId);

        // SetRelationshipDetails
        /// <summary>
        /// Setting the relationship details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// relationshipDetails -> RelationshipDetails object
        /// </remarks>
        int SetRelationshipDetails(RelationshipDetails relationshipDetails, string actionType, int customerId, int companyId);

        // GetRelationshipDetails
        /// <summary>
        /// Getting the relationship details
        /// </summary>
        /// <returns>
        /// RelationshipDetails value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        RelationshipDetails GetRelationshipDetails(int customerId, int companyId);

        // SetNewHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// hourlyOtherRates -> HourlyOtherRates object
        /// </remarks>
        int SetNewHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, int companyId);

        // SetUpdateHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// hourlyOtherRates -> HourlyOtherRates object
        /// </remarks>
        int SetUpdateHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, int companyId);

        // SetRemoveHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        int SetRemoveHourlyOtherRatesDetails(int hourlyOtherRatesId, int customerId, int companyId);

        // GetHourlyOtherRateListDetails
        /// <summary>
        /// Getting the Social media list details
        /// </summary>
        /// <returns>
        /// SocialMedia list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        List<HourlyOtherRates> GetHourlyOtherRateListDetails(Filter filter, int customerId, int companyId);

        // GetAllFilesList
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        List<GlobalFileDetails> GetAllFilesList(Filter filter, int customerId, int companyId);

        // RemoveGlobalFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// globalFileId -> number
        /// </remarks>
        int RemoveGlobalFile(int globalFileId, int customerId, int companyId);

        // SetGlobalFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// fileName -> string
        /// fileUrl -> string
        /// fileType -> string
        /// companyId -> number
        /// </remarks>
        int SetGlobalFile(string fileName, string fileUrl, string fileType, int companyId);

        // GetAllResourceFiles
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        List<ResourceType> GetAllResourceFiles(int customerId, int companyId);

        // GetAllResourceFilesWithPagination
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        List<ResourceType> GetAllResourceFilesWithPagination(Filter filter, int customerId, int companyId);

        // SetNewResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        int SetNewResourceDetails(ResourceType resourceType, int customerId, int companyId);

        // SetUpdateResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        int SetUpdateResourceDetails(ResourceType resourceType, int customerId, int companyId);

        // SetRemoveResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        int SetRemoveResourceDetails(int resourceId, int customerId, int companyId);

        // SetImageDocFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        int SetImageDocFile(ImageFiles imageFiles, int customerId, int companyId);

        // SetUpdateImageDocFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        int SetUpdateImageDocFile(ImageFiles imageFiles, int customerId, int companyId);

        // RemoveImageDocFile
        /// <summary>
        /// Removing the file
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        int RemoveImageDocFile(int imageFilesId, int customerId, int companyId);

        // GetAllImageDocFiles
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter
        /// </remarks>
        List<ImageFiles> GetAllImageDocFiles(Filter filter, int customerId, int companyId);

        // SetNewClientRequirement
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        int SetNewClientRequirement(ClientRequirement clientRequirement, int customerId, int companyId);

        // SetUpdateClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        int SetUpdateClientRequirement(ClientRequirement clientRequirement, int customerId, int companyId);

        // SetRemoveClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        int SetRemoveClientRequirement(int clientRequirementId, int customerId, int companyId);

        // SetClientRequirementFile
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        int SetClientRequirementFile(string fileName, string fileUrl, string fileType, int clientRequirementId, int companyId);

        // RemoveClientRequirementFile
        /// <summary>
        /// Removing the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int RemoveClientRequirementFile(int clientRequirementFileId, int customerId, int companyId);

        // UpdateClientRequirementRanking
        /// <summary>
        /// Updating the client requirement ranking
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int UpdateClientRequirementRanking(int clientRequirementId, string moveDirection, int customerId, int companyId);

        // SetNewGlobalClientRequirement
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        int SetNewGlobalClientRequirement(ClientRequirement clientRequirement, int customerId, int companyId);

        // SetRemoveGlobalClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        int SetRemoveGlobalClientRequirement(int clientRequirementId, int customerId, int companyId);

        // GetGlobalClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        List<ClientRequirement> GetGlobalClientRequirement(Filter filter, int customerId, int companyId);

        // GetClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        List<ClientRequirement> GetClientRequirement(Filter filter, int customerId, int companyId);

        // GetClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        List<ClientRequirementFile> GetClientRequirementFiles(int clientRequirementId, int companyId);

        // SetClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int SetClientRequirementRole(int roleId, int clientRequirementId, int customerId, int companyId);

        // RemoveClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int RemoveClientRequirementRole(int clientRequirementId, int customerId, int companyId);

        // SetGlobalClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int SetGlobalClientRequirementRole(int roleId, int clientRequirementId, int customerId, int companyId);

        // RemoveGlobalClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        int RemoveGlobalClientRequirementRole(int clientRequirementId, int customerId, int companyId);

        // GetClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// RoleDetails List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        List<RoleDetails> GetClientRequirementRole(int clientRequirementId, int customerId, int companyId);

        // GetGlobalClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// RoleDetails List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        List<RoleDetails> GetGlobalClientRequirementRole(int clientRequirementId, int customerId, int companyId);

        // GetAllSocialMediaList
        /// <summary>
        /// Get all the contact list
        /// </summary>
        /// <returns>
        /// SocialMedia object list
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        List<SocialMedia> GetAllSocialMediaList(Filter filter, int clientId, int companyId);

    }
}
