using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    //CLASSE PIZZA
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(25, ErrorMessage = "Il nome non può essere maggiore di 25 caratteri")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nome non può essere maggiore di 100 caratteri")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Pic { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0, 15, ErrorMessage = "Il prezzo non è valido")]
        public float Price { get; set; }

        // ? potrebbe essere null
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient>? Ingredients { get; set; }


        //COSTRUTTORE VUOTO
        public Pizza()
        {

        }

        //COSTRUTTORE
        public Pizza(string nome, string description, string pic, float price)
        {
            Nome = nome;
            Description = description;
            Pic = pic;
            Price = price;
        }
    }
}
