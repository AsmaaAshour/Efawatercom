using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Data
{
    public class Biller_Info
    {
        public Biller_Info()
        {
        }


        public Biller_Info(string bname, string bemail, string blocation)
        {
            this.bname = bname;
            this.bemail = bemail;
            this.blocation = blocation;
        }

        public string bname { set; get; }
        public string bemail { set; get; }
        public string blocation { set; get; }
    }
}