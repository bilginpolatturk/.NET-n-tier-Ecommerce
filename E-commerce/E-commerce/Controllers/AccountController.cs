using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace E_commerce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        DataContext dataContext = new DataContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgiler = dataContext.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);

            if (bilgiler != null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);

                Session["Mail"] = bilgiler.Email.ToString();
                Session["Name"] = bilgiler.Name.ToString();
                Session["Surname"] = bilgiler.SurName.ToString();
                Session["userid"] = bilgiler.Id.ToString();
                Session["username"] = bilgiler.Name.ToString();
                return RedirectToAction("Index", "Home");

            }




            ViewBag.Hata = "Wrong username or password";
            return View(data);
        }

        [HttpPost]

        public ActionResult Register(User data)
        {
            if (ModelState.IsValid)
            {
                dataContext.Users.Add(data);
                data.Role = "User";

                dataContext.SaveChanges();

                ViewBag.register = "Register success.";
                return RedirectToAction("Login");
            }
            return View("Login", data);

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Name");

            return RedirectToAction("Index", "Home");
        }
        public ActionResult SifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreReset(string Email)
        {
            var mail = dataContext.Users.Where(x => x.Email == Email).SingleOrDefault();

            if (mail != null)
            {
                Random rnd = new Random();
                int newpass = rnd.Next();
                User sifre = new User();
                mail.Password = (Convert.ToString(newpass));
                dataContext.SaveChanges();
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "test@gmail.com";
                WebMail.Password = "test12345";
                WebMail.SmtpPort = 587;
                WebMail.Send(Email, "your password", "Password:" + newpass);
                ViewBag.uyari = "Password sent";
            }
            else
            {
                ViewBag.uyari = "Error while sending passsword!";
            }





            return View();
        }
    }
}
