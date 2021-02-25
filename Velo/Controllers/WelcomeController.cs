using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Velo.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Velo
        public ActionResult Index()
        {
            return View();
        }
    }
}