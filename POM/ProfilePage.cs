using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.POM
{
    public class ProfilePage
    {
        IWebDriver _driver;

        public ProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By profilebutton = By.XPath("//*[@id=\"sidebarCollapse\"]/ul/li[7]/a");
        By fullname = By.XPath("//div//input[@formcontrolname='FullName']");
        By phonenumber = By.XPath("//div//input[@formcontrolname='PhoneNumber']");
        By email = By.XPath("//div//input[@formcontrolname='Email']");
        By currentpassword = By.XPath("//div//input[@formcontrolname='password']");
        By address = By.XPath("//div//input[@formcontrolname='address']");
        By username = By.XPath("//div//input[@formcontrolname='username']");
        By newpassword = By.XPath("//div//input[@formcontrolname='curenrpassword']");
        By updatebutton = By.XPath("//div//button[text()='Update']");

        public void ClickProfileButton()
        {
            CommonMethods.WaitAndFindElement(profilebutton).Click();
        }

        public void EnterFullName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(fullname);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterPhoneNumber(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(phonenumber);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterCurrentPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(currentpassword);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterAdress(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(address);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterUsername(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(username);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterNewPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(newpassword);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickUpdateButton()
        {
            CommonMethods.WaitAndFindElement(updatebutton).Click();
        }
    }
}