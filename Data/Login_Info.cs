using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Data
{
    public class Login_Info
    {
        public Login_Info()
        {
        }


        public Login_Info(string username,string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { set; get; }
        public string password { set; get; }
    }
}