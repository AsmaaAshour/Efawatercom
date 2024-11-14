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
    public class Profile_AssistantMethods
    {
        public static void FillProfileForm(Profile_Info profile_info)
        {

            ProfilePage profilepage = new ProfilePage(ManageDriver.driver);

            profilepage.ClickProfileButton();

            profilepage.EnterFullName(profile_info.fullname);
            profilepage.EnterPhoneNumber(profile_info.phonenumber);
            profilepage.EnterEmail(profile_info.email);
            profilepage.EnterCurrentPassword(profile_info.currentpassword);
            profilepage.EnterAdress(profile_info.address);
            profilepage.EnterUsername(profile_info.username);

            profilepage.ClickUpdateButton();
        }


        public static Profile_Info ReadProfileInfoFromExcel(int row)
        {

            Profile_Info profile_info = new Profile_Info();

            Worksheet worksheet = CommonMethods.ReadExcel("Profile");

            profile_info.fullname = Convert.ToString(worksheet.Cell(row, 1).Value);

            profile_info.phonenumber = Convert.ToString(worksheet.Cell(row, 2).Value);

            profile_info.email = Convert.ToString(worksheet.Cell(row, 3).Value);

            profile_info.currentpassword = Convert.ToString(worksheet.Cell(row, 4).Value);

            profile_info.address = Convert.ToString(worksheet.Cell(row, 5).Value);

            profile_info.username = Convert.ToString(worksheet.Cell(row, 6).Value);


            return profile_info;
        }
    }
}