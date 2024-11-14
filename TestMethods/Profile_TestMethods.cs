using EfawatercomProject.POM;
using EfawatercomProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfawatercomProject.AssistantMethod;
using EfawatercomProject.Data;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;

namespace EfawatercomProject.TestMethods
{
    [TestClass]
    public class Profile_TestMethods
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\EfawatercomFinalProject\\report\\report");

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            extentReports.AttachReporter(reporter);

            ManageDriver.MaximizeDriver();
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            extentReports.Flush();

            ManageDriver.CloseDriver();
        }


        [TestInitialize]
        public void Setup()
        {
            CommonMethods.NavigateToURL(GlobalConstants.loginLink);

            Login_Info login_info = Login_AssistantMethods.ReadLoginDataFromExcel(2);
            Login_AssistantMethods.FillLoginForm(login_info);
        }


        [TestMethod]
        public void ChangeNameSuccessfully()
        {
            var test = extentReports.CreateTest("TestSuccessfully_ChangeName", "TestSuccessfully_ChangeName");

            try
            {
                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(2);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "updated successfully";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void ChangeNameWithInvalidPassword()
        {
            var test = extentReports.CreateTest("TestFail_ChangeNameWithInvalidPassword", "TestFail_ChangeNameWithInvalidPassword");
            try
            {
                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(3);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "error password";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void ChangeNameWithEmptyNameField()
        {
            var test = extentReports.CreateTest("TestFail_ChangeNameWithEmptyNameField", "TestFail_ChangeNameWithEmptyNameField");
            try
            {
                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(4);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "Full Name is required!";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void ChangeNameWithEmptyPasswordField()
        {
            var test = extentReports.CreateTest("TestFail_ChangeNameWithEmptyPasswordField", "TestFail_ChangeNameWithEmptyPasswordField");
            try
            {
                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(5);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "Current Password is required!";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }



        [TestMethod]
        public void ChangeNameWithInvalidFullnameFormat()
        {
            var test = extentReports.CreateTest("TestFail_ChangeNameWithInvalidFullnameFormat", "TestFail_ChangeNameWithInvalidFullnameFormat");
            try
            {

                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(6);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "Invalid full name format";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);

            }
        }


        [TestMethod]
        public void ChangeNameWithForgetRequiredFiled()
        {
            var test = extentReports.CreateTest("TestFail_ChangeNameWithForgetRequiredFiled", "TestFail_ChangeNameWithForgetRequiredFiled");
            try
            {

                Profile_Info profile_info = Profile_AssistantMethods.ReadProfileInfoFromExcel(7);

                Profile_AssistantMethods.FillProfileForm(profile_info);

                Thread.Sleep(200);

                IWebElement successMessage = ManageDriver.driver.FindElement(By.XPath("//*[@id=\"toast-container\"]"));

                string expectedMessage = "Email is required!";
                string actualMessage = successMessage.Text;

                Assert.AreEqual(expectedMessage, actualMessage);
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }
    }
}