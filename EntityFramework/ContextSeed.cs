using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFramework.Context
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        { 
            await roleManager.CreateAsync(new Role(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new Role(Roles.User.ToString()));
        }
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            List<User> users = new List<User>();

            User tanimsiz = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Tanımsız",
                LastName = "",
                UserName = "Tanimsiz",
                Email = "Tanimsiz@Tanimsiz.com",
                PhoneNumber = "Tanimsiz",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TC =""

                //Password = "hKaoJdFbclk=",/*123456*/
            };
            users.Add(tanimsiz);

            #region ilerde kullanılabilir.
            /*User superadmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "superadmin",
                LastName = "",
                UserName = "SuperAdmin",
                Email = "superadmin@superadmin.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                //Password = "hKaoJdFbclk=", //123456
            };
            users.Add(superadmin);

            User admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "admin",
                LastName = "",
                UserName = "Admin",
                Email = "admin@admin.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
                //Password = "hKaoJdFbclk=",//123456
            };
            users.Add(admin);
            */
            #endregion

            User manager = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "manager",
                LastName = "",
                UserName = "Manager",
                Email = "manager@manager.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TC ="-1"             
            };
            users.Add(manager);

            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "user",
                LastName = "",
                UserName = "User",
                Email = "user@user.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TC = "-1"
            };
            users.Add(user);

            foreach (var usr in users)
            {
                var userEntity = await userManager.FindByEmailAsync(usr.Email);
                    if (userEntity == null)
                    {
                       var result = await userManager.CreateAsync(usr, "Sifre%5");
                           if (result.Succeeded && usr.UserName != "Tanimsiz")
                           {
                               await userManager.AddToRoleAsync(usr, usr.UserName);
                           }

                    }
            }


         
        }
    }
}
