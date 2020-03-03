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
    public class UserController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        RoleManager<IdentityRole<int>> _roleManager;
        UserManager<ApplicationUser> _userManager;
      
        public UserController( ApplicationDbContext context, RoleManager<IdentityRole<int>> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration){

            _dbContext = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        string role_admin = "Admin";
        string role_coach = "Coach";
        string role_referee = "Referee";
    

        

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]UserModel model)
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
                    FieldSizeId = model.FieldSize
                    

                };
                var x = await _userManager.CreateAsync(user, model.Password);
                if (model.IsAdmin)
                {
                    var xx = await _userManager.AddToRoleAsync(user, role_admin);
                

                }
                if (model.IsCoach)
                {
                    var xx = await _userManager.AddToRoleAsync(user, role_coach);
                }
                if (model.IsReferee)
                {
                    var xx = await _userManager.AddToRoleAsync(user, role_referee);
            
                    
                }

                user.EmailConfirmed = true;
                user.LockoutEnabled = false;

                await _dbContext.SaveChangesAsync();

                

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet("Coaches")]

        public async Task<ActionResult<UserModel>> GetCoaches()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserModel> user = new List<UserModel>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                if(roles.Contains("Coach"))
                {
                    user.Add(new UserModel
                    {
                        Id = item.Id,
                        Firstname = item.FirstName,
                        Lastname = item.LastName,
                        Compound = item.Compound,
                        Phone = item.PhoneNumber,
                        Email = item.Email
                        
                    });
                }

            }



            return Ok(user);
        }

        [HttpGet("Referees")]

        public async Task<ActionResult<UserModel>> GetReferees()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserModel> user = new List<UserModel>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                if (roles.Contains("Referee"))
                {
                    user.Add(new UserModel
                    {
                        Id = item.Id,
                        Firstname = item.FirstName,
                        Lastname = item.LastName,
                        Compound = item.Compound,
                        Phone = item.PhoneNumber,
                        Email = item.Email
                    });
                }
            }
            return Ok(user);
        }

        [HttpGet("Admins")]

        public async Task<ActionResult<UserModel>> GetAdmins()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserModel> user = new List<UserModel>();

            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);

                if (roles.Contains("Admin"))
                {
                    user.Add(new UserModel
                    {
                        Id = item.Id,
                        Firstname = item.FirstName,
                        Lastname = item.LastName,
                        Compound = item.Compound,
                        Phone = item.PhoneNumber,
                        Email = item.Email

                    });
                }

            }



            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {

            var users = await _dbContext.UserRoles.ToListAsync();

           
            
            var user = await _dbContext.Users.Include(x => x.FieldSize).Where(x => x.Id == id).SingleOrDefaultAsync();

            var roles = await _userManager.GetRolesAsync(user);

            UserModel returnUser = new UserModel
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Compound = user.Compound,
                Email = user.Email,
                Phone = user.PhoneNumber,
                UserName = user.UserName,
                FieldSize = user.FieldSize.FieldSize
            };

            if(roles.Contains("Admin"))
            {
                returnUser.IsAdmin = true;

            }
            if(roles.Contains("Coach"))
            {
                returnUser.IsCoach = true;
            }
            if(roles.Contains("Referee"))
            {
                returnUser.IsReferee = true;

            }
           
            

            if (user == null)
            {
                return NotFound();
            }

            return Ok(returnUser);
        }

        [HttpPut("updateuser/{id}")]
        public async Task<ActionResult<UserModel>> PutUser(int Id, UserModel model)
        {

            var user = await _userManager.FindByIdAsync(Id.ToString());


            user.UserName = model.UserName;
            user.FirstName = model.Firstname;
            user.LastName = model.Lastname;
            user.Compound = model.Compound;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;
            user.FieldSizeId = model.FieldSize;


           

            await _userManager.UpdateAsync(user);


            var updateuser = await _userManager.FindByIdAsync(user.Id.ToString());
            var oldRole = await _userManager.GetRolesAsync(user);


           

            if (model.IsAdmin && !oldRole.Contains("Admin"))
            {

                await _userManager.AddToRoleAsync(updateuser, role_admin);
            }

            if (!model.IsAdmin && oldRole.Contains("Admin"))
            {

                await _userManager.RemoveFromRoleAsync(updateuser, role_admin);
            }



            if (model.IsCoach && !oldRole.Contains("Coach"))
            {
                var xx = await _userManager.AddToRoleAsync(updateuser, role_coach);
            }
            if (!model.IsCoach && oldRole.Contains("Coach"))
            {
                await _userManager.RemoveFromRoleAsync(updateuser, role_coach);
            }
            if (model.IsReferee && !oldRole.Contains("Referee"))
            {
                var xx = await _userManager.AddToRoleAsync(updateuser, role_referee);


            }
            if (!model.IsReferee && oldRole.Contains("Referee"))
            {
                await _userManager.RemoveFromRoleAsync(updateuser, role_referee);


            }
           


            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return CreatedAtAction("GetUser", new { id = Id }, updateuser);
        }


    }
}
