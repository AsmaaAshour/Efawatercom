﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Helpers
{
    public class ManageDriver
    {
        public static IWebDriver driver = new ChromeDriver();

        public static void MaximizeDriver()
        {
            driver.Manage().Window.Maximize();
        }


        public static void CloseDriver()
        {
            driver.Quit();
        }
    }
}