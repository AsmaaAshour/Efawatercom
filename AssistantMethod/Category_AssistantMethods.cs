using Bytescout.Spreadsheet;
using EfawatercomProject.Data;
using EfawatercomProject.Helpers;
using EfawatercomProject.POM;
using MongoDB.Driver.Core.Configuration;
using OpenQA.Selenium;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.AssistantMethod
{
    public class Category_AssistantMethods
    {

        public static void FillCategoryForm(Category_Info category_info)
        {

            CategoryPage categoryPage = new CategoryPage(ManageDriver.driver);

            categoryPage.EnterName(category_info.name);
            categoryPage.EnterPicture(category_info.picture);
            categoryPage.EnterEmail(category_info.email);
            categoryPage.EnterLocation(category_info.location);
            categoryPage.EnterDeducted(category_info.deducted);

            categoryPage.ClickCreateButton();
        }


        public static Category_Info ReadCategoryFromExcel(int row)
        {

            Category_Info category_info = new Category_Info();

            Worksheet worksheet = CommonMethods.ReadExcel("Category");

            category_info.name = Convert.ToString(worksheet.Cell(row, 1).Value);

            category_info.picture = Convert.ToString(worksheet.Cell(row, 2).Value);

            category_info.email = Convert.ToString(worksheet.Cell(row, 3).Value);

            category_info.location = Convert.ToString(worksheet.Cell(row, 4).Value);

            category_info.deducted = Convert.ToString(worksheet.Cell(row, 5).Value);

            return category_info;
        }
    }
}