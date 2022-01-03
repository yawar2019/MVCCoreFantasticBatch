using Microsoft.AspNetCore.Mvc;
using MVCCoreFantasticBatch.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //param.Add("@Web_PWORD", pwd.IPAddress); 
             var passwordModel = con.QuerySingle<PasswordModel>("usp_Login",param:param, commandType: CommandType.StoredProcedure);
            if (passwordModel!=null)
            {
                if(passwordModel.WEB_YN=="Y")
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.Name, passwordModel.P_USER));
                    claims.Add(new Claim(ClaimTypes.Sid, passwordModel.P_NO.ToString()));
 

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.
            AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var props = new AuthenticationProperties();
                    props.IsPersistent = false;// model.RememberMe;

                    HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.
            AuthenticationScheme,
                        principal, props).Wait();
                    return RedirectToAction("Dashboard");
                }
            }        

            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            var pno="";
             foreach (var item in HttpContext.User.Claims)
            {
                  pno = item.Value.ToString(); 
            }
            var param = new DynamicParameters();
            param.Add("@pno", Convert.ToInt32(pno));
            var Ipaddress = con.Query<IPAddressModel>("usp_GetIpByPNO", param: param, commandType: CommandType.StoredProcedure).ToList();
           
            ViewBag.Ipaddress = new SelectList(Ipaddress, "Ipaddress", "Location");

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Dashboard(IPAddressModel Ipdet)
        {
            
            var param = new DynamicParameters();
            param.Add("@Ipaddress", Ipdet.Ipaddress);
            var Ipaddressdet = con.QuerySingle<IPAddressModel>("[usp_GetDbConnectionByIpaddress]", param: param, commandType: CommandType.StoredProcedure);

              SqlConnection RemoteConn = new SqlConnection(@"Data Source="+ Ipdet.Ipaddress + ";Initial catalog=eTill;User Id=" + Ipaddressdet.UserName + ";Password=" + Ipaddressdet.Pwd + "");
            var result = RemoteConn.Query("Select * from Section1");

            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(
CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
