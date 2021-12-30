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
    }
}
