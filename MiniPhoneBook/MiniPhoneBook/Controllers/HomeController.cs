using MiniPhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniPhoneBook.Controllers
{
    public class HomeController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["PhoneBookDbEntities"].ConnectionString;
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();

        }
        public ActionResult Create(ASPNetUsers collection)
        {
            try
            {
                // Do not initialize this variable here. 
                AspNetUser obj = new AspNetUser();
                obj.Id = collection.Id;
                obj.Email = collection.Email;
                obj.EmailConfirmed = collection.EmailConfirmed;
                obj.PasswordHash = collection.PasswordHash;
                obj.PhoneNumberConfirmed = collection.PhoneNumberConfirmed;
                obj.TwoFactorEnabled = collection.TwoFactorEnabled;
                obj.LockoutEndDateUtc = collection.LockoutEndDateUtc;
                obj.LockoutEnabled = collection.LockoutEnabled;
                obj.AccessFailedCount = collection.AccessFailedCount;
                obj.UserName = collection.UserName;
                
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.AspNetUsers.Add(obj);
                db.SaveChanges();

                

            }
            catch (Exception ex)
            {
                return View("Not done", new HandleErrorInfo(ex, "collection", "Create"));
            }
            return RedirectToAction("Index");
        }

        public ActionResult DashBoard()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Person()
        {
            return View();
        }

    }
}