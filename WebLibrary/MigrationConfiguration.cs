using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Constants;
using WebLibrary.EFContext;
using WebLibrary.EFContext.Data;
using WebLibrary.EFContext.Identity;

namespace WebLibrary
{
    public static class MigrationConfiguration
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();

                if (!roleManager.Roles.Any())
                {
                    var role = new AppRole
                    {
                        Name = Roles.Admin
                    };
                    var result = roleManager.CreateAsync(role).Result;
                }

                if (!userManager.Users.Any())
                {
                    var user = new AppUser
                    {
                        Email = "user@gmail.com",
                        UserName = "user@gmail.com"
                    };
                    var result = userManager.CreateAsync(user, "12345678").Result;
                    //if(result.Succeeded)
                    result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
                }

                if (!context.Books.Any())
                {
                    var books = new List<Book>()
                    {
                        new Book
                        {
                            Name = "Код да Вінчі",
                            Author="Ден Браун",
                            Description="Інтрига, навколо якої розгортаються події роману, " +
                            "пов'язана з одвічною загадкою людства: походження, особистість, родина Ісуса Христа. " +
                            "Відповіді на цю загадку активно, але з ризиком для власного життя, " +
                            "шукають герої книги — гарвардський учений Роберт Ленґдон та його несподівана супутниця, криптограф Софі.",
                            Year=2010
                        },
                        new Book
                        {
                            Name = "1408",
                            Author="Стівен Кінг",
                            Description="Каждый писатель, работающий в жанре «ужастиков», должен написать как минимум по одному рассказу, " +
                            "как о похоронах заживо, так и о Комнате Призраков в Гостинице. Это моя версия последнего рассказа. " +
                            "Необычность его состоит в том, что я не собирался доводить его до логического завершения.",
                            Year=1997
                        }
                       
                    };
                    context.Books.AddRange(books);
                    context.SaveChanges();
                }

            }
        }
    }
}
