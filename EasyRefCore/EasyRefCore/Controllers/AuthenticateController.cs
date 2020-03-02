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
    public class AuthenticateController : BaseApiController
    {

       
        public AuthenticateController(
            ApplicationDbContext context,
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration
            )
            : base(context, roleManager, userManager, configuration) { }
       

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
              
                var user = await UserManager.FindByNameAsync(model.Username);
           
                if (user == null && model.Username.Contains("@"))
                    user = await UserManager.FindByEmailAsync(model.Username);

                if (user == null || !await UserManager.CheckPasswordAsync(user, model.Password))
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

                var tokenExpirationMins =  Configuration.GetValue<int>("Auth:Jwt:TokenExpirationInMinutes");
                var issuerSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes(Configuration["Auth:Jwt:Key"]));

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
                    Expiration = tokenExpirationMins
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
