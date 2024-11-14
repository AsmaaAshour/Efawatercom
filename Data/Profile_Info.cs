using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Data
{
    public class Profile_Info
    {
        public Profile_Info()
        {
        }


        public Profile_Info(String fullname, String phonenumber, string email,
         string currentpassword, string address, String username)
        {
            this.fullname = fullname;
            this.phonenumber = phonenumber;
            this.email = email;
            this.currentpassword = currentpassword;
            this.address = address;
            this.username = username;
        }

        public string fullname { set; get; }
        public string phonenumber { set; get; }
        public string email { set; get; }
        public string currentpassword { set; get; }
        public string address { set; get; }
        public string username { set; get; }
        public string newpassword { set; get; }
    }
}