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
        List<Priority> GetPriorityList();

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
        List<Status> GetStatusList(string moduleCode);

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
        List<Module> GetModuleList();

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
        List<BasicUserDetails> GetAllStaffList();

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
        int TotalGlobalNotes(string tabSection, string userId);

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
    }
}
