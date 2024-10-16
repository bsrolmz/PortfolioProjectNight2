using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult ServiceList()
        {
            var values = context.Service.ToList();
            return View(values);
        }
        public ActionResult CreateService()
        {
           return View();   
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            var value=context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult DeleteService(int id)
        {
            var value = context.Service.Find(id);
            context.Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult UpdateService(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Service.Find(service.ServiceId);
            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}