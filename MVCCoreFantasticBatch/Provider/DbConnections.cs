using MVCCoreFantasticBatch.Models;
using Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreFantasticBatch.Provider
{
    public static class DbConnections
    {
        public static string ConnectionString = ConnectionSetting.GetConnectionString();
        public static string GetRemoteConnected(IPAddressModel Ip)
        {
            string RemoteConnectionString = ConnectionSetting.GetRemoteConnectionString(Ip.IPAddress, Ip.UserName, Ip.Pwd);
            return RemoteConnectionString;
        }

    }
}
