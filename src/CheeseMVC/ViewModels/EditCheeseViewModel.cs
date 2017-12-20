using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel
    {
        [Required(ErrorMessage = "You must give your cheese a name.")]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description.")]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public int CheeseId { get; set; }

        public EditCheeseViewModel(IEnumerable<CheeseCategory> categories, Cheese editCheese)
        {
            Name = editCheese.Name;
            Description = editCheese.Description;
            Rating = editCheese.Rating;
            CheeseId = editCheese.ID;
            CategoryID = editCheese.CategoryID;

            Categories = new List<SelectListItem>();
            foreach (CheeseCategory item in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = item.ID.ToString(),
                    Text = item.Name
                });
            }

        }

        public EditCheeseViewModel()
        {

        }
    }
}
