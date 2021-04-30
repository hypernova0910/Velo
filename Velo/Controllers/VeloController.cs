using System;
using System.Collections.Generic;
using System.IO;
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
            MyDB db = new MyDB();
            List<PHOTO> pics = db.Photos.Where(r => r.ID_User == acc.ID_User).Take(1).ToList<PHOTO>();
            if (pics.Count != 0)
            {
                PHOTO pic = pics[0];
                ViewBag.Link = pic.Link;
            }
            else
                ViewBag.Link = "";
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
        public ActionResult Edit(string id)
        {
            var con = new MyDB();
            var acc = con.ACCOUNTs.Where(r => r.ID_User == id).FirstOrDefault();
            PHOTO pic = con.Photos.Where(a => a.ID_User == id).FirstOrDefault();
            ViewBag.URL = pic.Link;
            return PartialView(acc);
        }

        // POST: Velo/Edit/5
        [HttpPost]
        public ActionResult Edit(ACCOUNT acc, PHOTO pic)
        {
            MyDB con = new MyDB();
            try
            {
                if (String.IsNullOrEmpty(acc.Account_ID) || String.IsNullOrEmpty(acc.Pass) || String.IsNullOrEmpty(acc.Name) || String.IsNullOrEmpty(acc.Email) ||
                    String.IsNullOrEmpty(acc.Gender) || String.IsNullOrEmpty(acc.Nationality) || String.IsNullOrEmpty(acc.Hobby))
                {
                    ViewBag.Error3 = "Thông tin chưa đầy đủ";
                    return PartialView("Edit", acc);
                }
                else
                {
                    var model = con.ACCOUNTs.Find(acc.ID_User);
                    model.Email = acc.Email;
                    model.DateOfBirth = acc.DateOfBirth;
                    model.Nationality = acc.Nationality;
                    model.Hobby = acc.Hobby;
                    model.Gender = acc.Gender;
                    model.Pass = acc.Pass;
                }

                if (pic.ImageUpload != null)
                {
                    PHOTO picNew = con.Photos.Where(r => r.ID_User == acc.ID_User).FirstOrDefault();
                    string fileName = Path.GetFileNameWithoutExtension(pic.ImageUpload.FileName);
                    string extension = Path.GetExtension(pic.ImageUpload.FileName);
                    fileName = fileName + extension;
                    picNew.Link = "/assets/img/" + fileName;
                    picNew.ImageUpload = pic.ImageUpload;
                    picNew.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/assets/img/"), fileName));
                    picNew.isAvatar = true;
                    picNew.Time_added = DateTime.Now;
                }

                con.SaveChanges();
                return RedirectToAction("Index", acc);
            }
            catch
            {
                return View("Index", acc);
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
