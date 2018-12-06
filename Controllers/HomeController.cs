using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Crudelicious.Models;
using System.Linq;


namespace Crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private CrudeliciousContext dbContext;

        public HomeController(CrudeliciousContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dishes> AllDishes = dbContext.Dishes.ToList();
            return View(AllDishes);
        }

        [HttpGet("ShowAddNewDish")]
        public IActionResult ShowAddNewDish()
        {
            return View();
        }

        [HttpPost("CreateDish")]
        public IActionResult CreateDish(Dishes Dishes)
        {

            
            if (ModelState.IsValid)
            {
                dbContext.Add(Dishes);
                dbContext.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {

                return View("ShowAddNewDish");
            };
 
            }
        [HttpGet("/show/{id}")]
        public IActionResult ViewSingleDish(int id)
        {
            
            Dishes DishToShow = dbContext.Dishes.FirstOrDefault(a => a.Id == id);
            

            return View(DishToShow);
        }
        [HttpGet("edit/{id}")]
        public IActionResult EditSingleDish(int id)
        {
            Dishes DishToEdit = dbContext.Dishes.FirstOrDefault(a => a.Id == id);
            return View(DishToEdit);

        }   

        [HttpPost("EditDish/{id}")]
        public IActionResult EditDish(Dishes Dish, int id)
        {
            Dishes DishToEdit = dbContext.Dishes.FirstOrDefault(a => a.Id == id);
            
            if(DishToEdit != null)
            {
            DishToEdit.Name = Dish.Name;
            DishToEdit.Chef = Dish.Chef;
            DishToEdit.Calories = Dish.Calories;
            DishToEdit.Description = Dish.Description;
            DishToEdit.Tastiness = Dish.Tastiness;

            dbContext.SaveChanges();
            System.Console.WriteLine($"*!*!*!*!*{DishToEdit.Name}*!*!*!*!*!*!*");

            return RedirectToAction("ViewSingleDish");
            }
            else
            {
                return View();
            }
        }
        [HttpGet("delete/{id}")]
        public IActionResult DeleteDish(int id)
        {
            Dishes DishToDelete = dbContext.Dishes.FirstOrDefault(a => a.Id == id);
            dbContext.Remove(DishToDelete);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
