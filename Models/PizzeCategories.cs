using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Models
{
    public class PizzeCategories
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        //action [post] la lista dei tag che vengono selezionati dall'utente
        public List<int> SelectedTags { get; set; }

        public PizzeCategories()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
            SelectedTags = new List<int>();
        }
    }
}
