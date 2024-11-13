﻿using Luky_Web.Data;
using Luky_Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Luky_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicaionDbContext _context;
        public CategoryController(ApplicaionDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
           
        }
        List<Category> categories=new List<Category>();
        public IActionResult Index()
        {
           categories =_context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name==category.DisplayOrder.ToString())
            {
                ModelState.AddModelError ("Name", "The Name Cannot exactly match the Display order");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
