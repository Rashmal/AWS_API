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
        string SetBugFixesDetails(BugFix bugFix, string actionState);

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
        List<DisplayModule> GetBugFixesDisplayModules(Filter filter);

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
        List<ViewBugFix> GetBugFixesDisplayList(Filter filter);

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
        BugFix GetBugFixesDetailsById(string bugFixId);

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
        bool UpdateBugFixesStatus(string bugFixId, int statusId);

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
        string SetBugFixesChangeDate(BugFixChangeDate bugFixChangeDate, string actionState);

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
        List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixId);

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
        string SetBugFixesComment(BugFixComment bugFixComment, string actionState);

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
        List<ViewBugFixComment> GetBugFixesComment(Filter filter);

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
    }
}
