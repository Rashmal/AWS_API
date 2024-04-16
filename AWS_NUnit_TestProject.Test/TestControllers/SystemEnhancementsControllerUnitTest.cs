using AWSProjectAPI.Controllers;
using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.Core.SystemEnhancements;
using AWSProjectAPI.DataAccess.Authentication;
using AWSProjectAPI.DataAccess.SystemEnhancements;
using AWSProjectAPI.Service.SystemEnhancements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWS_NUnit_TestProject.Test.TestControllers
{
    public class SystemEnhancementsControllerUnitTest
    {
        ISystemEnhancementsService _iSystemEnhancementsService;
        ISystemEnhancementsDataAccess _iSystemEnhancementsDataAccess;
        IConfiguration configurationString;
        string newlyAddedSEId = "";

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configurationString = builder.Build();

            _iSystemEnhancementsDataAccess = new SystemEnhancementsDataAccess(configurationString);
            _iSystemEnhancementsService = new SystemEnhancementsService(_iSystemEnhancementsDataAccess);
        }

        [Test]
        public void SetSystemEnhancementDetails_AddingANewSystemEnhancement_ReturnsNewId()
        {
            // Arrange
            var systemEnhancementDetails = new SystemEnhancement()
            {
                Id = "",
                AddedUserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                Title = "Adding the new dropdown for features",
                Description = "Adding new features description",
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

            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEnhancementDetails(systemEnhancementDetails, "NEW") as JsonResult;
            newlyAddedSEId = result.Value.ToString();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void UpdateSystemEnhancementDetails_AddingANewSystemEnhancement_ReturnsNewId()
        {
            // Arrange
            var systemEnhancementDetails = new SystemEnhancement()
            {
                Id = newlyAddedSEId,
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

            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEnhancementDetails(systemEnhancementDetails, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void RemoveSystemEnhancementDetails_AddingANewSystemEnhancement_ReturnsId()
        {
            // Arrange
            var systemEnhancementDetails = new SystemEnhancement()
            {
                Id = newlyAddedSEId,
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

            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEnhancementDetails(systemEnhancementDetails, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void GetSystemEnhancementDisplayModules_WhenDefaultFilters_ReturnsTheList()
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
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.GetSystemEnhancementDisplayModules(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<DisplayModule>;
            Assert.IsNotNull(model);
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void GetSystemEnhancementDisplayList_WhenDefaultFilters_ReturnsTheList()
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
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.GetSystemEnhancementDisplayList(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<ViewSystemEnhancement>;
            Assert.IsNotNull(model);
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void GetSystemEnhancementDetailsById_WhenRetrievingData_ReturnsSystemEnhancementDetails()
        {
            // Arrange
            var systemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F";
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.GetSystemEnhancementDetailsById(systemEnhancementId) as JsonResult;

            // Assert
            var model = result.Value as SystemEnhancement;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id.ToUpper(), systemEnhancementId.ToUpper());
        }

        [Test]
        public void UpdateSystemEnhancementStatus_UpdateStatusToTwo_ReturnsTrue()
        {
            // Arrange
            var systemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F";
            var statusId = 2;
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.UpdateSystemEnhancementStatus(systemEnhancementId, statusId) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((bool?)result.Value);
        }

        [Test]
        public void AddSystemEhancementChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var systemEhancementChangeDate = new SystemEnhancementChangeDate()
            {
                Id = 0,
                OldFromDate = Convert.ToDateTime("2024-04-09"),
                OldToDate = Convert.ToDateTime("2024-04-11"),
                NewFromDate = Convert.ToDateTime("2024-05-09"),
                NewToDate = Convert.ToDateTime("2024-05-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementChangeDate(systemEhancementChangeDate, "NEW") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void UpdateSystemEhancementChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var systemEhancementChangeDate = new SystemEnhancementChangeDate()
            {
                Id = 1,
                OldFromDate = Convert.ToDateTime("2024-05-09"),
                OldToDate = Convert.ToDateTime("2024-05-12"),
                NewFromDate = Convert.ToDateTime("2024-06-09"),
                NewToDate = Convert.ToDateTime("2024-06-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementChangeDate(systemEhancementChangeDate, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void RemoveSystemEhancementChangeDate_UpdateStatusToTwo_ReturnsSuccess()
        {
            // Arrange
            var systemEhancementChangeDate = new SystemEnhancementChangeDate()
            {
                Id = 1,
                OldFromDate = Convert.ToDateTime("2024-05-09"),
                OldToDate = Convert.ToDateTime("2024-05-12"),
                NewFromDate = Convert.ToDateTime("2024-06-09"),
                NewToDate = Convert.ToDateTime("2024-06-12"),
                OldDuration = 16,
                NewDuration = 32,
                Reason = "Due to conflicts the date is changed",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementChangeDate(systemEhancementChangeDate, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("SUCCESS", result.Value.ToString());
        }

        [Test]
        public void GetSystemEhancementChangeDate_GettingTheDataBasedSystemEnhancement_ReturnsChangeDataHistory()
        {
            // Arrange
            var systemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F";
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
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.GetSystemEhancementChangeDate(defaultFilter, systemEnhancementId) as JsonResult;

            // Assert
            var model = result.Value as List<ViewSystemEnhancementChangeDate>;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void AddSystemEhancementComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var systemEnhancementCommentData = new SystemEnhancementComment()
            {
                Id = 0,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                Description = "This is a sample comment"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementComment(systemEnhancementCommentData, "NEW") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void UpdateSystemEhancementComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var systemEnhancementCommentData = new SystemEnhancementComment()
            {
                Id = 1,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                Description = "This is a sample comment"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementComment(systemEnhancementCommentData, "UPDATE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void RemoveSystemEhancementComment_SettingTheData_ReturnsTrue()
        {
            // Arrange
            var systemEnhancementCommentData = new SystemEnhancementComment()
            {
                Id = 2,
                ParentId = 0,
                UserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA",
                SystemEnhancementId = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
                Description = "This is a sample comment"
            };
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.SetSystemEhancementComment(systemEnhancementCommentData, "DELETE") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("True", result.Value.ToString());
        }

        [Test]
        public void GetSystemEhancementComment_GettingCommentsOnDefaultFilter_ReturnsList()
        {
            // Arrange
            var defaultFilter = new Filter()
            {
                Id = "57C5B0A3-40CC-4E91-B33B-17B8D844848F",
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
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

            // Act
            var result = controller.GetSystemEhancementComment(defaultFilter) as JsonResult;

            // Assert
            var model = result.Value as List<ViewSystemEnhancementComment>;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.True(model.Count <= 10 && model.Count > 0);
        }

        [Test]
        public void GetStatBoxes_GettingDashboardStats_ReturnsList()
        {
            // Arrange
            var controller = new SystemEnhancementsController(_iSystemEnhancementsService);

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
