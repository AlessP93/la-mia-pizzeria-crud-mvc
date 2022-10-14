
namespace la_mia_pizzeria.Models
{
    public class PizzeCategories
    {
        public Pizza? Pizza { get; set; }

        public List<Category>? Categories { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        //action [post] la lista degli ingredienti che vengono selezionati dall'utente
        public List<int> SelectedIngredients { get; set; }

        public PizzeCategories()
        {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
            SelectedIngredients = new List<int>();
        }
    }
}
