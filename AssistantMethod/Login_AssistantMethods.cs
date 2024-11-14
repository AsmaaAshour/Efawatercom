using Bytescout.Spreadsheet;
using EfawatercomProject.Data;
using EfawatercomProject.Helpers;
using EfawatercomProject.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.AssistantMethod
{
    public class Login_AssistantMethods
    {
        public static void FillLoginForm(Login_Info login_Info)
        {
            LoginPage loginPage = new LoginPage(ManageDriver.driver);

            loginPage.EnterUsername(login_Info.username);
            loginPage.EnterPassword(login_Info.password);
            loginPage.ClickSigninButton();
        }


        public static Login_Info ReadLoginDataFromExcel(int row)
        {
            Login_Info login_info = new Login_Info();

            Worksheet worksheet = CommonMethods.ReadExcel("Login");

            login_info.username = Convert.ToString(worksheet.Cell(row, 1).Value);

            login_info.password = Convert.ToString(worksheet.Cell(row, 2).Value);

            return login_info;
        }
    }
}