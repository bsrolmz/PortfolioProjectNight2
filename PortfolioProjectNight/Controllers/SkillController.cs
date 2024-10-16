using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SkillList(int p=1)
        {
            var values = context.Skill.ToList().ToPagedList(p,5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            var values = context.Skill.Add(skill);
            ViewBag.rate = skill.Rate;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value= context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context. Skill.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;  
            value.Rate = skill.Rate;   
            value.Icon = skill.Icon;    
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}