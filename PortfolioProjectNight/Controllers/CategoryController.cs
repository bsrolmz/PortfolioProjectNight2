﻿using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class CategoryController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        public ActionResult CategoryList()
        {
            var values = context.Category.ToList();
            return View(values);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            var values=context.Category.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            var values = context.Category.Find(id);
            context.Category.Remove(values);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public ActionResult UpdateCategory(int id)
        {
            var value=context.Category.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Category.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
            
        }
    }
}

