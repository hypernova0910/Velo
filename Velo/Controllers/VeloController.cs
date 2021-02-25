using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Velo.Controllers
{
    public class VeloController : Controller
    {
        // GET: Velo
        public ActionResult Index()
        {
            return View();
        }
    }
}