using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.BugFixes
{
    public interface IBugFixesService
    {
        // SetBugFixDetails
        /// <summary>
        /// Set Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFix -> BugFix object
        /// actionState -> string
        /// </remarks>
        string SetBugFixesDetails(BugFix bugFix, string actionState, int companyId);

        // GetBugFixDisplayModules
        /// <summary>
        /// Getting the Bug Fixess modules to display
        /// </summary>
        /// <returns>
        /// DisplayModule object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        List<DisplayModule> GetBugFixesDisplayModules(Filter filter, int companyId);

        // GetBugFixDisplayList
        /// <summary>
        /// Getting the Bug Fixess display list
        /// </summary>
        /// <returns>
        /// ViewBugFix object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        List<ViewBugFix> GetBugFixesDisplayList(Filter filter, string UserId, int companyId);

        // GetBugFixDetailsById
        /// <summary>
        /// Getting the Bug Fixess details based on the Id
        /// </summary>
        /// <returns>
        /// BugFix object
        /// </returns>
        /// <remarks>
        /// BugFixId -> String value
        /// </remarks>
        BugFix GetBugFixesDetailsById(string bugFixId, string userId, int companyId);

        // UpdateBugFixStatus
        /// <summary>
        /// Updating the status of the Bug Fixes
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixId -> String value
        /// statusId -> Int value
        /// </remarks>
        bool UpdateBugFixesStatus(string bugFixId, int statusId, int companyId);

        // SetBugFixesChangeDate
        /// <summary>
        /// Set Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// actionState -> String value
        /// BugFixChangeDate -> BugFixChangeDate object value
        /// </remarks>
        string SetBugFixesChangeDate(BugFixChangeDate bugFixChangeDate, string actionState, int companyId);

        // GetBugFixesChangeDate
        /// <summary>
        /// Get Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// ViewBugFixChangeDate object list value
        /// </returns>
        /// <remarks>
        /// BugFixId -> String value
        /// filter -> Filter object value
        /// </remarks>
        List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixId, int companyId);

        // SetBugFixesComment
        /// <summary>
        /// Set Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixComment -> BugFixComment object value
        /// actionState -> string value
        /// </remarks>
        string SetBugFixesComment(BugFixComment bugFixComment, string actionState, int companyId);

        // GetBugFixesComment
        /// <summary>
        /// Get Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// ViewBugFixComment object list value
        /// </returns>
        /// <remarks>
        /// filter -> Filter object value
        /// </remarks>
        List<ViewBugFixComment> GetBugFixesComment(Filter filter, int companyId);

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
        List<StatisticsBoxData> GetStatBoxes(int companyId);

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
        bool ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval, int companyId);

        // AddViewId
        /// <summary>
        /// Setting the view ID for the bug fixes
        /// </summary>
        /// <returns>
        /// itemId string value
        /// userId string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        bool AddViewId(string itemId, string userId, int companyId);
    }
}
