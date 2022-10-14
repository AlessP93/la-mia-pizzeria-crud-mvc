
using la_mia_pizzeria;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria.Models
{
    //tabelle
    public class PizzeriaContext : IdentityDbContext<IdentityUser>
    {
        public PizzeriaContext()
        {

        }
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
        : base(options)
        {
        }
        public DbSet<Pizza>? Pizzas { get; set; }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Ingredient>? Ingredients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria_auth;Integrated Security=True;Pooling=False");
        }

    }
}