using AWSProjectAPI.Controllers;
using AWSProjectAPI.Core.BugFixes;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.DataAccess.BugFixes;
using AWSProjectAPI.DataAccess.SystemEnhancements;
using AWSProjectAPI.Service.BugFixes;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_NUnit_TestProject.Test.TestControllers
{
    public class BugFixesControllerUnitTest
    {
        IBugFixesService _iBugFixesService;
        IBugFixesDataAccess _iBugFixesDataAccess;
        IConfiguration configurationString;
        string newlyAddedBEId = "";

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configurationString = builder.Build();

            _iBugFixesDataAccess = new BugFixesDataAccess(configurationString);
            _iBugFixesService = new BugFixesService(_iBugFixesDataAccess);
        }

        [Test]
        public void SetBugFixesDetails_AddingANewBugFix_ReturnsNewId()
        {
            // Arrange
            var bugFixDetails = new BugFix()
            {
                Id = "",
                AddedUserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                Title = "Adding the new dropdown for features Bug",
                Description = "Adding new features description Bug",
                StartDate = Convert.ToDateTime("2024-04-09"),
                EndDate = Convert.ToDateTime("2024-04-11"),
                EstimatedHours = 16,
                ModuleId = 1,
                PriorityId = 1,
                StatusId = 1,
                AssignedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                },
                RequestedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                }
            };

            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesDetails(bugFixDetails, "NEW") as JsonResult;
            newlyAddedBEId = result.Value.ToString();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void UpdateBugFixDetails_AddingANewBugFix_ReturnsNewId()
        {
            // Arrange
            var bugFixDetails = new BugFix()
            {
                Id = newlyAddedBEId,
                AddedUserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                Title = "Adding the new dropdown for features Updated",
                Description = "Adding new features description Updated",
                StartDate = Convert.ToDateTime("2024-04-09"),
                EndDate = Convert.ToDateTime("2024-04-11"),
                EstimatedHours = 16,
                ModuleId = 1,
                PriorityId = 1,
                StatusId = 1,
                AssignedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                },
                RequestedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                }
            };

            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesDetails(bugFixDetails, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void RemoveBugFixSystemEnhancementDetails_AddingANewBugFix_ReturnsId()
        {
            // Arrange
            var bugFixDetails = new BugFix()
            {
                Id = newlyAddedBEId,
                AddedUserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                Title = "Adding the new dropdown for features Updated",
                Description = "Adding new features description Updated",
                StartDate = Convert.ToDateTime("2024-04-09"),
                EndDate = Convert.ToDateTime("2024-04-11"),
                EstimatedHours = 16,
                ModuleId = 1,
                PriorityId = 1,
                StatusId = 1,
                AssignedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                },
                RequestedStaffList = new List<AWSProjectAPI.Core.Authentication.BasicUserDetails>()
                {
                    new AWSProjectAPI.Core.Authentication.BasicUserDetails()
                    {
                        Id  = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                        Email = "rashmalat@gmail.com",
                        Avatar = "",
                        FirstName = "Rashmal",
                        LastName = "Perera"
                    }
                }
            };

            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesDetails(bugFixDetails, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void GetBugFixesDisplayModules_WhenDefaultFilters_ReturnsTheList()
        {
            // Arrange
            var defaultFilter = new Filter()
            {
                Id = "",
                CurrentPage = 1,
                RecordsPerPage = 10,
                EndDate = null,
                StartDate = null,
                ModuleId = -1,
                ParentId = -1,
                PriorityId = -1,
                StaffId = "",
                StatusId = -1,
                SearchQuery = ""
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetBugFixesDisplayModules(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<DisplayModule>;
            Assert.IsNotNull(model);
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void GetBugFixesDisplayList_WhenDefaultFilters_ReturnsTheList()
        {
            // Arrange
            var defaultFilter = new Filter()
            {
                Id = "",
                CurrentPage = 1,
                RecordsPerPage = 10,
                EndDate = null,
                StartDate = null,
                ModuleId = 1,
                ParentId = -1,
                PriorityId = -1,
                StaffId = "",
                StatusId = -1,
                SearchQuery = ""
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetBugFixesDisplayList(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<ViewBugFix>;
            Assert.IsNotNull(model);
            Assert.True(model.Count <= 10 && model.Count >= 0);
        }

        [Test]
        public void GetBugFixesDetailsById_WhenRetrievingData_ReturnsBugFixDetails()
        {
            // Arrange
            var bugFixId = "659CF9A1-2024-4B53-B388-71C7817B6C0B";
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetBugFixesDetailsById(bugFixId) as JsonResult;

            // Assert
            var model = result.Value as BugFix;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id.ToUpper(), bugFixId.ToUpper());
        }

        [Test]
        public void UpdateBugFixesStatus_UpdateStatusToTwo_ReturnsTrue()
        {
            // Arrange
            var bugFixId = "659CF9A1-2024-4B53-B388-71C7817B6C0B";
            var statusId = 2;
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.UpdateBugFixesStatus(bugFixId, statusId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((bool?)result.Value);
        }

        [Test]
        public void AddBugFixChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var bugFixChangeDate = new BugFixChangeDate()
            {
                Id = 0,
                OldFromDate = Convert.ToDateTime("2024-04-09"),
                OldToDate = Convert.ToDateTime("2024-04-11"),
                NewFromDate = Convert.ToDateTime("2024-05-09"),
                NewToDate = Convert.ToDateTime("2024-05-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesChangeDate(bugFixChangeDate, "NEW") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void UpdateBugFixChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var bugFixChangeDate = new BugFixChangeDate()
            {
                Id = 1,
                OldFromDate = Convert.ToDateTime("2024-05-09"),
                OldToDate = Convert.ToDateTime("2024-05-12"),
                NewFromDate = Convert.ToDateTime("2024-06-09"),
                NewToDate = Convert.ToDateTime("2024-06-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesChangeDate(bugFixChangeDate, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void RemoveBugFixChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var bugFixChangeDate = new BugFixChangeDate()
            {
                Id = 1,
                OldFromDate = Convert.ToDateTime("2024-05-09"),
                OldToDate = Convert.ToDateTime("2024-05-12"),
                NewFromDate = Convert.ToDateTime("2024-06-09"),
                NewToDate = Convert.ToDateTime("2024-06-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesChangeDate(bugFixChangeDate, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void GetBugFixChangeDate_GettingTheDataBasedBugFix_ReturnsChangeDataHistory()
        {
            // Arrange
            var bugFixId = "659CF9A1-2024-4B53-B388-71C7817B6C0B";
            // Arrange
            var defaultFilter = new Filter()
            {
                Id = "",
                CurrentPage = 1,
                RecordsPerPage = 10,
                EndDate = null,
                StartDate = null,
                ModuleId = 1,
                ParentId = -1,
                PriorityId = -1,
                StaffId = "",
                StatusId = -1,
                SearchQuery = ""
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetBugFixesChangeDate(defaultFilter, bugFixId) as JsonResult;

            // Assert
            var model = result.Value as List<ViewBugFixChangeDate>;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void AddBugFixComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var bugFixCommentData = new BugFixComment()
            {
                Id = 0,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                Description = "This is a sample comment"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesComment(bugFixCommentData, "NEW") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void UpdateBugFixComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var bugFixCommentData = new BugFixComment()
            {
                Id = 1,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                Description = "This is a sample comment"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesComment(bugFixCommentData, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void RemoveBugFixComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var bugFixCommentData = new BugFixComment()
            {
                Id = 2,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                BugFixesId = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                Description = "This is a sample comment"
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.SetBugFixesComment(bugFixCommentData, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void GetBugFixesComment_GettingCommentsOnDefaultFilter_ReturnsList()
        {
            // Arrange
            var defaultFilter = new Filter()
            {
                Id = "659CF9A1-2024-4B53-B388-71C7817B6C0B",
                CurrentPage = 1,
                RecordsPerPage = 10,
                EndDate = null,
                StartDate = null,
                ModuleId = 1,
                ParentId = 0,
                PriorityId = -1,
                StaffId = "",
                StatusId = -1,
                SearchQuery = ""
            };
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetBugFixesComment(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<ViewBugFixComment>;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void GetStatBoxes_GettingDashboardStats_ReturnsList()
        {
            // Arrange
            var controller = new BugFixesController(_iBugFixesService);

            // Act
            var result = controller.GetStatBoxes() as JsonResult;

            // Assert
            var model = result.Value as List<StatisticsBoxData>;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.True(model.Count == 5);
        }
    }
}
