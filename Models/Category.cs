using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // inserisco la lista delle pizze
        public List<Pizza> Pizza { get; set; }

        public Category()
        {
            
        }
    }
}