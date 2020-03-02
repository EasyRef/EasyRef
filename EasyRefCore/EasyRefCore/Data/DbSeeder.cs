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

        public static void Seed(ApplicationDbContext dbContext, RoleManager<IdentityRole<int>> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!dbContext.GameFieldSize.Any()) { 
            var fieldSize = new List<GameFieldSize>
                {
                    new GameFieldSize {FieldSize = 5},
                    new GameFieldSize {FieldSize = 7},
                    new GameFieldSize {FieldSize = 9},
                    new GameFieldSize {FieldSize = 11},
                };

            dbContext.GameFieldSize.AddRange(fieldSize);
        }

            if (!dbContext.GameAge.Any()) {
                var gameAge = new List<GameAge> {

                new GameAge { Age = 4},
                new GameAge { Age = 5 },
                new GameAge { Age = 6 },
                new GameAge { Age = 7 },
                new GameAge { Age = 8 },
                new GameAge { Age = 9 },
                new GameAge { Age = 10 },
                new GameAge { Age = 11 },
                new GameAge { Age = 12 },
                new GameAge { Age = 13 },
                new GameAge { Age = 14 },
                new GameAge { Age = 15 },
                new GameAge { Age = 16 },
                new GameAge { Age = 17 }

            };

                dbContext.GameAge.AddRange(gameAge);
            }

            if(!dbContext.GameDivison.Any())
            {
                var gameDiv = new List<GameDivision>
                {
                    new GameDivision {Division = "Divison 1"},
                    new GameDivision {Division = "Divison 2"},
                    new GameDivision {Division = "Divison 3"},
                    new GameDivision {Division = "Divison 4"},
                    new GameDivision {Division = "Divison 5"},
                };

                dbContext.GameDivison.AddRange(gameDiv);
            }

            if(!dbContext.GameGender.Any())
            {
                var gender = new List<GameGender>
                {
                    new GameGender {Gender = "H"},
                    new GameGender {Gender = "D"}
                };

                dbContext.GameGender.AddRange(gender);
            }
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager).GetAwaiter().GetResult();
              
            }
        }

        private static async Task CreateUsers(ApplicationDbContext dbContext, RoleManager<IdentityRole<int>> roleManager, UserManager<ApplicationUser> userManager)
        {

            string role_admin = "Admin";
            string role_coach = "Coach";
            string role_referee = "Referee";
      

            if (!await roleManager.RoleExistsAsync(role_admin))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role_admin));
            }
            if (!await roleManager.RoleExistsAsync(role_coach))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role_coach));
            }
            if (!await roleManager.RoleExistsAsync(role_referee))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role_referee));
            }
       

            var admin_user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Bertil",
                LastName = "Administrator",
                Email = "admin@testref.com",
                PhoneNumber = "0731236543",
                UserName = "bertiladmin",

            };
                  if (await userManager.FindByEmailAsync(admin_user.Email) == null )
            {
                
                var x = await userManager.CreateAsync(admin_user, "Pass12345");
                var xx = await userManager.AddToRoleAsync(admin_user, role_admin);
                admin_user.EmailConfirmed = true;
                admin_user.LockoutEnabled = false;
            }

            await dbContext.SaveChangesAsync();

        }

      
        }
    }

