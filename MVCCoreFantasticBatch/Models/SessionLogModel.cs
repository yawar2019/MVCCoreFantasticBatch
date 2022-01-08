using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreFantasticBatch.Models
{
    public class SessionLogModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time  { get; set; }
        public bool LoginOut  { get; set; }
        public string Location  { get; set; }
        public string IpAddressFrom { get; set; }
        public string IpAddressTo { get; set; }
        public string DeviceId  { get; set; }
        public string UserId  { get; set; }
        public string UserName { get; set; }
    }               
}
