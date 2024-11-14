using EfawatercomProject.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.POM
{
    public class CategoryPage
    {
        IWebDriver _driver;

        public CategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By categorybutton = By.XPath("//div/button[contains(text(), 'Create Category Name')]");
        By name = By.XPath("//input[@formcontrolname='billercategoryname']");
        By picture = By.XPath("//input[@formcontrolname='Pictuer']");
        By email = By.XPath("//input[@formcontrolname='Email']");
        By location = By.XPath("//input[@formcontrolname='Location']");
        By deducted = By.XPath("//input[@formcontrolname='deducted']");
        By createbutton = By.XPath("//div/button[text()='Create']");


        public  void ClickCatecoryButton()
        {
            CommonMethods.WaitAndFindElement(categorybutton).Click();
        }

        public void EnterName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(name);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterPicture(string value)
        {
            CommonMethods.WaitAndFindElement(picture).SendKeys(value);
        }

        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterLocation(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(location);
            CommonMethods.HighlightElement(element);
            element.SendKeys(value);
        }

        public void EnterDeducted(string value)
        {
             CommonMethods.WaitAndFindElement(deducted).SendKeys(value);
        }

        public void ClickCreateButton()
        {
            CommonMethods.WaitAndFindElement(createbutton).Click();
        }
    }
}