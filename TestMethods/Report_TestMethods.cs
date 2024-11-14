using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using EfawatercomProject.AssistantMethod;
using EfawatercomProject.Data;
using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace EfawatercomProject.TestMethods
{
    [TestClass]
    public class Report_TestMethods
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


        [TestMethod]
        public void CategoryListDisplayed()
        {
            var test = extentReports.CreateTest("TestSuccessfully_CategoryListDisplayed", "TestSuccessfully_CategoryListDisplayed");
            try
            {
                Report_AssistantMethods.ShowListOfCategory();

                Thread.Sleep(200);

                var categorysList = ManageDriver.driver.FindElement(By.XPath("//div/select[@formcontrolname='Billercategoryname']"));
                Assert.IsTrue(categorysList.Displayed, "Categort List not displayed");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void SelectCategory()
        {
            var test = extentReports.CreateTest("TestSuccessfully_SelectCategory", "TestSuccessfully_SelectCategory");

            try
            {
                // Select Report Page
                ManageDriver.driver.FindElement(By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[2]/a")).Click();

                Thread.Sleep(200);

                //All Categories In List
                var categoryOptions = ManageDriver.driver.FindElements(By.XPath("//div/select/option[@class=\"ng-star-inserted\"]"));

                Random random = new Random();
                int randomIndex = random.Next(categoryOptions.Count);

                string selectedCategoryName = categoryOptions[randomIndex].Text;
                categoryOptions[randomIndex].Click();

                // Category Name In Table
                string categoryActualValue = ManageDriver.driver.FindElement(By.XPath("//div/table/tbody/tr[1]/td[1]")).Text.Trim();

                // Count Pay In Table
                string countActualValue = ManageDriver.driver.FindElement(By.XPath("//div/table/tbody/tr[1]/td[2]")).Text.Trim();
                int countActual = int.Parse(countActualValue.Replace(" ", ""));

                // Sum Profit In Table
                string sumActualValue = ManageDriver.driver.FindElement(By.XPath("//div/table/tbody/tr[1]/td[3]")).Text.Trim();
                int sumActual = int.Parse(sumActualValue.Replace(" ", "").Replace("$", ""));

                Thread.Sleep(400);

                OracleDatabaseHelper dbHelper = new OracleDatabaseHelper();
                var (expectedCount, expectedSum, billerId) = dbHelper.GetCountAndSumFromDatabase(selectedCategoryName);

                Assert.AreEqual(selectedCategoryName, categoryActualValue, "Category name mismatch");
                Assert.AreEqual(expectedCount, countActual, $"The count for the category '{selectedCategoryName}' does not match the database value. Expected: {expectedCount}, Actual: {countActual}");
                Assert.AreEqual(expectedSum, sumActual, $"The sum for the category '{selectedCategoryName}' does not match the database value. Expected: {expectedSum}, Actual: {sumActual}");
            }

            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


    [TestMethod]
        public void SearchByDate_ValidRange()
        {
            var test = extentReports.CreateTest("TestSuccessfully_SearchByDateValidRange", "TestSuccessfully_SearchByDateValidRange");
            try
            {
                // Select Report Page
                ManageDriver.driver.FindElement(By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[2]/a")).Click();

                Thread.Sleep(200);

                Report_AssistantMethods.SelectRandomCategoryFromList();

                Report_Info report_info = Report_AssistantMethods.ReadDateFromExcel(2);

                Report_AssistantMethods.SearchByDate(report_info);

                Thread.Sleep(200);

                ManageDriver.driver.FindElement(By.XPath("//table/tbody/tr[1]/td[4]/button")).Click();

                Thread.Sleep(200);

                DateTime StartDate = report_info.startdate;
                DateTime EndDate = report_info.enddate;

                Thread.Sleep(300);

                var paymentDateElements = ManageDriver.driver.FindElements(By.XPath(".//tbody/tr/td[4]"));

                string[] dateFormats = { "MMM d, yy", "MMM d, yyyy" };

                List<DateTime> paymentDates = paymentDateElements
                    .Select(element =>
                    {
                        DateTime parsedDate;

                        if (DateTime.TryParseExact(element.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                        {
                            return parsedDate;
                        }
                        else
                        {
                            throw new FormatException($"Date '{element.Text}' was not recognized in any specified format.");
                        }
                    })
                    .ToList();

                foreach (var paymentDate in paymentDates)
                {
                    Assert.IsTrue(paymentDate >= StartDate && paymentDate <= EndDate,
                                  $"Payment date {paymentDate} is out of range ({StartDate} - {EndDate}).");
                }
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }


        [TestMethod]
        public void SearchByDate_InvalidRange()
        {
            var test = extentReports.CreateTest("TestSuccessfully_SearchByDateinValidRange", "TestSuccessfully_SearchByDateinValidRange");
            try
            {
                ManageDriver.driver.FindElement(By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[2]/a")).Click();

                Thread.Sleep(200);

                Report_AssistantMethods.SelectRandomCategoryFromList();

                Report_Info report_info = Report_AssistantMethods.ReadDateFromExcel(3);

                Report_AssistantMethods.SearchByDate(report_info);

                Thread.Sleep(300);

                String expectedValue = " Total Profit 0 $";
                string actualValue = ManageDriver.driver.FindElement(By.XPath("//div[2]/div/table/tbody/tr")).Text;

                actualValue = actualValue.Trim();
                expectedValue = expectedValue.Trim();

                Assert.AreEqual(expectedValue, actualValue);
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                string screenShotPath = CommonMethods.TakeScreenShot();
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }

        [TestMethod]
        public void SearchbyDate_NoResults()
        {
            var test = extentReports.CreateTest("TestSuccessfully_SearchByDateNoResults", "TestSuccessfully_SearchByDateNoResults");

            try
            {
                ManageDriver.driver.FindElement(By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[2]/a")).Click();

                Thread.Sleep(200);

                Report_AssistantMethods.SelectRandomCategoryFromList();

                Report_Info report_info = Report_AssistantMethods.ReadDateFromExcel(4);

                Report_AssistantMethods.SearchByDate(report_info);

                Thread.Sleep(300);

                String expectedValue = " Total Profit 0 $";
                string actualValue = ManageDriver.driver.FindElement(By.XPath("//div[2]/div/table/tbody/tr")).Text;

                actualValue = actualValue.Trim();
                expectedValue = expectedValue.Trim();

                Assert.AreEqual(expectedValue, actualValue);
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