using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Data
{
    public class Category_Info
    {
        public Category_Info()
        {
        }

        public Category_Info(string name, string picture, string email, string location,
                   string deducted)
        {
            this.name = name;
            this.picture = picture;
            this.email = email;
            this.location = location;
            this.deducted = deducted;
        }

        public string name { get; set; }
        public string picture { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string deducted { get; set; }
    }
}