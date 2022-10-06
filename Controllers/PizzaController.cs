using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace la_mia_pizzeria.Controllers
{
	public class PizzaController : Controller
	{
		// GET: PizzaController
		public ActionResult Index()
		{
            List<Pizza> pizzaRosse = new List<Pizza>();

            pizzaRosse.Add(new Pizza("Margherita", "Mozzarella e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 8));
            pizzaRosse.Add(new Pizza("Napoli", "Alici e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
            pizzaRosse.Add(new Pizza("Capricciosa", "Uova e carciofi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 10));

            List<Pizza> pizzaBianche = new List<Pizza>();

            pizzaBianche.Add(new Pizza("Quattro Formaggi", "Mix formaggi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 6));
            pizzaBianche.Add(new Pizza("Funghi", "Porcini e mozzarella", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
            pizzaBianche.Add(new Pizza("Bresaola", "Rucola e bresaola", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 12));

            MenuPizze mp = new MenuPizze();

			mp.Bianche = pizzaBianche;
			mp.Rosse = pizzaRosse;


            return View(mp);
          
        }

		// GET: PizzaController/Details/5
		public ActionResult Details(int id)
		{
            List<Pizza> pizzaList = new List<Pizza> ();

            pizzaList.Add(new Pizza("Margherita", "Mozzarella e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 8));
            pizzaList.Add(new Pizza("Napoli", "Alici e pomodoro", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
            pizzaList.Add(new Pizza("Capricciosa", "Uova e carciofi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 10));

            pizzaList.Add(new Pizza("Quattro Formaggi", "Mix formaggi", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 6));
            pizzaList.Add(new Pizza("Funghi", "Porcini e mozzarella", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 7));
            pizzaList.Add(new Pizza("Bresaola", "Rucola e bresaola", "https://www.melarossa.it/wp-content/uploads/2021/02/ricetta-pizza-margherita.jpg?x58780", 12));

			return View(pizzaList[id]);
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
			return View();
		}

		// POST: PizzaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PizzaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PizzaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
