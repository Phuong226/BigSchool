using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbConText;
        public CoursesController()
        {
            _dbConText = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbConText.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories= _dbConText.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerID = User.Identity.GetUserId(),    
                DateTime = viewModel.GetDateTime(),
                CategoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbConText.Courses.Add(course);
            _dbConText.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}