using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult Chart()
        {
            var skills = context.Skill.ToList();

            var skillNames = skills.Select(s => s.SkillName).ToList();
            var skillRates = skills.Select(s => s.Rate).ToList();

            ViewBag.SkillNames = skillNames;
            ViewBag.SkillRates = skillRates;

            return View();
        }

        
    }
}
