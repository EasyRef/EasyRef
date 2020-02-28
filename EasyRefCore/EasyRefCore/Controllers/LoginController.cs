using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyRefCore.Data;
using EasyRefCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyRefCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult PostGame(LoginModel model)
        {
            return null;
        //    UserModel uModel;

        //    if (string.Equals(model.UserType, "coach"))
        //    {
        //        try
        //        {
        //           var coach = _context.Coach.Include(x => x.Role).Where(x => x.Email == model.Email).Where(p => p.Password == model.Password).Single();

        //            uModel = new UserModel {
        //                Id = coach.CoachId,
        //                FullName = coach.FirstName + " " + coach.LastName,
        //                Email = coach.Email,
        //                UserType = "coach",
        //                UserRole = coach.Role.UserRole
        //            };
        //            return Ok(uModel);

        //        } catch(InvalidOperationException ex)
        //        {
        //            return BadRequest("Wrong credentials");
        //        }

          

        //    }
        //    if (string.Equals(model.UserType, "referee"))
        //    {

        //        try { 
        //        var referee = _context.Referee.Include(x => x.Role).Where(x => x.Email == model.Email).Where(p => p.Password == model.Password).Single();

        //            uModel = new UserModel
        //            {
        //                Id = referee.RefereeId,
        //                FullName = referee.FirstName + " " + referee.LastName,
        //                Email = referee.Email,
        //                UserType = "referee",
        //                UserRole = referee.Role.UserRole
        //            };
        //            return Ok(uModel);
        //        } catch (InvalidOperationException ex)
        //    {
        //        return BadRequest("Wrong credentials");
        //    }
        //}

        //    return BadRequest("Wrong credentials");
        }

    }
}
