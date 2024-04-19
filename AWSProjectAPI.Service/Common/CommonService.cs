using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Common
{
    public class CommonService : ICommonService
    {
        #region Private Properties
        private readonly ICommonDataAccess iCommonDataAccess;
        #endregion

        // Constructor
        public CommonService(ICommonDataAccess iCommonDataAccess)
        {
            this.iCommonDataAccess = iCommonDataAccess;
        }

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
        public bool CheckEmailExists(string userEmail)
        {
            return iCommonDataAccess.CheckEmailExists(userEmail);
        }

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
        public List<Priority> GetPriorityList()
        {
            return iCommonDataAccess.GetPriorityList();
        }

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
        public List<Status> GetStatusList(string moduleCode)
        {
            return iCommonDataAccess.GetStatusList(moduleCode);
        }

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
        public List<Module> GetModuleList()
        {
            return iCommonDataAccess.GetModuleList();
        }

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
        public List<BasicUserDetails> GetAllStaffList()
        {
            return iCommonDataAccess.GetAllStaffList();
        }

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
        public int TotalGlobalNotes(string tabSection)
        {
            // Declare the count
            int totalCount = 0;

            // Check the tab section
            switch (tabSection.ToUpper())
            {
                case "TOTAL":
                    totalCount = iCommonDataAccess.TotalGlobalNotes();
                    break;
                case "SE":
                    totalCount = iCommonDataAccess.TotalSE();
                    break;
                case "BGF":
                    totalCount = iCommonDataAccess.TotalBG();
                    break;
            }
            // End of Check the tab section

            // Return the count
            return totalCount;
        }
    }
}
