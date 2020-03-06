using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyRefCore.Data;
using EasyRefCore.Models;
using EasyRefCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyRefCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase

    {

        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole<int>> _roleManager;
        IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration) {

            
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
       

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth([FromBody]AuthModel model)
        {
         
            if (model == null) {
                return new StatusCodeResult(500);
            }
            else {
                return await AuthenticateUser(model);
            }
            
        }

        private async Task<IActionResult> AuthenticateUser(AuthModel model)
        {
            try
            {
              
                var user = await _userManager.FindByNameAsync(model.Username);
           
                if (user == null && model.Username.Contains("@"))
                    user = await _userManager.FindByEmailAsync(model.Username);

                if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                {
                 
                    return new UnauthorizedResult();
                }

                DateTime now = DateTime.UtcNow;

      
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,
                        new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
       
                };

                var tokenExpirationMins =  _configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
                var issuerSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes(_configuration["Auth:Jwt:Key"]));

                var token = new JwtSecurityToken(
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMins)),
                    signingCredentials: new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

                var response = new AuthResponse()
                {
                    Token = encodedToken,
                    Expiration = tokenExpirationMins,
                    UserId = user.Id,
                    User = user.Email,
                    UserRole = await _userManager.GetRolesAsync(user)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return new UnauthorizedResult();
            }
        }
    }

}
