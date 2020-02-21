using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class Referee
    {

        public Referee() { }

        public int RefereeId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Compound { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? FieldSizeId { get; set; }
        public Role Role { get; set; }
        public  ICollection<Game> GameReferee { get; set; }
        public ICollection<Game> GameSecondReferee { get; set; }
        public ICollection<Game> GameThirdReferee { get; set; }
        public  GameFieldSize FieldSize { get; set; }

     
      
    }
}
