using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.BugFixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.BugFixes
{
    public class BugFixesService: IBugFixesService
    {
        #region Private Properties
        private readonly IBugFixesDataAccess iBugFixesDataAccess;
        #endregion

        // Constructor
        public BugFixesService(IBugFixesDataAccess iBugFixesDataAccess)
        {
            this.iBugFixesDataAccess = iBugFixesDataAccess;
        }

        // SetBugFixesDetails
        /// <summary>
        /// Set Bug Fixes Details
        /// </summary>
        /// <returns>
        /// string value of the Id
        /// </returns>
        /// <remarks>
        /// BugFixes -> BugFixes object
        /// actionState -> string
        /// </remarks>
        public string SetBugFixesDetails(BugFix bugFix, string actionState)
        {
            // Declare the new ID
            string newId = "";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the new Bug Fixes
                    newId = this.iBugFixesDataAccess.AddBugFixesDetails(bugFix);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaff = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaff, taskAddRequestedStaff);
                    break;
                case "UPDATE":
                    // Updating the new Bug Fixes
                    newId = this.iBugFixesDataAccess.UpdateBugFixesDetails(bugFix);
                    // Remove all the assigned and requested staff
                    Task taskRemoveAssignedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesAssignedStaff(newId));
                    Task taskRemoveRequestedStaffUpdate = Task.Factory.StartNew(() => this.iBugFixesDataAccess.DeleteBugFixesRequestedStaff(newId));
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskRemoveAssignedStaffUpdate, taskRemoveRequestedStaffUpdate);
                    // Adding all the assigned and requested staff
                    Task taskAddAssignedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.AssignedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesAssignedStaff(newId, bugFix.AssignedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    Task taskAddRequestedStaffUpdate = Task.Factory.StartNew(() =>
                    {
                        // Loop through the assigned staff
                        for (int i = 0; i < bugFix.RequestedStaffList.Count; i++)
                        {
                            // Setting the staff details
                            this.iBugFixesDataAccess.AddBugFixesRequestedStaff(newId, bugFix.RequestedStaffList[i].Id);
                        }
                        // End of Loop through the assigned staff
                    });
                    // Wait untill all the tasks are completed
                    Task.WaitAll(taskAddAssignedStaffUpdate, taskAddRequestedStaffUpdate);
                    break;
                case "DELETE":
                    // Deleting the new Bug Fixes
                    newId = this.iBugFixesDataAccess.DeleteBugFixesDetails(bugFix.Id);
                    break;
            }
            // End of Check the action state

            // Return the value
            return newId;
        }

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
        public List<DisplayModule> GetBugFixesDisplayModules(Filter filter)
        {
            return this.iBugFixesDataAccess.GetBugFixesDisplayModules(filter);
        }

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
        public List<ViewBugFix> GetBugFixesDisplayList(Filter filter)
        {
            // Declare the object
            List<ViewBugFix> bugFixesList = new List<ViewBugFix>();
            // Getting the list
            bugFixesList = this.iBugFixesDataAccess.GetBugFixesDisplayList(filter);
            // Loop through the list
            for (int i = 0; i < bugFixesList.Count; i++)
            {
                // Setting the requested staff list
                bugFixesList[i].RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesList[i].Id);
            }
            // End of Loop through the list

            // return the value
            return bugFixesList;
        }

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
        public BugFix GetBugFixesDetailsById(string bugFixesId)
        {
            // Declare the object
            BugFix BugFixes = new BugFix();
            // Getting the basic details
            BugFixes = this.iBugFixesDataAccess.GetBugFixesDetailsById(bugFixesId);
            // Getting the assigned staff details
            BugFixes.AssignedStaffList = this.iBugFixesDataAccess.GetBugFixesAssignedStaff(bugFixesId);
            // Getting the requested staff details
            BugFixes.RequestedStaffList = this.iBugFixesDataAccess.GetBugFixesRequestedStaff(bugFixesId);
            // return the value
            return BugFixes;
        }

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
        public bool UpdateBugFixesStatus(string bugFixesId, int statusId)
        {
            return this.iBugFixesDataAccess.UpdateBugFixesStatus(bugFixesId, statusId);
        }

        // SetBugFixesChangeDate
        /// <summary>
        /// Set Bug Fixes Change date history
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// actionState -> String value
        /// BugFixesChangeDate -> BugFixesChangeDate object value
        /// </remarks>
        public string SetBugFixesChangeDate(BugFixChangeDate bugFixesChangeDate, string actionState)
        {
            // Declare the variable
            string status = "ERROR";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement change date history
                    status = this.iBugFixesDataAccess.AddBugFixesChangeDate(bugFixesChangeDate);
                    break;
                case "UPDATE":
                    // Updating the system ehancement change date history
                    status = this.iBugFixesDataAccess.UpdateBugFixesChangeDate(bugFixesChangeDate);
                    break;
                case "DELETE":
                    // Deleting the history record
                    status = this.iBugFixesDataAccess.DeleteBugFixesChangeDate(bugFixesChangeDate);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

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
        public List<ViewBugFixChangeDate> GetBugFixesChangeDate(Filter filter, string bugFixesId)
        {
            return this.iBugFixesDataAccess.GetBugFixesChangeDate(filter, bugFixesId);
        }

        // SetBugFixesComment
        /// <summary>
        /// Set Bug Fixes Comment
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// BugFixesComment -> BugFixesComment object value
        /// actionState -> string value
        /// </remarks>
        public string SetBugFixesComment(BugFixComment bugFixesComment, string actionState)
        {
            // Declare the variable
            string status = "false";

            // Check the action state
            switch (actionState)
            {
                case "NEW":
                    // Adding the system ehancement comment
                    status = this.iBugFixesDataAccess.AddBugFixesComment(bugFixesComment);
                    break;
                case "UPDATE":
                    // Updating the system ehancement comment
                    status = this.iBugFixesDataAccess.UpdateBugFixesComment(bugFixesComment);
                    break;
                case "DELETE":
                    // Deleting the comment
                    status = this.iBugFixesDataAccess.DeleteBugFixesComment(bugFixesComment);
                    break;
            }
            // End of Check the action state

            // Return the value
            return status;
        }

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
        public List<ViewBugFixComment> GetBugFixesComment(Filter filter)
        {
            return this.iBugFixesDataAccess.GetBugFixesComment(filter);
        }

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
        public List<StatisticsBoxData> GetStatBoxes()
        {
            return this.iBugFixesDataAccess.GetStatBoxes();
        }
    }
}
