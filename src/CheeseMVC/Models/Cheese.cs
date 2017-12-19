using System.Collections.Generic;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int ID { get; set; }

        public int CategoryID { get; set; }  //This represents the 'foreign key' that allows us to relate each cheese to a category.
        public CheeseCategory Category { get; set; } //Navigation property corresponding to the foreign key.

        public IList<CheeseMenu> CheeseMenus = new List<CheeseMenu>();
    }
}
