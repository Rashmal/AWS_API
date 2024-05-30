﻿using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.BugFixes;
using AWSProjectAPI.DataAccess.ClientDetails;
using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ResourceType = AWSProjectAPI.Core.Client.ResourceType;

namespace AWSProjectAPI.Service.ClientDetails
{
    public class ClientService : IClientService
    {
        #region Private Properties
        private readonly IClientDataAccess iClientDataAccess;
        protected string GLOBAL_FILES_PATH { get; set; }
        protected string IMAGE_DOC_FILES_PATH { get; set; }
        protected string CLIENT_REQ_FILES_PATH { get; set; }
        #endregion

        // Constructor
        public ClientService(IClientDataAccess iClientDataAccess, IConfiguration configurationString)
        {
            this.iClientDataAccess = iClientDataAccess;
            // Intantiating the object
            this.GLOBAL_FILES_PATH = configurationString.GetConnectionString("GLOBAL_FILES_PATH");
            this.IMAGE_DOC_FILES_PATH = configurationString.GetConnectionString("IMAGE_DOC_FILES_PATH");
            this.CLIENT_REQ_FILES_PATH = configurationString.GetConnectionString("CLIENT_REQ_FILES_PATH");
        }

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
        public List<DisplayClientDetails> GetDisplayClientDetails(Filter filter, int companyId)
        {
            // Getting the display client display list
            List<DisplayClientDetails> displayClientDetailsList = this.iClientDataAccess.GetDisplayClientDetails(filter, companyId);

            // Declare the filter
            Filter filterContacts = new Filter()
            {
                Id = "",
                CurrentPage = 1,
                RecordsPerPage = 10,
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                ModuleId = 0,
                Param1 = "",
                ParentId = 0,
                PriorityId = 0,
                SearchQuery = "",
                SortColumn = "",
                SortDirection = "",
                StaffId = "",
                StatusId = 0
            };

            // Loop through the list
            for (int i = 0; i < displayClientDetailsList.Count; i++)
            {
                // Getting the type
                displayClientDetailsList[i].Contacts = this.iClientDataAccess.GetAllContactList(filterContacts, displayClientDetailsList[i].Id, companyId);
            }
            // End of Loop through the list

            // Return the list
            return displayClientDetailsList;
        }

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
        public List<Contact> GetAllContactList(Filter filter, int clientId, int companyId)
        {
            // Getting the client list
            return this.iClientDataAccess.GetAllContactList(filter, clientId, companyId);
        }

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
        public int SetClientCustomer(ClientCustomer clientCustomer, string staffId, string actionType, int companyId)
        {
            // Getting the client list
            return this.iClientDataAccess.SetClientCustomer(clientCustomer, staffId, actionType, companyId);
        }

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
        public ClientCustomer GetClientCustomer(int clientId, int companyId)
        {
            // Getting the client list
            return this.iClientDataAccess.GetClientCustomer(clientId, companyId);
        }

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
        public int SetBillingAddress(BusinessAddress businessAddress, string actionType, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.SetBillingAddress(businessAddress, actionType, customerId, companyId);
        }

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
        public BusinessAddress GetBillingAddress(int clientId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetBillingAddress(clientId, companyId);
        }

        // SetContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string (NEW/UPDATE/REMOVE)
        /// contact -> Contact object
        /// </remarks>
        public int SetContactDetails(Contact contact, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewContactDetails(contact, customerId, companyId);
                    break;
                case "UPDATE":
                    newId = iClientDataAccess.SetUpdateContactDetails(contact, customerId, companyId);
                    break;
                case "REMOVE":
                    newId = iClientDataAccess.SetRemoveContactDetails(contact.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public List<Contact> GetContactListDetails(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetContactListDetails(filter, customerId, companyId);
        }

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
        public int SetSocialMediaDetails(SocialMedia socialMedia, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewSocialMediaDetails(socialMedia, customerId, companyId);
                    break;
                case "UPDATE":
                    newId = iClientDataAccess.SetUpdateSocialMediaDetails(socialMedia, customerId, companyId);
                    break;
                case "REMOVE":
                    newId = iClientDataAccess.SetRemoveSocialMediaDetails(socialMedia.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public List<SocialMedia> GetSocialMediaListDetails(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetSocialMediaListDetails(filter, customerId, companyId);
        }

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
        public int SetRelationshipDetails(RelationshipDetails relationshipDetails, string actionType, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.SetRelationshipDetails(relationshipDetails, actionType, customerId, companyId);
        }

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
        public RelationshipDetails GetRelationshipDetails(int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetRelationshipDetails(customerId, companyId);
        }

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
        public int SetOtherRateDetails(HourlyOtherRates hourlyOtherRates, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewHourlyOtherRatesDetails(hourlyOtherRates, customerId, companyId);
                    break;
                case "UPDATE":
                    newId = iClientDataAccess.SetUpdateHourlyOtherRatesDetails(hourlyOtherRates, customerId, companyId);
                    break;
                case "REMOVE":
                    newId = iClientDataAccess.SetRemoveHourlyOtherRatesDetails(hourlyOtherRates.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public List<HourlyOtherRates> GetHourlyOtherRateListDetails(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetHourlyOtherRateListDetails(filter, customerId, companyId);
        }

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
        public List<GlobalFileDetails> GetAllFilesList(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetAllFilesList(filter, customerId, companyId);
        }

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
        public int RemoveGlobalFile(int globalFileId, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.RemoveGlobalFile(globalFileId, customerId, companyId);
        }

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
        public string UploadGlobalFile(List<IFormFile> files, int customerId, int companyId)
        {
            // Store the return value
            string uploadStatus = "ERROR";

            // Uploading the file
            try
            {
                for (int i = 0; i < files.Count; i++)
                {

                    // Getting the file path
                    string folderName = this.GLOBAL_FILES_PATH;
                    IFormFile file = files[i];
                    // Check the file length
                    if (file.Length > 0)
                    {
                        // File name
                        var fileName = file.FileName;

                        // Reading the extenstion
                        string fileExt = System.IO.Path.GetExtension(file.FileName);

                        // Updating the file name
                        folderName = folderName + "\\" + RandomStringOnly(5);

                        // Path
                        var pathToSave = Path.Combine(folderName);

                        // Check the directory
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        // End of Check the directory

                        // Setting the full path
                        string fullPath = Path.Combine(pathToSave, fileName);

                        // Check if file exists with its full path
                        if (File.Exists(fullPath))
                        {
                            // If file found, delete it  
                            File.Delete(fullPath);
                        }
                        // End of Check if file exists with its full path

                        // Upload the file
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // End of Upload the file

                        // Writing to the DB
                        int newUploadedFileId = this.iClientDataAccess.SetGlobalFile(fileName, fullPath, fileExt.Substring(1).ToUpper(), companyId);

                        if (newUploadedFileId > 0)
                        {
                            uploadStatus = "SUCCESS";
                        }
                    }

                }
                // End of Check the file length
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UploadGlobalFile ! :" + ex);
            }
            // End of Uploading the file

            // Return the value
            return uploadStatus;
        }

        private static string RandomStringOnly(int length)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            const string pool = "abcdefghijklmnopqrstuvwxyz";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

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
        public List<ResourceType> GetAllResourceFiles(int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetAllResourceFiles(customerId, companyId);
        }

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
        public List<ResourceType> GetAllResourceFilesWithPagination(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetAllResourceFilesWithPagination(filter, customerId, companyId);
        }

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
        public int SetResourceTypeDetails(ResourceType resourceType, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewResourceDetails(resourceType, customerId, companyId);
                    break;
                case "UPDATE":
                    newId = iClientDataAccess.SetUpdateResourceDetails(resourceType, customerId, companyId);
                    break;
                case "REMOVE":
                    newId = iClientDataAccess.SetRemoveResourceDetails(resourceType.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public string UploadImageDocFile(List<IFormFile> files, int customerId, int companyId, int resourceTypeId)
        {
            // Store the return value
            string uploadStatus = "ERROR";

            // Uploading the file
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    // Getting the file path
                    string folderName = this.IMAGE_DOC_FILES_PATH;

                    IFormFile file = files[i];

                    // Check the file length
                    if (file.Length > 0)
                    {
                        // File name
                        var fileName = file.FileName;

                        // Reading the extenstion
                        string fileExt = System.IO.Path.GetExtension(file.FileName);

                        // Updating the file name
                        folderName = folderName + "\\" + RandomStringOnly(5);

                        // Path
                        var pathToSave = Path.Combine(folderName);

                        // Check the directory
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        // End of Check the directory

                        // Setting the full path
                        string fullPath = Path.Combine(pathToSave, fileName);

                        // Check if file exists with its full path
                        if (File.Exists(fullPath))
                        {
                            // If file found, delete it  
                            File.Delete(fullPath);
                        }
                        // End of Check if file exists with its full path

                        // Upload the file
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // End of Upload the file

                        // Writing to the DB
                        ImageFiles imageFiles = new ImageFiles()
                        {
                            Id = 0,
                            Caption = fileName,
                            InternalNotes = "",
                            ResourceFile = fullPath,
                            TotalRecords = 0,
                            ResourceType = new ResourceType()
                            {
                                Id = resourceTypeId,
                                Code = "",
                                Name = "",
                                TotalRecords = 0
                            }
                        };

                        int newUploadedFileId = this.iClientDataAccess.SetImageDocFile(imageFiles, customerId, companyId);

                        if (newUploadedFileId > 0)
                        {
                            uploadStatus = "SUCCESS";
                        }

                    }
                    // End of Check the file length
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UploadGlobalFile ! :" + ex);
            }
            // End of Uploading the file

            // Return the value
            return uploadStatus;
        }

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
        public int SetUpdateImageDocFile(ImageFiles imageFiles, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.SetUpdateImageDocFile(imageFiles, customerId, companyId);
        }

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
        public int RemoveImageDocFile(int imageFilesId, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.RemoveImageDocFile(imageFilesId, customerId, companyId);
        }

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
        public List<ImageFiles> GetAllImageDocFiles(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetAllImageDocFiles(filter, customerId, companyId);
        }

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
        public int SetClientRequirement(ClientRequirement clientRequirement, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewClientRequirement(clientRequirement, customerId, companyId);
                    // Remove all roles
                    iClientDataAccess.RemoveClientRequirementRole(clientRequirement.Id, customerId, companyId);
                    // Loop through the requirements roles
                    for (int i = 0; i < clientRequirement.RoleDetails.Count; i++)
                    {
                        // Setting the role
                        iClientDataAccess.SetClientRequirementRole(clientRequirement.RoleDetails[i].Id, newId, customerId, companyId);
                    }
                    // End of Loop through the requirements roles
                    break;
                case "UPDATE":
                    newId = iClientDataAccess.SetUpdateClientRequirement(clientRequirement, customerId, companyId);
                    // Remove all roles
                    iClientDataAccess.RemoveClientRequirementRole(clientRequirement.Id, customerId, companyId);
                    // Loop through the requirements roles
                    for (int i = 0; i < clientRequirement.RoleDetails.Count; i++)
                    {
                        // Setting the role
                        iClientDataAccess.SetClientRequirementRole(clientRequirement.RoleDetails[i].Id, newId, customerId, companyId);
                    }
                    // End of Loop through the requirements roles
                    break;
                case "REMOVE":
                    // Remove all roles
                    iClientDataAccess.RemoveClientRequirementRole(clientRequirement.Id, customerId, companyId);
                    newId = iClientDataAccess.SetRemoveClientRequirement(clientRequirement.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public string SetClientRequirementFile(List<IFormFile> files, int clientRequirementId, string actionType, int customerId, int companyId)
        {
            // Store the return value
            string uploadStatus = "ERROR";

            // Uploading the file
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    // Getting the file path
                    string folderName = this.CLIENT_REQ_FILES_PATH;

                    IFormFile file = files[i];

                    // Check the file length
                    if (file.Length > 0)
                    {
                        // File name
                        var fileName = file.FileName;

                        // Reading the extenstion
                        string fileExt = System.IO.Path.GetExtension(file.FileName);

                        // Updating the file name
                        folderName = folderName + "\\" + RandomStringOnly(5);

                        // Path
                        var pathToSave = Path.Combine(folderName);

                        // Check the directory
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                        }
                        // End of Check the directory

                        // Setting the full path
                        string fullPath = Path.Combine(pathToSave, fileName);

                        // Check if file exists with its full path
                        if (File.Exists(fullPath))
                        {
                            // If file found, delete it  
                            File.Delete(fullPath);
                        }
                        // End of Check if file exists with its full path

                        // Upload the file
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // End of Upload the file

                        // Writing to the DB
                        int newUploadedFileId = this.iClientDataAccess.SetClientRequirementFile(fileName, fullPath, fileExt.Substring(1).ToUpper(), clientRequirementId, companyId);

                        if (newUploadedFileId > 0)
                        {
                            uploadStatus = "SUCCESS";
                        }

                    }
                    // End of Check the file length
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UploadGlobalFile ! :" + ex);
            }
            // End of Uploading the file

            // Return the value
            return uploadStatus;
        }

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
        public int RemoveClientRequirementFile(int clientRequirementFileId, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.RemoveClientRequirementFile(clientRequirementFileId, customerId, companyId);
        }

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
        public int UpdateClientRequirementRanking(int clientRequirementId, string moveDirection, int customerId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.UpdateClientRequirementRanking(clientRequirementId, moveDirection, customerId, companyId);
        }

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
        public int SetGlobalClientRequirement(ClientRequirement clientRequirement, string actionType, int customerId, int companyId)
        {
            // Store the new Id
            int newId = 0;

            // Check the action type
            switch (actionType)
            {
                case "NEW":
                    newId = iClientDataAccess.SetNewGlobalClientRequirement(clientRequirement, customerId, companyId);
                    // Remove all roles
                    iClientDataAccess.RemoveGlobalClientRequirementRole(clientRequirement.Id, customerId, companyId);
                    // Loop through the requirements roles
                    for (int i = 0; i < clientRequirement.RoleDetails.Count; i++)
                    {
                        // Setting the role
                        iClientDataAccess.SetGlobalClientRequirementRole(clientRequirement.RoleDetails[i].Id, newId, customerId, companyId);
                    }
                    // End of Loop through the requirements roles
                    break;
                case "REMOVE":
                    // Remove all roles
                    iClientDataAccess.RemoveGlobalClientRequirementRole(clientRequirement.Id, customerId, companyId);
                    newId = iClientDataAccess.SetRemoveGlobalClientRequirement(clientRequirement.Id, customerId, companyId);
                    break;
            }
            // End of Check the action type

            // return the ID
            return newId;
        }

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
        public List<ClientRequirement> GetGlobalClientRequirement(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            List<ClientRequirement> globalClientRequirements = this.iClientDataAccess.GetGlobalClientRequirement(filter, customerId, companyId);

            // Loop through the client requirements
            for (int i = 0; i < globalClientRequirements.Count; i++)
            {
                // Getting the client requirement roles
                globalClientRequirements[i].RoleDetails = this.iClientDataAccess.GetGlobalClientRequirementRole(globalClientRequirements[i].Id, customerId, companyId);
            }
            // End of Loop through the client requirements

            // Return the requirements
            return globalClientRequirements;
        }

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
        public List<ClientRequirement> GetClientRequirement(Filter filter, int customerId, int companyId)
        {
            // Getting the result
            List<ClientRequirement> clientRequirements = this.iClientDataAccess.GetClientRequirement(filter, customerId, companyId);

            // Loop through the client requirements
            for (int i = 0; i < clientRequirements.Count; i++)
            {
                // Getting the client requirement roles
                clientRequirements[i].RoleDetails = this.iClientDataAccess.GetClientRequirementRole(clientRequirements[i].Id, customerId, companyId);

                // Getting the client requirement files
                clientRequirements[i].ClientRequirementFiles = this.iClientDataAccess.GetClientRequirementFiles(clientRequirements[i].Id, companyId);
            }
            // End of Loop through the client requirements

            // Return the requirements
            return clientRequirements;
        }

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
        public List<SocialMedia> GetAllSocialMediaList(Filter filter, int clientId, int companyId)
        {
            // Getting the result
            return this.iClientDataAccess.GetAllSocialMediaList(filter, clientId, companyId);
        }
    }
}
