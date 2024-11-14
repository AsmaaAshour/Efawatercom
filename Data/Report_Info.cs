using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfawatercomProject.Data
{
    public class Report_Info
    {
        public Report_Info()
        {
        }


        public Report_Info(DateTime startdate,DateTime enddate) 
        {
            this.startdate = startdate;
            this.enddate = enddate;
        }

       public DateTime startdate { set; get; }
       public DateTime enddate { set; get; }
    }
}