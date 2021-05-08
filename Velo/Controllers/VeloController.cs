using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            List<PHOTO> pics = db.Photos.Where(r => r.ID_User == acc.ID_User && r.isAvatar == true).Take(1).ToList<PHOTO>();
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

        public ActionResult Message(string id)
        {
            var db = new MyDB();
            ACCOUNT acc = db.ACCOUNTs.Find(id);
            return PartialView(acc.CONVERSATION_DETAIL.ToList());
        }

        public ActionResult Notification()
        {
            return PartialView();
        }

        public ActionResult Chat()
        {
            var db = new MyDB();
            string user_id = Request["user_id"];
            string receiver_id = Request["receiver_id"];
            string conversation_id = Request["conversation_id"];
            SqlParameter senderId = new SqlParameter("@sender_id", user_id);
            SqlParameter receiverId = new SqlParameter("@receiver_id", receiver_id);
            CONVERSATION conversation = new CONVERSATION();
            ViewBag.User_ID = user_id;
            //var receiverId = receiver_id;
            if (string.IsNullOrEmpty(conversation_id))
            {
                conversation_id = db.Database.SqlQuery<string>("getConversation @sender_id, @receiver_id", senderId, receiverId).FirstOrDefault();
                if (string.IsNullOrEmpty(conversation_id))
                {
                    conversation.Conversation_ID = Guid.NewGuid().ToString().Substring(0, 10);
                    ACCOUNT acc = db.ACCOUNTs.Find(user_id);
                    ACCOUNT receiver = db.ACCOUNTs.Find(receiver_id);
                    CONVERSATION_DETAIL chat_detail = new CONVERSATION_DETAIL();
                    chat_detail.Name = receiver.Account_ID;
                    chat_detail.ID_User = user_id;
                    chat_detail.Conversation_ID = conversation.Conversation_ID;
                    CONVERSATION_DETAIL chat_detail2 = new CONVERSATION_DETAIL();
                    chat_detail2.Name = acc.Account_ID;
                    chat_detail2.Conversation_ID = conversation.Conversation_ID;
                    chat_detail2.ID_User = receiver_id;
                    db.CONVERSATIONs.Add(conversation);
                    db.CONVERSATION_DETAIL.Add(chat_detail);
                    db.CONVERSATION_DETAIL.Add(chat_detail2);
                    conversation.CONVERSATION_DETAIL.Add(chat_detail);
                    conversation.CONVERSATION_DETAIL.Add(chat_detail2);
                    db.SaveChanges();
                    //conversation.CONVERSATION_DETAIL.Add(db)
                    return PartialView(conversation);
                }
            }
            conversation = db.CONVERSATIONs.Find(conversation_id);
            return PartialView(conversation);
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
            PHOTO pic = con.Photos.Where(a => a.ID_User == id && a.isAvatar == true).FirstOrDefault();
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
                var model = con.ACCOUNTs.Find(acc.ID_User);
                model.Account_ID = acc.Account_ID;
                model.Name = acc.Name;
                model.Email = acc.Email;
                model.DateOfBirth = acc.DateOfBirth;
                model.Nationality = acc.Nationality;
                model.Hobby = acc.Hobby;
                model.Gender = acc.Gender;
                model.Pass = acc.Pass;

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
        public ActionResult Close(String id)
        {
            var con = new MyDB();
            var acc = con.ACCOUNTs.Where(r => r.ID_User == id).FirstOrDefault();
            return RedirectToAction("Index", acc);
        }
        public ActionResult Upgrade(string id)
        {
            var con = new MyDB();
            var acc = con.ACCOUNTs.Where(r => r.ID_User == id).FirstOrDefault();
            return View(acc);
        }

        [HttpPost]
        public ActionResult Upgrade(FormCollection data)
        {
            string id = data["user_id"];
            using(var con = new MyDB())
            {
                var acc = con.ACCOUNTs.Find(id);
                acc.isVip = true;
                con.SaveChanges();
                return RedirectToAction("Index", acc);
            }
        }
        public ActionResult Community()
        {
            return View();
        }
        public ActionResult CookiePolicy()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
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
