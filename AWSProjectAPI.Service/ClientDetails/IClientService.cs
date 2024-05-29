using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.ClientDetails
{
    public interface IClientService
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

        // SetContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string (NEW/UPDATE/REMOVE)
        /// contact -> Contact object
        /// </remarks>
        int SetContactDetails(Contact contact, string actionType, int customerId, int companyId);

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

        // SetSocialMediaDetails
        /// <summary>
        /// Setting the social media details
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// socialMedia -> SocialMedia object
        /// </remarks>
        int SetSocialMediaDetails(SocialMedia socialMedia, string actionType, int customerId, int companyId);

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


        // SetOtherRateDetails
        /// <summary>
        /// Setting the other rates details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// hourlyOtherRates -> HourlyOtherRates object
        /// </remarks>
        int SetOtherRateDetails(HourlyOtherRates hourlyOtherRates, string actionType, int customerId, int companyId);

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

        // UploadGlobalFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// file -> IFormFile
        /// </remarks>
        string UploadGlobalFile(List<IFormFile> files, int customerId, int companyId);

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

        // SetResourceTypeDetails
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType
        /// </remarks>
        int SetResourceTypeDetails(ResourceType resourceType, string actionType, int customerId, int companyId);

        // UploadImageDocFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceTypeId -> number
        /// file -> IFormFile
        /// </remarks>
        string UploadImageDocFile(List<IFormFile> files, int customerId, int companyId, int resourceTypeId);

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

        // SetClientRequirement
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
        int SetClientRequirement(ClientRequirement clientRequirement, string actionType, int customerId, int companyId);

        // SetClientRequirementFile
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
        string SetClientRequirementFile(List<IFormFile> files, int clientRequirementId, string actionType, int customerId, int companyId);

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

        // SetGlobalClientRequirement
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
        int SetGlobalClientRequirement(ClientRequirement clientRequirement, string actionType, int customerId, int companyId);

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
        /// 
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
