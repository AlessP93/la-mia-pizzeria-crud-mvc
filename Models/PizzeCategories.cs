using la_mia_pizzeria.Models;

namespace la_mia_pizzeria_static.Models
{
    public class PizzeCategories
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }

        public PizzeCategories()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
        }
    }
}
