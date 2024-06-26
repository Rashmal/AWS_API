using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Common
{
    public interface ICommonService
    {
        // CheckEmailExists
        /// <summary>
        /// Check if the email exists
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// userEmail -> string
        /// </remarks>
        bool CheckEmailExists(string userEmail);

        // GetPriorityList
        /// <summary>
        /// Getting the priority list
        /// </summary>
        /// <returns>
        /// Priority object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<Priority> GetPriorityList(int companyId);

        // GetStatusList
        /// <summary>
        /// Getting the status list
        /// </summary>
        /// <returns>
        /// Status object list value
        /// </returns>
        /// <remarks>
        /// moduleCode -> string value
        /// </remarks>
        List<Status> GetStatusList(string moduleCode, int companyId);

        // GetModuleList
        /// <summary>
        /// Getting the module list
        /// </summary>
        /// <returns>
        /// Module object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<Module> GetModuleList(int companyId);

        // GetAllStaffList
        /// <summary>
        /// Getting all the staff list
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<BasicUserDetails> GetAllStaffList(int companyId);

        // TotalGlobalNotes
        /// <summary>
        /// Getting the total of global notes
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        int TotalGlobalNotes(string tabSection, string userId, int companyId);

        // SendEmail
        /// <summary>
        /// Sending the emails 
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        string SendEmail(EmailBodyDetails internelEmailObject);

        // SendEmailLocally
        /// <summary>
        /// Sending the emails 
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        string SendEmailLocally(EmailBodyDetails emailDetails);

        // GetModuleListBasedUserRole
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<Module> GetModuleListBasedUserRole(string userRole, bool isStatic, int companyId, string userId);

        // GetAccessListBasedUserRole
        /// <summary>
        /// Getting all the access list based on the user role
        /// </summary>
        /// <returns>
        /// UserRoleAccessDetail object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<UserRoleAccessDetail> GetAccessListBasedUserRole(string userRole, int companyId);

        // Getting all the access list based on the user role for view
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<Module> GetViewAccessListBasedUserRole(string userRole, int companyId, string userId);

        // GetAccountDetails
        /// <summary>
        /// Getting all the account details
        /// </summary>
        /// <returns>
        /// AccountDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<AccountDetails> GetAccountDetails(Filter filter);

        // GetAllBusinessNumberTypes
        /// <summary>
        /// Getting all the business number type details
        /// </summary>
        /// <returns>
        /// BusinessNumberType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<BusinessNumberType> GetAllBusinessNumberTypes();

        // GetAllClientSizes
        /// <summary>
        /// Getting all the client size details
        /// </summary>
        /// <returns>
        /// ClientSize object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<ClientSize> GetAllClientSizes();

        // GetAllContactTypes
        /// <summary>
        /// Getting all the contact type details
        /// </summary>
        /// <returns>
        /// ContactType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<ContactType> GetAllContactTypes();

        // GetAllCountries
        /// <summary>
        /// Getting all the country details
        /// </summary>
        /// <returns>
        /// Country object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<Country> GetAllCountries();

        // GetAllDays
        /// <summary>
        /// Getting all the day details
        /// </summary>
        /// <returns>
        /// DayDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<DayDetails> GetAllDays();

        // GetAllPriceClassifications
        /// <summary>
        /// Getting all the price classfication details
        /// </summary>
        /// <returns>
        /// PriceClassification object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<PriceClassification> GetAllPriceClassifications();

        // GetAllRatings
        /// <summary>
        /// Getting all the rating details
        /// </summary>
        /// <returns>
        /// RatingDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<RatingDetails> GetAllRatings();

        // GetAllSocialMediaTypes
        /// <summary>
        /// Getting all the social media type details
        /// </summary>
        /// <returns>
        /// SocialMediaType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<SocialMediaType> GetAllSocialMediaTypes();

        // GetAllTermTypes
        /// <summary>
        /// Getting all the term type details
        /// </summary>
        /// <returns>
        /// TermType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<TermType> GetAllTermTypes();

        // GetAllRoleDetails
        /// <summary>
        /// Getting all the role details
        /// </summary>
        /// <returns>
        /// RoleDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<RoleDetails> GetAllRoleDetails();

        // GetConnectionString
        /// <summary>
        /// Getting all the connection details
        /// </summary>
        /// <returns>
        /// ConnectionString object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        ConnectionString GetConnectionString(int parentGroupId, string moduleCode);

        // GetAllParentGroupsDetailsByEmail
        /// <summary>
        /// Getting all the parent groups by email
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<ParentGroup> GetAllParentGroupsDetailsByEmail(string email);

        // GetAllParentGroupsDetailsById
        /// <summary>
        /// Getting all the parent groups by id
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<ParentGroup> GetAllParentGroupsDetailsById(string userId);

        
    }
}
