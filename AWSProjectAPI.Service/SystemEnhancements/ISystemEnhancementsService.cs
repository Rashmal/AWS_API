using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.SystemEnhancements
{
    public interface ISystemEnhancementsService
    {
        // SetSystemEnhancementDetails
        /// <summary>
        /// Set System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// actionState -> string
        /// </remarks>
        string SetSystemEnhancementDetails(SystemEnhancement systemEnhancement, string actionState);

        // GetSystemEnhancementDisplayModules
        /// <summary>
        /// Getting the system enhancements modules to display
        /// </summary>
        /// <returns>
        /// DisplayModule object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        List<DisplayModule> GetSystemEnhancementDisplayModules(Filter filter);

        // GetSystemEnhancementDisplayList
        /// <summary>
        /// Getting the system enhancements display list
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancement object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        List<ViewSystemEnhancement> GetSystemEnhancementDisplayList(Filter filter);

        // GetSystemEnhancementDetailsById
        /// <summary>
        /// Getting the system enhancements details based on the Id
        /// </summary>
        /// <returns>
        /// SystemEnhancement object
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        SystemEnhancement GetSystemEnhancementDetailsById(string systemEnhancementId);

        // UpdateSystemEnhancementStatus
        /// <summary>
        /// Updating the status of the system enhancement
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// statusId -> Int value
        /// </remarks>
        bool UpdateSystemEnhancementStatus(string systemEnhancementId, int statusId);

        // SetSystemEhancementChangeDate
        /// <summary>
        /// Set System Enhancement Change date history
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// actionState -> String value
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        string SetSystemEhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate, string actionState);

        // GetSystemEhancementChangeDate
        /// <summary>
        /// Get System Enhancement Change date history
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancementChangeDate object list value
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// filter -> Filter object value
        /// </remarks>
        List<ViewSystemEnhancementChangeDate> GetSystemEhancementChangeDate(Filter filter, string systemEnhancementId);

        // SetSystemEhancementComment
        /// <summary>
        /// Set System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// actionState -> string value
        /// </remarks>
        string SetSystemEhancementComment(SystemEnhancementComment systemEnhancementComment, string actionState);

        // GetSystemEhancementComment
        /// <summary>
        /// Get System Enhancement Comment
        /// </summary>
        /// <returns>
        /// ViewSystemEnhancementComment object list value
        /// </returns>
        /// <remarks>
        /// filter -> Filter object value
        /// </remarks>
        List<ViewSystemEnhancementComment> GetSystemEhancementComment(Filter filter);

        // GetStatBoxes
        /// <summary>
        /// Getting the stat boxes
        /// </summary>
        /// <returns>
        /// StatisticsBoxData object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        List<StatisticsBoxData> GetStatBoxes();
    }
}
