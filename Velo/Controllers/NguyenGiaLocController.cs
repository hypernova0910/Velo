using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Velo.Models;

namespace Velo.Controllers
{
    public class NguyenGiaLocController : Controller
    {
        // GET: NguyenGiaLoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp(FormCollection data)
        {
            using (var db = new MyDB())
            {
                ACCOUNT acc = new ACCOUNT();
                acc.ID_User = Guid.NewGuid().ToString().Substring(0, 10);
                acc.Account_ID = data["Account_ID"];
                acc.Pass = data["Pass"];
                acc.Name = data["Name"];
                acc.Email = data["Email"];
                acc.Gender = data["Gender"];
                acc.Nationality = data["Nationality"];
                acc.Hobby = data["Hobby"];
                db.ACCOUNTs.Add(acc);
                db.SaveChanges();
                return View();
            }
        }
    }
}