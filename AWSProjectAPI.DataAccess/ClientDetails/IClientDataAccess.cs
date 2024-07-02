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
        List<DisplayClientDetails> GetDisplayClientDetails(Filter filter, ConnectionString connectionString);

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
        //List<Contact> GetAllContactList(Filter filter, int clientId, ConnectionString connectionString);

        List<Contact> GetAllContactListNew(Filter filter, int clientId, ConnectionString connectionString);
        List<ContactDetails> GetAllContactDetailsListNew(Filter filter, int contactId, ConnectionString connectionString);


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
        int SetClientCustomer(ClientCustomer clientCustomer, string staffId, string actionType, ConnectionString connectionString);

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
        ClientCustomer GetClientCustomer(int clientId, ConnectionString connectionString);

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
        int SetBillingAddress(BusinessAddress businessAddress, string actionType, int customerId, ConnectionString connectionString);

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
        BusinessAddress GetBillingAddress(int clientId, ConnectionString connectionString);

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
        int SetNewContact(Contact contact, int customerId, ConnectionString connectionString);
        int SetNewContactDetails(ContactDetails contact, int customerId, ConnectionString connectionString);
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
        int SetUpdateContact(Contact contact, int customerId, ConnectionString connectionString);
        int SetUpdateContactDetails(ContactDetails contact, int customerId, ConnectionString connectionString);
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
        int SetRemoveContact(int contactId, int customerId, ConnectionString connectionString);
        int SetRemoveContactDetails(int contactId, int customerId, ConnectionString connectionString);
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
        //List<Contact> GetContactListDetails(Filter filter, int customerId, ConnectionString connectionString);
        List<Contact> GetContactListDetailsNew(Filter filter, int customerId, ConnectionString connectionString);

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
        int SetNewSocialMediaDetails(SocialMedia socialMedia, int customerId, ConnectionString connectionString);

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
        int SetUpdateSocialMediaDetails(SocialMedia socialMedia, int customerId, ConnectionString connectionString);

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
        int SetRemoveSocialMediaDetails(int sociamMediaId, int customerId, ConnectionString connectionString);

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
        List<SocialMedia> GetSocialMediaListDetails(Filter filter, int customerId, ConnectionString connectionString);

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
        int SetRelationshipDetails(RelationshipDetails relationshipDetails, string actionType, int customerId, ConnectionString connectionString);

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
        RelationshipDetails GetRelationshipDetails(int customerId, ConnectionString connectionString);

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
        int SetNewHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, ConnectionString connectionString);

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
        int SetUpdateHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, ConnectionString connectionString);

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
        int SetRemoveHourlyOtherRatesDetails(int hourlyOtherRatesId, int customerId, ConnectionString connectionString);

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
        List<HourlyOtherRates> GetHourlyOtherRateListDetails(Filter filter, int customerId, ConnectionString connectionString);

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
        List<GlobalFileDetails> GetAllFilesList(Filter filter, int customerId, ConnectionString connectionString);

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
        int RemoveGlobalFile(int globalFileId, int customerId, ConnectionString connectionString);

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
        int SetGlobalFile(string fileName, string fileUrl, string fileType, ConnectionString connectionString, string localPath);

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
        List<ResourceType> GetAllResourceFiles(int customerId, ConnectionString connectionString);

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
        List<ResourceType> GetAllResourceFilesWithPagination(Filter filter, int customerId, ConnectionString connectionString);

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
        int SetNewResourceDetails(ResourceType resourceType, int customerId, ConnectionString connectionString);

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
        int SetUpdateResourceDetails(ResourceType resourceType, int customerId, ConnectionString connectionString);

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
        int SetRemoveResourceDetails(int resourceId, int customerId, ConnectionString connectionString);

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
        int SetImageDocFile(ImageFiles imageFiles, int customerId, ConnectionString connectionString, string staffId);

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
        int SetUpdateImageDocFile(ImageFiles imageFiles, int customerId, ConnectionString connectionString, string staffId);

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
        int RemoveImageDocFile(int imageFilesId, int customerId, ConnectionString connectionString);

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
        List<ImageFiles> GetAllImageDocFiles(Filter filter, int customerId, ConnectionString connectionString);

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
        int SetNewClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString);

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
        int SetUpdateClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString);

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
        int SetRemoveClientRequirement(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        int SetClientRequirementFile(string fileName, string fileUrl, string fileType, int clientRequirementId, ConnectionString connectionString, string localPath);

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
        int RemoveClientRequirementFile(int clientRequirementFileId, int customerId, ConnectionString connectionString);

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
        int UpdateClientRequirementRanking(int clientRequirementId, string moveDirection, int customerId, ConnectionString connectionString);

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
        int SetNewGlobalClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString);

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
        int SetRemoveGlobalClientRequirement(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        List<ClientRequirement> GetGlobalClientRequirement(Filter filter, int customerId, ConnectionString connectionString);

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
        List<ClientRequirement> GetClientRequirement(Filter filter, int customerId, ConnectionString connectionString);

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
        List<ClientRequirementFile> GetClientRequirementFiles(int clientRequirementId, ConnectionString connectionString);

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
        int SetClientRequirementRole(int roleId, int clientRequirementId, int customerId, ConnectionString connectionString);

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
        int RemoveClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        int SetGlobalClientRequirementRole(int roleId, int clientRequirementId, int customerId, ConnectionString connectionString);

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
        int RemoveGlobalClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        List<RoleDetails> GetClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        List<RoleDetails> GetGlobalClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString);

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
        List<SocialMedia> GetAllSocialMediaList(Filter filter, int clientId, ConnectionString connectionString);

        // CheckEmailExists
        /// <summary>
        /// 
        /// Check if the email exists
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// userEmail -> string
        /// </remarks>
        bool CheckEmailExists(string userEmail, ConnectionString connectionString);

    }
}
