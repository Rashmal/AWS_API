using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.SystemEnhancements
{
    public interface ISystemEnhancementsDataAccess
    {
        // AddSystemEnhancementDetails
        /// <summary>
        /// Adding System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        string AddSystemEnhancementDetails(SystemEnhancement systemEnhancement);

        // UpdateSystemEnhancementDetails
        /// <summary>
        /// Updating System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        string UpdateSystemEnhancementDetails(SystemEnhancement systemEnhancement);

        // DeleteSystemEnhancementDetails
        /// <summary>
        /// Removing System Enhancement Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// systemEnhancement -> SystemEnhancement object
        /// </remarks>
        string DeleteSystemEnhancementDetails(string systemEnhancementId);

        // DeleteSystemEnhancementAssignedStaff
        /// <summary>
        /// Removing System Enhancement related assigned staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// </remarks>
        string DeleteSystemEnhancementAssignedStaff(string systemEnhancementId);

        // DeleteSystemEnhancementRequestedStaff
        /// <summary>
        /// Removing System Enhancement related requested staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// </remarks>
        string DeleteSystemEnhancementRequestedStaff(string systemEnhancementId);

        // AddSystemEnhancementAssignedStaff
        /// <summary>
        /// Adding System Enhancement related assigned staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// staffId -> string value
        /// </remarks>
        string AddSystemEnhancementAssignedStaff(string systemEnhancementId, string staffId);

        // AddSystemEnhancementRequestedStaff
        /// <summary>
        /// Adding System Enhancement related requested staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> string value
        /// staffId -> string value
        /// </remarks>
        string AddSystemEnhancementRequestedStaff(string systemEnhancementId, string staffId);

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
        List<ViewSystemEnhancement> GetSystemEnhancementDisplayList(Filter filter, string UserId);

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

        // GetSystemEnhancementAssignedStaff
        /// <summary>
        /// Getting the system enhancements assigned staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        List<BasicUserDetails> GetSystemEnhancementAssignedStaff(string systemEnhancementId);

        // GetSystemEnhancementRequestedStaff
        /// <summary>
        /// Getting the system enhancements requested staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// systemEnhancementId -> String value
        /// </remarks>
        List<BasicUserDetails> GetSystemEnhancementRequestedStaff(string systemEnhancementId);

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

        // AddSystemEnhancementChangeDate
        /// <summary>
        /// Adding the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        string AddSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate);

        // UpdateSystemEnhancementChangeDate
        /// <summary>
        /// Upadating the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        string UpdateSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate);

        // DeleteSystemEnhancementChangeDate
        /// <summary>
        /// Removing the new dates in the system enhancement details
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementChangeDate -> SystemEnhancementChangeDate object value
        /// </remarks>
        string DeleteSystemEnhancementChangeDate(SystemEnhancementChangeDate systemEnhancementChangeDate);

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

        // AddSystemEhancementComment
        /// <summary>
        /// Adding System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        string AddSystemEhancementComment(SystemEnhancementComment systemEnhancementComment);

        // UpdateSystemEhancementComment
        /// <summary>
        /// Update System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        string UpdateSystemEhancementComment(SystemEnhancementComment systemEnhancementComment);

        // DeleteSystemEhancementComment
        /// <summary>
        /// Removing System Enhancement Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// systemEnhancementComment -> SystemEnhancementComment object value
        /// </remarks>
        string DeleteSystemEhancementComment(SystemEnhancementComment systemEnhancementComment);

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

        // ApprovalChangeDate
        /// <summary>
        /// Getting the approval change date
        /// </summary>
        /// <returns>
        /// SystemEnhancementsChangeHistoryId int value
        /// approval string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        bool ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval);

        // AddViewId
        /// <summary>
        /// Setting the view ID for the system enhancement
        /// </summary>
        /// <returns>
        /// itemId string value
        /// userId string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        bool AddViewId(string itemId, string userId);
    }
}
