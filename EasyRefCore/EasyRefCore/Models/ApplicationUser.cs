using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Compound { get; set; }


     
        public ICollection<Game> Games { get; set; }

    }
}
