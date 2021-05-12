using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Velo.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public AuthController()
        {
            if (System.Web.HttpContext.Current.Session["AccountLogin"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect(String.Format("~/Welcome/Index"));
            }
        }
    }
}