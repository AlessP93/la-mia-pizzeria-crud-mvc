
using la_mia_pizzeria.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace la_mia_pizzeria.Controllers

{
	public class PizzaController : Controller
	{
        //db nel genitore
        PizzeriaContext db = new PizzeriaContext();


        // GET: PizzaController -------------------- MOSTRA SOLO DATI
        public ActionResult Index()
		{
 
            using (PizzeriaContext context = new PizzeriaContext())
			{
             
                //MI RECUPERO DAL CONTEXT LA LISTA DELLE PIZZE CHE INCLUDONO LE CATEGORY

                //passami una lista di pizze 
                List<Pizza> pizza = context.Pizzas.Include("Category").ToList();
                //E LI PASSO ALLA VISTA
                return View("Index", pizza);
            }

        }

        // GET: PizzaController/Details/5 ------------- MOSTRA SOLO DATI SINGOLI
        public ActionResult Details(int id)//SHOW
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                //FACCIO RICHIESTA DELLE PIZZE ANDANDO A SELEZIONARE LA PIZZA SPECIFICA
                //pizzaFound e' LINQ (questa e' la method syntax)

                Pizza pizzaFound = context.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.Id == id).FirstOrDefault();

                //SE IL POST NON VIENE TROVATO
                if (pizzaFound == null)
                {
                    return NotFound($"La pizza con id {id} non è stato trovata");
                }
                else //ALTRIMENTI VIENE PASSATO ALLA VISTA DI DETTAGLIO CON PIZZAFOUND
                {
                    return View("Details", pizzaFound);
                }
            }
        }

		// GET: PizzaController/Create
		public IActionResult Create()
		{
			PizzeCategories pizzeCategories = new PizzeCategories(); //accesso ai dati del modello pizzecategories

			pizzeCategories.Categories = new PizzeriaContext().Categories.ToList();
            pizzeCategories.Ingredients = new PizzeriaContext().Ingredients.ToList();

			return View(pizzeCategories);
		}

		// POST: PizzaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		                               //classe e parametro 
		public ActionResult Create(PizzeCategories formData)
		{
            //PizzeriaContext db = new PizzeriaContext();
            if (!ModelState.IsValid)
            {
                formData.Categories = db.Categories.ToList();
                formData.Ingredients = db.Ingredients.ToList();
                return View("Create", formData);
            }
                                        //new = nuova lista di ingredienti  ( con modello Ingredient )
            formData.Pizza.Ingredients = new List<Ingredient>();

            db.Pizzas.Add(formData.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

		// GET: PizzaController/Edit/5
		public ActionResult Edit(int id)
		{
			using (PizzeriaContext contesto = new PizzeriaContext())
			{
				Pizza pizzaEditata = contesto.Pizzas.Include("Category").Include("Ingredients").Where(pizza => pizza.Id == id).FirstOrDefault();

				if (pizzaEditata == null)
				{
                    return NotFound();
                }

				PizzeCategories pizzeCategories = new PizzeCategories();

				pizzeCategories.Pizza = pizzaEditata;
				pizzeCategories.Categories = contesto.Categories.ToList();
                pizzeCategories.Ingredients = contesto.Ingredients.ToList();

                return View(pizzeCategories);
            }
			//PizzeriaContext db = new PizzeriaContext();
			//Pizzas pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

   //         return View(pizza);
            
		}
		
		// POST: PizzaController/Edit/5
		[HttpPost]

		public ActionResult Edit(int id, PizzeCategories formData) {

            using (PizzeriaContext contesto = new PizzeriaContext())
            {
               
                if (!ModelState.IsValid)
                {
					formData.Categories = contesto.Categories.ToList();
                    formData.Ingredients = contesto.Ingredients.ToList();
                    return View("Edit", formData);
                }

				formData.Pizza.Id = id;
				contesto.Pizzas.Update(formData.Pizza);

				contesto.SaveChanges();

                return RedirectToAction("Index");
            }
            //PizzeriaContext db = new PizzeriaContext();
            //         Pizzas pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            //         pizza.Nome = formData.Nome;
            //pizza.Description = formData.Description;
            //pizza.Pic = formData.Pic;
            //pizza.Price = formData.Price;

            //db.SaveChanges();
           
		}

		// POST: PizzaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
            using (PizzeriaContext contesto = new PizzeriaContext())
            {
                Pizza pizzaDaEliminare = contesto.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaEliminare != null)
                {
                    contesto.Pizzas.Remove(pizzaDaEliminare);

                    contesto.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            //         PizzeriaContext db = new PizzeriaContext();
            //         Pizzas pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            //if (pizza == null)
            //{
            //	return NotFound();
            //}
            //else
            //{
            //	db.Pizzas.Remove(pizza);
            //	db.SaveChanges();
            //}
            //         return RedirectToAction("Index");
        }
	}
}
