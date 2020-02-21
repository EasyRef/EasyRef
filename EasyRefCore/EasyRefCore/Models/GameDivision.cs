using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class GameDivision
    {

        public GameDivision() { }

        public int Id { get; set; }
        public string Division { get; set; }

        public  ICollection<Game> Games { get; set; }
    }
}
