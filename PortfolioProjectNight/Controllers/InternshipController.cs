using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class InternshipController : Controller
    {
       DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();
            return View(values);
        }

        public ActionResult DeleteInternship(int id)
        {
            var values = context.Internship.Find(id);
            context.Internship.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        public ActionResult UpdateInternship(int id)
        {
            var values=context.Internship.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInternship(Internship internship)
        {
            var values = context.Internship.Find(internship.InternshipId);
            values.Title = internship.Title;
            values.SubTitle = internship.SubTitle;
            values.Description= internship.Description; 
            values.Date = internship.Date;
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternship(Internship internship)
        {
            var values = context.Internship.Add(internship);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
    }
}