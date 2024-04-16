using AWSProjectAPI.Controllers;
using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.Authentication;
using AWSProjectAPI.DataAccess.Common;
using AWSProjectAPI.Service.Authentication;
using AWSProjectAPI.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_NUnit_TestProject.Test.TestControllers
{
    public class AuthenticationControllerUnitTest
    {
        IAuthenticationService _iAuthenticationService;
        IAuthenticationDataAccess _iAuthenticationDataAccess;
        IConfiguration configurationString;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configurationString = builder.Build();

            _iAuthenticationDataAccess = new AuthenticationDataAccess(configurationString);
            _iAuthenticationService = new AuthenticationService(_iAuthenticationDataAccess);
        }

        [Test]
        public void LoginAuthentication_WhenAuthenticationIsSuccess_ReturnsTheToken()
        {
            // Arrange
            var testDataEmail = "rashmalat@gmail.com";
            var testDataPass = "123";

            var controller = new AuthenticationController(_iAuthenticationService);

            // Act
            var result = controller.LoginAuthentication(testDataEmail, testDataPass) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreNotEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void LoginAuthentication_WhenAuthenticationIsNotSuccess_ReturnsError()
        {
            // Arrange
            var testDataEmail = "rashmalat@gmail.com";
            var testDataPass = "1234";

            var controller = new AuthenticationController(_iAuthenticationService);

            // Act
            var result = controller.LoginAuthentication(testDataEmail, testDataPass) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Value.ToString());
            Assert.AreEqual("ERROR", result.Value.ToString());
        }

        [Test]
        public void LogoutUser_WhenLogoutSuccessfully_ReturnsTrue()
        {
            // Arrange
            var testDataEmail = "rashmalat@gmail.com";

            var controller = new AuthenticationController(_iAuthenticationService);

            // Act
            var result = controller.LogoutUser(testDataEmail) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((bool?)result.Value);
        }

        [Test]
        public void GetUserAccessLevels_WhenAdminIsLoggedIn_ReturnsAllAccess()
        {
            // Arrange
            var testDataUserId = "D7FC4D7F-511A-413D-96C4-D3097F4188CA";

            var controller = new AuthenticationController(_iAuthenticationService);

            // Act
            var result = controller.GetUserAccessLevels(testDataUserId) as JsonResult;

            // Assert
            var model = result.Value as List<AccessLevel>;
            Assert.IsNotNull(model);
            Assert.True(model.Count > 0);
        }

    }
}
