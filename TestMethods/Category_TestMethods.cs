using EfawatercomProject.Helpers;
using EfawatercomProject.AssistantMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfawatercomProject.Data;
using EfawatercomProject.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static EfawatercomProject.AssistantMethod.Category_AssistantMethods;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace EfawatercomProject.TestMethods
{
    [TestClass]
    public class Category_TestMethods
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

            Thread.Sleep(200);
        }


        //[TestMethod]
        //public void AddedCategory()
        //{
        //    var test = extentReports.CreateTest("TestSuccessfully_AddCategory", "TestSuccessfully_AddCategory");

        //    try
        //    {
        //        ManageDriver.driver.FindElement(By.XPath("//div/button[contains(text(), 'Create Category Name')]")).Click();

        //        Category_Info category_info = Category_AssistantMethods.ReadCategoryFromExcel(2);

        //        Category_AssistantMethods.FillCategoryForm(category_info);

        //        Thread.Sleep(200);

        //        OracleDatabaseHelper dbHelper = new OracleDatabaseHelper();
        //        bool isAdded = dbHelper.IsCategoryAdded(category_info.name);
        //        Assert.IsTrue(isAdded, $"The category '{category_info.name}' was not added to the database.");
        //    }

        //    catch (Exception ex)
        //    {
        //        test.Fail(ex.Message);
        //        string screenShotPath = CommonMethods.TakeScreenShot();
        //        test.AddScreenCaptureFromPath(screenShotPath);
        //    }
        //}


        //[TestMethod]
        //public void AddedBiller()
        //{
        //    var test = extentReports.CreateTest("TestSuccessfully_AddBiller", "TestSuccessfully_AddBiller");
        //    try
        //    {
        //        Biller_AssistantMethods.AddBillerRandomly();

        //        Thread.Sleep(200);

        //        Biller_Info biller_info = Biller_AssistantMethods.ReadBillerDataFromExcel(2);

        //        Biller_AssistantMethods.FillBillerForm(biller_info);

        //        Thread.Sleep(200);

        //        string billName = biller_info.bname;

        //        OracleDatabaseHelper dbHelper = new OracleDatabaseHelper();
        //        bool isAdded = dbHelper.IsBillAdded(billName);
        //        Assert.IsTrue(isAdded, $"The bill '{billName}' was not added to the database.");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Fail(ex.Message);
        //        string screenShotPath = CommonMethods.TakeScreenShot();
        //        test.AddScreenCaptureFromPath(screenShotPath);
        //    }
        //}


        [TestMethod]
        public void ViewdBillers()
        {
            var test = extentReports.CreateTest("TestSuccessfully_ViewdBiller", "TestSuccessfully_ViewdBiller");
            try
            {

                Biller_AssistantMethods.ViewBillerRandomly();

                Thread.Sleep(200);

                var billsList = ManageDriver.driver.FindElements(By.XPath(".//div/table/tbody/tr[2]/td"));
                Assert.IsTrue(billsList.Count > 0, "No bills found under the selected category.");
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void Added_UniqdBiller()
        {
            var test = extentReports.CreateTest("TestSuccessfully_Added_UniqdBiller", "TestSuccessfully_Added_UniqdBiller");
            try
            {
                Biller_Info biller_info = Biller_AssistantMethods.ReadBillerDataFromExcel(2);
                string billName = biller_info.bname;

                OracleDatabaseHelper dbHelper = new OracleDatabaseHelper();
                bool doesExist = dbHelper.IsBillAdded(billName);

                Assert.IsFalse(doesExist, $"The biller '{billName}' already exists in the database and cannot be added again.");

                if (!doesExist)
                {
                    Biller_AssistantMethods.AddBillerRandomly();
                    Biller_AssistantMethods.FillBillerForm(biller_info);
                    Thread.Sleep(200);

                    bool isAdded = dbHelper.IsBillAdded(billName);
                    Assert.IsTrue(isAdded, $"The biller '{billName}' was not added to the database.");
                }
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