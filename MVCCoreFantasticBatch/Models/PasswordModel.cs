using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreFantasticBatch.Models
{
    public class PasswordModel
    {
        public int P_NO { get; set; }
        public string P_USER { get; set; }
        public string P_CODE { get; set; }
        public int P_LEVEL { get; set; }
        public string WEB_YN { get; set; }
        public string WEB_PWORD { get; set; }
        public string IPAddress { get; set; }
    }

    public class IPAddressModel
    {
        public int IPid { get; set; }
        public string Ipaddress { get; set; }
        public string Pwd { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
         
    }
}
