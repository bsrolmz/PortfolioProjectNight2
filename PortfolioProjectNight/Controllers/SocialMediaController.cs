using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities context= new DbMyPortfolioNightEntities();   
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }
        public ActionResult ChangeSocialMediaStatusToTrue(int id)
        {
            var value = context.SocialMedia.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult ChangeSocialMediaStatusToFalse(int id)
        {
            var value = context.SocialMedia.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            var value = context.SocialMedia.Find(socialmedia.SocialMediaId);
            value.Title = socialmedia.Title;
            value.Url = socialmedia.Url;
            value.Icon = socialmedia.Icon;
            value.Status = socialmedia.Status;  
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialmedia)
        {
            var values = context.SocialMedia.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}