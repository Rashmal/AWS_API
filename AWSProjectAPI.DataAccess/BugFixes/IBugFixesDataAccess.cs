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
        string AddBugFixesDetails(BugFix bugFixes, ConnectionString connectionString);

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
        string UpdateBugFixesDetails(BugFix bugFixes, ConnectionString connectionString);

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
        string DeleteBugFixesDetails(string bugFixesId, ConnectionString connectionString);

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
        string DeleteBugFixesAssignedStaff(string bugFixesId, ConnectionString connectionString);

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
        string DeleteBugFixesRequestedStaff(string bugFixesId, ConnectionString connectionString);

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
        string AddBugFixesAssignedStaff(string bugFixesId, string staffId, ConnectionString connectionString);

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
        string AddBugFixesRequestedStaff(string bugFixesId, string staffId, ConnectionString connectionString);

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
        List<DisplayModule> GetBugFixesDisplayModules(Filter filter, ConnectionString connectionString);

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
        List<ViewBugFix> GetBugFixesDisplayList(Filter filter, string UserId, ConnectionString connectionString);

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
        BugFix GetBugFixesDetailsById(string bugFixesId, ConnectionString connectionString, string userId = "");

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
        List<BasicUserDetails> GetBugFixesAssignedStaff(string bugFixesId, ConnectionString connectionString);

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
        List<BasicUserDetails> GetBugFixesRequestedStaff(string bugFixesId, ConnectionString connectionString);

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
        bool UpdateBugFixesStatus(string bugFixesId, int statusId, ConnectionString connectionString);

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
        string AddBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, ConnectionString connectionString);

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
        string UpdateBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, ConnectionString connectionString);

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
        string DeleteBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, ConnectionString connectionString);

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
        List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixesId, ConnectionString connectionString);

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
        string AddBugFixesComment(BugFixComment bugFixesComment, ConnectionString connectionString);

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
        string UpdateBugFixesComment(BugFixComment bugFixesComment, ConnectionString connectionString);

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
        string DeleteBugFixesComment(BugFixComment bugFixesComment, ConnectionString connectionString);

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
        List<ViewBugFixComment> GetBugFixesComment(Filter filter, ConnectionString connectionString);

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
        List<StatisticsBoxData> GetStatBoxes(ConnectionString connectionString);

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
        bool ApprovalChangeDate(int SystemEnhancementsChangeHistoryId, string approval, ConnectionString connectionString);

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
        bool AddViewId(string itemId, string userId, ConnectionString connectionString);
    }
}
