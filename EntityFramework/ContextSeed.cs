using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            User user1 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Muhammet Ali",
                LastName = "KOÇ",
                UserName = "MuhammetAliKOC",
                Email = "malikoc2020@gmail.com",
                PhoneNumber = "0553 011 80 17",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                //Password = "hKaoJdFbclk=",/*123456*/

            };


                var user = await userManager.FindByEmailAsync(user1.Email);
                if (user == null)
                {
                   var result = await userManager.CreateAsync(user1, "Sifre%5");
                       if (result.Succeeded)
                       {
                           await userManager.AddToRoleAsync(user1, Roles.User.ToString());
                           await userManager.AddToRoleAsync(user1, Roles.Manager.ToString());
                           await userManager.AddToRoleAsync(user1, Roles.Admin.ToString());
                           await userManager.AddToRoleAsync(user1, Roles.SuperAdmin.ToString());
                       }

                }
         
        }
    }
}
