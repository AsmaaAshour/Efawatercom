using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.POM
{
    public class ReportPage
    {
        IWebDriver _driver;

        public ReportPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By reportpage = By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[2]/a");
        By list = By.XPath("//div/select[@formcontrolname='Billercategoryname']");
        By startdate = By.XPath("//div/input[@formcontrolname='DateFrom']");
        By enddate = By.XPath("//div/input[@formcontrolname='DateTo']");
        By detailesbutton = By.XPath("//table/tbody/tr[1]/td[4]/button");

        public void ClickReportPage()
        {
            CommonMethods.WaitAndFindElement(reportpage).Click();
        }

        public void ClickList()
        {
            CommonMethods.WaitAndFindElement(list).Click();
        }

        public void EnterStartDate(DateTime startDate)
        {
            IWebElement startDateField = CommonMethods.WaitAndFindElement(startdate);
            startDateField.SendKeys(startDate.ToString("MM-dd-yyyy"));
        }

        public void EnterEndDate(DateTime endDate)
        {
            IWebElement endDateField = CommonMethods.WaitAndFindElement(enddate);
            endDateField.SendKeys(endDate.ToString("MM-dd-yyyy"));
        }

        public void ClickDetailesButton()
        {
            CommonMethods.WaitAndFindElement(detailesbutton).Click();
        }
    }
}