using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using _200566839.Models;
using System;
using System.Linq;
using _200566839.Data;

namespace _200566839.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(),
                serviceProvider.GetRequiredService<IConfiguration>()))
            {
                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Princy",
                        LastName = "Patel",
                        EmailAddress = "patel.princy@example.com"
                    },
                    new Student
                    {
                        FirstName = "Jay",
                        LastName = "Desai",
                        EmailAddress = "jay.desai@example.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
