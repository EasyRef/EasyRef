using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class ApplicationUser : IdentityUser<int>
    {

        public ApplicationUser() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Compound { get; set; }
        public int? FieldSizeId { get; set; }


        public GameFieldSize FieldSize { get; set; }

        public ICollection<IdentityRole<int>> Roles { get; set; }
        public ICollection<IdentityUserRole<int>> UserRoles { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Game> GameReferee { get; set; }
        public ICollection<Game> GameSecondReferee { get; set; }
        public ICollection<Game> GameThirdReferee { get; set; }
        

    }


}
