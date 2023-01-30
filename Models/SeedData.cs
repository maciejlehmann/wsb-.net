using Microsoft.EntityFrameworkCore;
using RazorPagesDish.Models;
using Restuarant.Data;

namespace RazorPagesDish.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestuarantContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RestuarantContext>>()))
            {
                if (context == null || context.Dish == null)
                {
                    throw new ArgumentNullException("Null RestuarantContext");
                }

                // Look for any dishes.
                if (context.Dish.Any())
                {
                    return;   // DB has been seeded
                }

                context.Dish.AddRange(
                    new Dish
                    {
                        Name = "Rosół",
                        Description = "Woda z warzywami",
                        Price = 11.99M,
                        Type = "Zupa",
                        ImageUrl = "https://cdn.pixabay.com/photo/2014/12/09/17/57/soup-562163_960_720.jpg"
					},

                    new Dish
                    {
                        Name = "Pierogi z kapustą i grzybami",
                        Description = "10 szt. dużych pierogów.",
                        Price = 22.99M,
                        Type = "Pierogi",
						ImageUrl = "https://cdn.pixabay.com/photo/2017/03/10/13/57/cooking-2132874_960_720.jpg"
					},

                    new Dish
                    {
                        Name = "Schabowy",
                        Description = "Kotlet",
                        Price = 31.99M,
                        Type = "Danie mięsne",
						ImageUrl = "https://cdn.pixabay.com/photo/2020/03/14/01/04/dinner-4929395_960_720.jpg"
					},

                    new Dish
                    {
                        Name = "Spaghetti",
                        Description = "Makaron",
                        Price = 23.99M,
                        Type = "Makaron",
						ImageUrl = "https://cdn.pixabay.com/photo/2018/07/18/19/12/pasta-3547078_960_720.jpg"
					}
                );
                context.SaveChanges();
            }
        }
    }
}