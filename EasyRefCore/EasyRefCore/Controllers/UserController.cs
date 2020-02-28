using EasyRefCore.Data;
using EasyRefCore.Models;
using EasyRefCore.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {

        public UserController( ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
            : base(context, roleManager, userManager, configuration) { }

        string role_admin = "Admin";
        string role_coach = "Coach";
        string role_referee = "Referee";
    

        

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]AddUserModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            try
            {

                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    Compound = model.Compound,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    

                };
                var x = await UserManager.CreateAsync(user, model.Password);
                if (model.IsAdmin)
                {
                    var xx = await UserManager.AddToRoleAsync(user, role_admin);
                

                }
                if (model.IsCoach)
                {
                    var xx = await UserManager.AddToRoleAsync(user, role_coach);
                }
                if (model.IsReferee)
                {
                    var xx = await UserManager.AddToRoleAsync(user, role_referee);
                    var xxxx = await UserManager.AddToRoleAsync(user, model.FieldSize);
                    
                }

                user.EmailConfirmed = true;
                user.LockoutEnabled = false;

                await DbContext.SaveChangesAsync();

                

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await DbContext.Users.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

    }
}
