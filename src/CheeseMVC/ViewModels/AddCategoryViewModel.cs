using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "You must give your category a name.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
