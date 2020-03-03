using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyRefCore.Data;
using EasyRefCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EasyRefCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Constructor
        public BaseApiController(ApplicationDbContext context, RoleManager<IdentityRole<int>> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
           
            _dbContext = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;

         
            _jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

        }
        #endregion

        #region Shared Properties
        protected ApplicationDbContext _dbContext { get; private set; }
        protected RoleManager<IdentityRole<int>> _roleManager { get; private set; }
        protected UserManager<ApplicationUser> _userManager { get; private set; }
        protected IConfiguration _configuration { get; private set; }
        protected JsonSerializerSettings _jsonSettings { get; private set; }
        #endregion
    }

}
