﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories) {

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

        public AddCheeseViewModel()
        {

        }

    }
}