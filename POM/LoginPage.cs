using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.POM
{
    public class LoginPage
    {
        IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By username = By.XPath("//form/input[@type='email']");
        By password = By.XPath("//form/input[@type='password']");
        By signinButton = By.XPath("//form/button[contains(text(), 'SIGN IN')]");

        public void EnterUsername(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(username);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(password);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void ClickSigninButton()
        {
            CommonMethods.WaitAndFindElement(signinButton).Click();
        }
    }
}