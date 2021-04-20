using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Velo.Models;

namespace Velo.Controllers
{
    public class VeloController : Controller
    {
        // GET: Velo
        public ActionResult Index(ACCOUNT acc)
        {
            return View(acc);
        }

        public ActionResult Recent()
        {
            return PartialView();
        }

        public ActionResult Message()
        {
            return PartialView();
        }

        public ActionResult Notification()
        {
            return PartialView();
        }

        public ActionResult Chat()
        {
            return PartialView();
        }

        public ActionResult Photos(string id)
        {
            var db = new MyDB();
            var accs = db.ACCOUNTs.Where(r=> r.ID_User != id).ToList<ACCOUNT>();
            return PartialView(accs);
        }

        public ActionResult Error()
        {
            return PartialView();
        }

        // GET: Velo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Velo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Velo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Velo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Velo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Velo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Velo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
