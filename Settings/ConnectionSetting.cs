using System;

namespace Settings
{
    public  class ConnectionSetting
    {
        static string ConnectionStringName = @"Data Source=AZAM-PC\SQLEXPRESS;Initial catalog=eTill;Integrated Security=true";
        string RemoteConnectionString = string.Empty;
        public static string GetConnectionString()
        {
            return ConnectionStringName;
        }

        public static string GetRemoteConnectionString(string IpAddress,string UserId,string Password)
        {
            string RemoteConnectionString = @"Data Source="+ IpAddress + ";Initial Catalog=eTill;User Id=" + UserId + ";Password="+ Password + "";
            return RemoteConnectionString;
        }

    }
}
