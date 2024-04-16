using AWSProjectAPI.Controllers;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;

namespace AWS_NUnit_TestProject.Test.TestControllers
{
    public class Tests
    {
        ICommonService _iCommonService;
        ICommonDataAccess _iCommonDataAccess;
        IConfiguration configurationString;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configurationString = builder.Build();

            _iCommonDataAccess = new CommonDataAccess(configurationString);
            _iCommonService = new CommonService(_iCommonDataAccess);
        }

        [Test]
        public void CheckEmailExists_WhenEmailExists_ReturnsTrue()
        {
            // Arrange
            var testData = "rashmalat@gmail.com";
            var expectedResult = true;

            //var mockICommonService = new Mock<ICommonService>();
            //mockICommonService.Setup(service => service.CheckEmailExists(testData)).Returns(expectedResult);
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.CheckEmailExists(testData) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.Value);
        }

        [Test]
        public void CheckEmailExists_WhenEmailDoesNotExists_ReturnsFalse()
        {
            // Arrange
            var testData = "rashmalat123@gmail.com";
            var expectedResult = false;

            //var mockICommonService = new Mock<ICommonService>();
            //mockICommonService.Setup(service => service.CheckEmailExists(testData)).Returns(expectedResult);
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.CheckEmailExists(testData) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.Value);
        }

        [Test]
        public void GetPriorityList_CheckTheListCount_ReturnsThree()
        {
            // Arrange
            List<Priority> expectedItemsListResult = new List<Priority>()
            {
                new Priority(){ Id = 1, Code = "UG", Name = "Urgent" },
                new Priority(){ Id = 2, Code = "NM", Name = "Normal" },
                new Priority(){ Id = 3, Code = "LW", Name = "Low" }
            };
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetPriorityList() as JsonResult;

            // Assert
            var model = result.Value as List<Priority>;
            Assert.IsNotNull(model, "model is not of type List<ItemModel>");
            Assert.True(model.Count == 3);
        }

        [Test]
        public void GetPriorityList_CheckTheListData_ReturnsThreePriorityObjectList()
        {
            // Arrange
            List<Priority> expectedItemsListResult = new List<Priority>()
            {
                new Priority(){ Code = "UG", Id = 1,  Name = "Urgent" },
                new Priority(){ Code = "NM", Id = 2,  Name = "Normal" },
                new Priority(){ Code = "LW", Id = 3,  Name = "Low" }
            };
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetPriorityList() as JsonResult;
            List<Priority> jsonList = (List<Priority>)result.Value;


            // Assert
            Assert.AreEqual(expectedItemsListResult, jsonList);
        }

        [Test]
        public void GetModuleList_CheckTheCountOfModules_ReturnsTrueWhenGreaterThanZero()
        {
            // Arrange
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetModuleList() as JsonResult;

            // Assert
            var model = result.Value as List<Module>;
            Assert.IsNotNull(model);
            Assert.True(model.Count > 0);
        }

        [Test]
        public void GetStatusList_CheckTheListCountWithSEModule_ReturnsFiveObjectList()
        {
            // Arrange
            var passParam = "SE";
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetStatusList(passParam) as JsonResult;

            // Assert
            var model = result.Value as List<Status>;
            Assert.IsNotNull(model, "model is not of type List<ItemModel>");
            Assert.True(model.Count == 5);
        }

        [Test]
        public void GetStatusList_CheckTheListCountWithBGModule_ReturnsFiveObjectList()
        {
            // Arrange
            var passParam = "BG";
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetStatusList(passParam) as JsonResult;

            // Assert
            var model = result.Value as List<Status>;
            Assert.IsNotNull(model, "model is not of type List<ItemModel>");
            Assert.True(model.Count == 5);
        }

        [Test]
        public void GetStatusList_CheckTheListCountWithSEModule_ReturnsFiveStatusObjectList()
        {
            // Arrange
            var passParam = "SE";
            List<Status> expectedItemsListResult = new List<Status>()
            {
                new Status(){ Id = 1, Code = "RP", Name = "Reported", ColorCode = "#E5FA65" },
                new Status(){ Id = 2, Code = "SC", Name = "Scheduled", ColorCode = "#FAC260" },
                new Status(){ Id = 3, Code = "DC", Name = "Declined", ColorCode = "#FF5757" },
                new Status(){ Id = 4, Code = "WP", Name = "Work in Progress", ColorCode = "#2185D0" },
                new Status(){ Id = 5, Code = "SO", Name = "SignedOff", ColorCode = "#82EF8A" }
            };
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetStatusList(passParam) as JsonResult;
            List<Status> jsonList = (List<Status>)result.Value;

            // Assert
            Assert.AreEqual(expectedItemsListResult, jsonList);
        }

        [Test]
        public void GetStatusList_CheckTheListCountWithBGModule_ReturnsFiveStatusObjectList()
        {
            // Arrange
            var passParam = "BG";
            List<Status> expectedItemsListResult = new List<Status>()
            {
                new Status(){ Id = 8, Code = "RP", Name = "Reported", ColorCode = "#E5FA65" },
                new Status(){ Id = 9, Code = "SC", Name = "Scheduled", ColorCode = "#FAC260" },
                new Status(){ Id = 10, Code = "DC", Name = "Declined", ColorCode = "#FF5757" },
                new Status(){ Id = 11, Code = "WP", Name = "Work in Progress", ColorCode = "#2185D0" },
                new Status(){ Id = 12, Code = "CF", Name = "Confirm Fix", ColorCode = "#82EF8A" }
            };
            var controller = new CommonController(_iCommonService);

            // Act
            var result = controller.GetStatusList(passParam) as JsonResult;
            List<Status> jsonList = (List<Status>)result.Value;

            // Assert
            Assert.AreEqual(expectedItemsListResult, jsonList);
        }

    }
}