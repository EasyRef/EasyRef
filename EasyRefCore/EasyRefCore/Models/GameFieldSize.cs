using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class GameFieldSize
    {

        public GameFieldSize() { }

        public int Id { get; set; }
        public int FieldSize { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
        public  ICollection<Game> Games { get; set; }
    }
}
