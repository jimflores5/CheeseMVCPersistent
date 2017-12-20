using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);

                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category = newCheeseCategory,
                    Rating = addCheeseViewModel.Rating
                };

                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
                
            };

            AddCheeseViewModel redoCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            return View(redoCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            Cheese editCheese = context.Cheeses.Single(c => c.ID == id);
            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel(context.Categories.ToList(),editCheese);
            return View(editCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                Cheese changedCheese = context.Cheeses.Single(c => c.ID == id);
                changedCheese.Name = editCheeseViewModel.Name;
                changedCheese.Description = editCheeseViewModel.Description;
                changedCheese.Rating = editCheeseViewModel.Rating;
                changedCheese.CategoryID = editCheeseViewModel.CategoryID;

                context.Cheeses.Update(changedCheese);
                context.SaveChanges();
                return Redirect("/");
            }

            Cheese redoCheese = context.Cheeses.Single(c => c.ID == id);
            EditCheeseViewModel redoCheeseViewModel = new EditCheeseViewModel(context.Categories.ToList(), redoCheese);
            return View(redoCheeseViewModel);
        }
    }
}
