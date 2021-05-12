﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Velo.Models;

namespace Velo.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Velo
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Error = "";
            ViewBag.Error2 = "";
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection data, PHOTO pic)
        {
            string uid = data["Account_ID"];
            string pass = data["Pass"];
            string pass2 = data["password_confirmation"];
            string name = data["Name"];
            string email = data["Email"];
            string birthday = data["DateOfBirth"];
            string gender = data["Gender"];
            string nationality = data["Nationality"];
            string hobby = data["Hobby"];

            if (String.IsNullOrEmpty(uid) || String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(birthday) ||
                String.IsNullOrEmpty(gender) || String.IsNullOrEmpty(nationality) || String.IsNullOrEmpty(hobby))
            {
                ViewBag.Error2 = "Thông tin chưa đầy đủ";
                return View("Index");
            }
            else if (pass != pass2)
            {
                ViewBag.Error2 = "Mật khẩu không khớp";
                return View("Index");
            }
            else
            {
                using (var db = new MyDB())
                {
                    ACCOUNT acc = new ACCOUNT();
                    acc.ID_User = Guid.NewGuid().ToString().Substring(0, 10);
                    acc.Account_ID = uid;
                    acc.Pass = pass;
                    acc.Name = name;
                    acc.Email = email;
                    acc.DateOfBirth = DateTime.Parse(birthday);
                    acc.Gender = gender;
                    acc.Nationality = nationality;
                    acc.Hobby = hobby;

                    pic.Photo_ID = Guid.NewGuid().ToString().Substring(0, 10);
                    pic.ID_User = acc.ID_User;
                    pic.isAvatar = true;
                    pic.Time_added = DateTime.Now;
                    if (pic.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(pic.ImageUpload.FileName);
                        string extension = Path.GetExtension(pic.ImageUpload.FileName);
                        fileName = fileName + extension;
                        pic.Link = "/assets/img/" + fileName;
                        pic.ImageUpload.SaveAs(Path.Combine(Server.MapPath("/assets/img/"), fileName));
                    }
                    else
                    {
                        pic.Link = "/assets/img/user-icon.png";
                    }  
                    ViewBag.Link = pic.Link;
                    db.ACCOUNTs.Add(acc);
                    db.Photos.Add(pic);
                    db.SaveChanges();
                    Session["AccountLogin"] = acc.ID_User;
                    return RedirectToAction("Index", "Velo", acc);
                }
            }
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
                    Session["AccountLogin"] = acc.ID_User;
                    return RedirectToAction("Index", "Velo", acc);
                }
            }
        }
    }
}