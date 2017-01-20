using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrailerCheckV1.Data;
using System;
using System.Linq;

namespace TrailerCheckV1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any trailers.
                if (context.Trailer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Trailer.AddRange(
                     new Trailer
                     {
                         Model = "GD125",
                         ProductGroup = "General Duty",
                         SerialNumber = "345846",
                         Stolen = "Yes",
                         YearOfManufacture = DateTime.Parse("25-03-1985")
                     },

                     new Trailer
                     {
                         Model = "LM146",
                         ProductGroup = "Flatbed",
                         SerialNumber = "5133456",
                         Stolen = "No",
                         YearOfManufacture = DateTime.Parse("01-08-1999")
                     },

                     new Trailer
                     {
                         Model = "HB505R",
                         ProductGroup = "Horsebox",
                         SerialNumber = "221898",
                         Stolen = "Yes",
                         YearOfManufacture = DateTime.Parse("16-06-2002")
                     },

                     new Trailer
                     {
                         Model = "GP106H",
                         ProductGroup = "Plant",
                         SerialNumber = "360458",
                         Stolen = "No",
                         YearOfManufacture = DateTime.Parse("24-10-2010")
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
