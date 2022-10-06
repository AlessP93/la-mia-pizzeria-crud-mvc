using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace la_mia_pizzeria.Controllers
{
	public class PizzaController : Controller
	{
		// GET: PizzaController
		 public ActionResult Index()
		{
   //         List<Pizza> pizzaRosse = new List<Pizza>();

   //         pizzaRosse.Add(new Pizza("Margherita", "Mozzarella e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 8));
   //         pizzaRosse.Add(new Pizza("Napoli", "Alici e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
   //         pizzaRosse.Add(new Pizza("Capricciosa", "Uova e carciofi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 10));

   //         List<Pizza> pizzaBianche = new List<Pizza>();

   //         pizzaBianche.Add(new Pizza("Quattro Formaggi", "Mix formaggi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 6));
   //         pizzaBianche.Add(new Pizza("Funghi", "Porcini e mozzarella", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
   //         pizzaBianche.Add(new Pizza("Bresaola", "Rucola e bresaola", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 12));

   //         MenuPizze mp = new MenuPizze();

			//mp.Bianche = pizzaBianche;
			//mp.Rosse = pizzaRosse;

            //return View(mp);

            using (PizzeriaContext context = new PizzeriaContext())
            {
                //MI RECUPERO DAL CONTEXT LA LISTA DELLE PIZZE
                IQueryable<Pizza> pizza = context.Pizza;
                //E LI PASSO ALLA VISTA
                return View("Index", pizza.ToList());
            }

        }

		// GET: PizzaController/Details/5
		public ActionResult Details(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                //FACCIO RICHIESTA DELLE PIZZE ANDANDO A SELEZIONARE LA PIZZA SPECIFICA
                //pizzaFound e' LINQ (questa e' la method syntax)
                Pizza pizzaFound = context.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();
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
		public ActionResult Create()
		{
			return View();
		}

		// POST: PizzaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Pizza formData)
		{
			
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

			PizzeriaContext db = new PizzeriaContext();
			db.Pizza.Add(formData);
			db.SaveChanges();
           
            return RedirectToAction("Index");
        }

		// GET: PizzaController/Edit/5
		public ActionResult Edit(int id)
		{
			PizzeriaContext db = new PizzeriaContext();
			Pizza pizza = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

            return View(pizza);
            
		}
		
		// POST: PizzaController/Edit/5
		[HttpPost]

		public ActionResult Edit(int id, Pizza formData) {

			PizzeriaContext db = new PizzeriaContext();
            Pizza pizza = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

            pizza.Nome = formData.Nome;
			pizza.Description = formData.Description;
			pizza.Pic = formData.Pic;
			pizza.Price = formData.Price;

			db.SaveChanges();

			return RedirectToAction("Index");
		}

		// POST: PizzaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
            PizzeriaContext db = new PizzeriaContext();
            Pizza pizza = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

			if (pizza == null)
			{
				return NotFound();
			}
			else
			{
				db.Pizza.Remove(pizza);
				db.SaveChanges();
			}
            return RedirectToAction("Index");
        }
	}
}
