using EfawatercomProject.Helpers;
using EfawatercomProject.POM;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using EfawatercomProject.Data;

namespace EfawatercomProject.AssistantMethod
{
    public class Biller_AssistantMethods
    {
        public static void FillBillerForm(Biller_Info biller_info)
        {
            BillerPage billerpage = new BillerPage(ManageDriver.driver);

            billerpage.EnterBillName(biller_info.bname);
            billerpage.EnterBillEmail(biller_info.bemail);
            billerpage.EnterBillLocation(biller_info.blocation);
            billerpage.ClickSubmitButton();
        }


        public static Biller_Info ReadBillerDataFromExcel(int row)
        {
            Biller_Info biller_info = new Biller_Info();

            Worksheet worksheet = CommonMethods.ReadExcel("Biller");

            biller_info.bname = Convert.ToString(worksheet.Cell(row, 1).Value);

            biller_info.bemail = Convert.ToString(worksheet.Cell(row, 2).Value);

            biller_info.blocation = Convert.ToString(worksheet.Cell(row, 3).Value);


            return biller_info;
        }


        public static void AddBillerRandomly()
        {
            var categoriesTable = ManageDriver.driver.FindElement(By.XPath("//div/div/table"));

            var categoryRows = categoriesTable.FindElements(By.XPath(".//tbody/tr"));

            Random random = new Random();
            int randomIndex = random.Next(0, categoryRows.Count);

            var randomCategoryRow = categoryRows[randomIndex];

            var createButton = randomCategoryRow.FindElement(By.XPath(".//button[text()=' Create ']"));
            createButton.Click();
        }


        public static void ViewBillerRandomly()
        {
            var categoriesTable = ManageDriver.driver.FindElement(By.XPath("//div/div/table"));

            var categoryRows = categoriesTable.FindElements(By.XPath(".//tbody/tr"));

            Random random = new Random();
            int randomIndex = random.Next(0, categoryRows.Count);

            var randomCategoryRow = categoryRows[randomIndex];

            Thread.Sleep(200);
            var showButton = randomCategoryRow.FindElement(By.XPath(".//td[1]/button"));

            ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("arguments[0].scrollIntoView(true);", showButton);
            Thread.Sleep(200);

            showButton.Click();
        }
    }
}