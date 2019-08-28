using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcPRJ.Models;

namespace mvcPRJ.Controllers
{
    public class AccountController : Controller
    {
        private const string V = " Registred Successfuly";

        // GET: Account
        public ActionResult Index()
        {   
            using (OurDbContext db = new OurDbContext())
           { 
             return View(db.UserAccount.ToList());
            }
        }

        public ActionResult Register()
            {
            return View();
             }

        [HttpPost]
        public ActionResult Register(UserAccount account)
            {
            if(ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    { db.UserAccount.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                ViewBag.Message= account.FirstName + "  " + account.LastName + V;
                 }
            return View();
}
        //Login
        public ActionResult Login()
            { 
              return View();
            }
         
        [HttpPost]
        public ActionResult Login(UserAccount user)
            {
                  using (OurDbContext db  = new OurDbContext())
                  {
                       var usr = db.UserAccount.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                      if(usr != null)
                      {
                          Session["UserID"]=usr.UserID.ToString();
                          Session["UserName"]= usr.UserName.ToString();
                          return RedirectToAction("LoggedIn");
                       }
                      else
                       {
                           NewMethod();
                       }
                
                  }   
                  return View();   
             }

        private void NewMethod()
        {
            ModelState.AddModelError(key: "", errorMessage: "Username or Password is invalid try again.");
        }

        public ActionResult LoggedIn()
            {
               if(Session["UserId"]!=null)
                {   return  View(); }
               else {return RedirectToAction("Login");}
            }
    }
}