using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SettingsController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();    
        public ActionResult Settings()
        {
            var value = context.Admin.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateSettings(int id)
        {
            var value = context.Admin.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSettings(Admin admin)
        {
            var value = context.Admin.Find(admin.AdminId);
            value.NameSurname = admin.NameSurname;
            value.Email = admin.Email;
            value.Phone = admin.Phone;
            value.UserName = admin.UserName;
            value.Password = admin.Password;
            context.SaveChanges();
            return RedirectToAction("Settings");
        }
    }
}