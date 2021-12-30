using Microsoft.AspNetCore.Mvc;
using MVCCoreFantasticBatch.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace MVCCoreFantasticBatch.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=AZAM-PC\SQLEXPRESS;Initial catalog=eTill;Integrated Security=true");

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(PasswordModel pwd)
        {
            var param = new DynamicParameters();
            param.Add("@p_no", pwd.P_NO);
            param.Add("@Web_PWORD", pwd.WEB_PWORD);
            var passwordModel = con.QuerySingle<PasswordModel>("usp_Login",param:param, commandType: CommandType.StoredProcedure);
            if (passwordModel!=null)
            {
                if(passwordModel.WEB_YN=="Y")
                {
                    return View("Dashboard");
                }
            }        

            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
