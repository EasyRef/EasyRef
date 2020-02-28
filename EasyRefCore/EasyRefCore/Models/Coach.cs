using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class Coach
    {
        public Coach() { }

        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Compound { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public  ICollection<Game> Games { get; set; }

    }
}
