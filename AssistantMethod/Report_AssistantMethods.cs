using EfawatercomProject.POM;
using EfawatercomProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;
using System.Data.SqlClient;
using EfawatercomProject.Data;
using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;
using Bytescout.Spreadsheet;

namespace EfawatercomProject.AssistantMethod
{
    public class Report_AssistantMethods
    {
        public static void ShowListOfCategory()
        {
            ReportPage reportpage = new ReportPage(ManageDriver.driver);

            reportpage.ClickReportPage();
            reportpage.ClickList();
        }


        public static void SearchByDate(Report_Info report_info)
        {
            ReportPage reportpage = new ReportPage(ManageDriver.driver);

            reportpage.EnterStartDate(report_info.startdate);
            reportpage.EnterEndDate(report_info.enddate);
        }


        public static void SelectRandomCategoryFromList()
        {
            var categoryOptions = ManageDriver.driver.FindElements(By.XPath("//div/select/option[@class=\"ng-star-inserted\"]"));

            Random random = new Random();
            int randomIndex = random.Next(categoryOptions.Count);

            string selectedCategoryName = categoryOptions[randomIndex].Text;

            categoryOptions[randomIndex].Click();
        }


        public static Report_Info ReadDateFromExcel(int row)
        {
            Report_Info report_info = new Report_Info();

            Worksheet worksheet = CommonMethods.ReadExcel("Report");

            double startDateValue = Convert.ToDouble(worksheet.Cell(row, 1).Value);
            double endDateValue = Convert.ToDouble(worksheet.Cell(row, 2).Value);

            DateTime startDate = DateTime.FromOADate(startDateValue);
            DateTime endDate = DateTime.FromOADate(endDateValue);

            report_info.startdate = startDate;
            report_info.enddate = endDate;

            return report_info;
        }
    }
}