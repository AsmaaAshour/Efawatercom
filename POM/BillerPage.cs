using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.POM
{
    public class BillerPage
    {
        IWebDriver _driver;

        public BillerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By billname = By.XPath("//div//input[@formcontrolname='Billname']");
        By billemail = By.XPath("//div//input[@formcontrolname='Email']");
        By billlocation = By.XPath("//div//input[@formcontrolname='Location']");
        By submitbutton = By.XPath("//div//button[text()='create']");

        public void EnterBillName(String value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(billname);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterBillEmail(String value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(billemail);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterBillLocation(String value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(billlocation);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickSubmitButton()
        {
            CommonMethods.WaitAndFindElement(submitbutton).Click();
        }
    }
}