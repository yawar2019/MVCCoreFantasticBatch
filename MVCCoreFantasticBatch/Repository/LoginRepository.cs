using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MVCCoreFantasticBatch.Models;
using MVCCoreFantasticBatch.Provider;
using Settings;

namespace MVCCoreFantasticBatch.Repository
{
    public class LoginRepository : ConnectionSetting
    {

        static string ConnectionString = DbConnections.ConnectionString;
        SqlConnection primarycon = new SqlConnection(ConnectionString);


        public static string remoteConnectionString;
        SqlConnection RemoteCon = new SqlConnection(remoteConnectionString);


        public static string GetRemoteConnected(IPAddressModel Ipdet)
        {
            remoteConnectionString = DbConnections.GetRemoteConnected(Ipdet);
            return remoteConnectionString;
        }

        ///Repository code Started

        public PasswordModel getUserLogin(PasswordModel pwd)
        {
            var param = new DynamicParameters();
            param.Add("@p_no", pwd.P_NO);
            param.Add("@Web_PWORD", pwd.WEB_PWORD);
            var passwordModel = primarycon.QuerySingle<PasswordModel>("usp_Login", param: param, commandType: CommandType.StoredProcedure);
            return passwordModel;
        }

        public IPAddressModel GetAllIpAddress(IPAddressModel Ipdet)
        {
            var param = new DynamicParameters();
            param.Add("@Ipaddress", Ipdet.IpAddress);
            var Ipaddressdet = primarycon.QuerySingle<IPAddressModel>("[usp_GetDbConnectionByIpaddress]", param: param, commandType: CommandType.StoredProcedure);
            return Ipaddressdet;
        }

        public List<IPAddressModel> GetIpAddressByPno(int pno)
        {
            var param = new DynamicParameters();
            param.Add("@pno", Convert.ToInt32(pno));
            var Ipaddress = primarycon.Query<IPAddressModel>("usp_GetIpByPNO", param: param, commandType: CommandType.StoredProcedure).ToList();
            return Ipaddress;
        }



        public   List<Section> GetSection1()
        { 
             var Sectiondet = RemoteCon.Query<Section>("SectionProc1", commandType: CommandType.StoredProcedure).ToList();
            return Sectiondet;
        }
    }
}
