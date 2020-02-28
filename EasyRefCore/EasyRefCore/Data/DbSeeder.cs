using EasyRefCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Data
{
    public static class DbSeeder
    {

        public static void Seed(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager).GetAwaiter().GetResult();
            }
        }

        private static async Task CreateUsers(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {

            string role_admin = "Admin";
            string role_coach = "Coach";
            string role_referee = "Referee";
            string fieldsize_5 = "5 Man";
            string fieldsize_7 = "7 Man";
            string fieldsize_9 = "9 Man";
            string fieldsize_11 = "11 Man";

            if (!await roleManager.RoleExistsAsync(role_admin))
            {
                await roleManager.CreateAsync(new IdentityRole(role_admin));
            }
            if (!await roleManager.RoleExistsAsync(role_coach))
            {
                await roleManager.CreateAsync(new IdentityRole(role_coach));
            }
            if (!await roleManager.RoleExistsAsync(role_referee))
            {
                await roleManager.CreateAsync(new IdentityRole(role_referee));
            }
            if (!await roleManager.RoleExistsAsync(fieldsize_5))
            {
                await roleManager.CreateAsync(new IdentityRole(fieldsize_5));
            }
            if (!await roleManager.RoleExistsAsync(fieldsize_7))
            {
                await roleManager.CreateAsync(new IdentityRole(fieldsize_7));
            }
            if (!await roleManager.RoleExistsAsync(fieldsize_9))
            {
                await roleManager.CreateAsync(new IdentityRole(fieldsize_9));
            }
            if (!await roleManager.RoleExistsAsync(fieldsize_11))
            {
                await roleManager.CreateAsync(new IdentityRole(fieldsize_11));
            }


            var admin_user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Bertil",
                LastName = "Administrator",
                Email = "admin@testref.com",
                PhoneNumber = "0731236543",
                UserName = "bertiladmin"

            };
                  if (await userManager.FindByEmailAsync(admin_user.Email) == null )
            {
                
                var x = await userManager.CreateAsync(admin_user, "Pass12345");
                var xx = await userManager.AddToRoleAsync(admin_user, role_admin);
                admin_user.EmailConfirmed = true;
                admin_user.LockoutEnabled = false;
            }

            var coach_user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Lars",
                LastName = "Domare",
                Compound = "Testlag",
                Email = "lars@testlag.test",
                PhoneNumber = "0701337345",
                UserName = "Lassemannen"
            };

            if (await userManager.FindByEmailAsync(coach_user.Email) == null)
            {
                var x = await userManager.CreateAsync(coach_user, "pass4Lars");
                 var xx = await userManager.AddToRoleAsync(coach_user, role_coach);
                coach_user.EmailConfirmed = true;
                coach_user.LockoutEnabled = false;
            }

            var referee_user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Jenny",
                LastName = "Domare",
                Compound = "Laget",
                Email = "jenny@testdomare.com",
                PhoneNumber = "0731227345",
                UserName = "Jenny88"
            };

            var second_referee_user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Kalle",
                LastName = "Domare",
                Compound = "Andra laget",
                Email = "kalle@testdomare.com",
                PhoneNumber = "0702345345",
                UserName = "Kalleanka"
            };


           

            if (await userManager.FindByEmailAsync(referee_user.Email) == null)
            {
                await userManager.CreateAsync(referee_user, "pass4Jenny");
                await userManager.AddToRoleAsync(referee_user, role_referee);
                await userManager.AddToRoleAsync(referee_user, fieldsize_5);
                referee_user.EmailConfirmed = true;
                referee_user.LockoutEnabled = false;
            }

            if (await userManager.FindByEmailAsync(second_referee_user.Email) == null)
            {
                await userManager.CreateAsync(second_referee_user, "pass4Kalle");
                await userManager.AddToRoleAsync(second_referee_user, fieldsize_11);
                referee_user.EmailConfirmed = true;
                referee_user.LockoutEnabled = false;
            }

            await dbContext.SaveChangesAsync();

        }

      
        }
    }

