using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.DataAccess.BugFixes
{
    public interface IBugFixesDataAccess
    {
        // AddBugFixesDetails
        /// <summary>
        /// Adding Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        string AddBugFixesDetails(BugFix bugFixes);

        // UpdateBugFixesDetails
        /// <summary>
        /// Updating Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        string UpdateBugFixesDetails(BugFix bugFixes);

        // DeleteBugFixesDetails
        /// <summary>
        /// Removing Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// </remarks>
        string DeleteBugFixesDetails(string bugFixesId);

        // DeleteBugFixesAssignedStaff
        /// <summary>
        /// Removing Bug Fixes related assigned staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// </remarks>
        string DeleteBugFixesAssignedStaff(string bugFixesId);

        // DeleteBugFixesRequestedStaff
        /// <summary>
        /// Removing Bug Fixes related requested staffs
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// </remarks>
        string DeleteBugFixesRequestedStaff(string bugFixesId);

        // AddBugFixesAssignedStaff
        /// <summary>
        /// Adding Bug Fixes related assigned staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// staffId -> string value
        /// </remarks>
        string AddBugFixesAssignedStaff(string bugFixesId, string staffId);

        // AddBugFixesRequestedStaff
        /// <summary>
        /// Adding Bug Fixes related requested staff
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        /// <remarks>
        /// BugFixesId -> string value
        /// staffId -> string value
        /// </remarks>
        string AddBugFixesRequestedStaff(string bugFixesId, string staffId);

        // GetBugFixesDisplayModules
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

        // GetBugFixesDisplayList
        /// <summary>
        /// Getting the Bug Fixess display list
        /// </summary>
        /// <returns>
        /// ViewBugFixes object list
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// </remarks>
        List<ViewBugFix> GetBugFixesDisplayList(Filter filter, string UserId);

        // GetBugFixesDetailsById
        /// <summary>
        /// Getting the Bug Fixess details based on the Id
        /// </summary>
        /// <returns>
        /// BugFixes object
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        BugFix GetBugFixesDetailsById(string bugFixesId, string userId = "");

        // GetBugFixesAssignedStaff
        /// <summary>
        /// Getting the Bug Fixess assigned staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        List<BasicUserDetails> GetBugFixesAssignedStaff(string bugFixesId);

        // GetBugFixesRequestedStaff
        /// <summary>
        /// Getting the Bug Fixess requested staff details
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// </remarks>
        List<BasicUserDetails> GetBugFixesRequestedStaff(string bugFixesId);

        // UpdateBugFixesStatus
        /// <summary>
        /// Updating the status of the Bug Fixes
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// statusId -> Int value
        /// </remarks>
        bool UpdateBugFixesStatus(string bugFixesId, int statusId);

        // AddBugFixesChangeDate
        /// <summary>
        /// Adding the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        string AddBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate);

        // UpdateBugFixesChangeDate
        /// <summary>
        /// Upadating the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        string UpdateBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate);

        // DeleteBugFixesChangeDate
        /// <summary>
        /// Removing the new dates in the Bug Fixes details
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        string DeleteBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate);

        // GetBugFixesChangeDate
        /// <summary>
        /// Get Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// ViewBugFixesChangeDate object list value
        /// </returns>
        /// <remarks>
        /// BugFixesId -> String value
        /// filter -> Filter object value
        /// </remarks>
        List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixesId);

        // AddBugFixesComment
        /// <summary>
        /// Adding Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        string AddBugFixesComment(BugFixComment bugFixesComment);

        // UpdateBugFixesComment
        /// <summary>
        /// Update Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        string UpdateBugFixesComment(BugFixComment bugFixesComment);

        // DeleteBugFixesComment
        /// <summary>
        /// Removing Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// </remarks>
        string DeleteBugFixesComment(BugFixComment bugFixesComment);

        // GetBugFixesComment
        /// <summary>
        /// Get Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// ViewBugFixesComment object list value
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
        bool AddViewId(string itemId, string userId);
    }
}
