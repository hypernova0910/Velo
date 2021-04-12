using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Velo.Models;

namespace Velo.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Velo
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult SignIn(ACCOUNT account)
        {
            using(var dbCtx = new MyDB())
            {
                SqlParameter[] param =
                {
                    new SqlParameter{ParameterName = "email", Value = account.Email},
                    new SqlParameter{ParameterName = "pass", Value = account.Pass}
                };
                List<ACCOUNT> accs = dbCtx.ACCOUNTs.SqlQuery("SELECT * FROM ACCOUNT WHERE Email = @email AND Pass = @pass", param).ToList();
                if(accs.Count == 0)
                {
                    ViewBag.Error = "Sai email hoặc mật khẩu";
                    return View("Index");
                }
                else
                {
                    ACCOUNT acc = accs[0];
                    return RedirectToAction("Index", "Velo", acc);
                }
            }
        }
    }
}