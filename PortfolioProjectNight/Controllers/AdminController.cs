using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class AdminController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {

            return PartialView();
        }
        public PartialViewResult PartialSidebar()
        {
            ViewBag.ImageUrl = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}