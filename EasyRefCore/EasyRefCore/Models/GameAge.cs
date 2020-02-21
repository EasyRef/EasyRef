using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class GameAge
    {
        public GameAge() { }
        public int Id { get; set; }
        public int Age { get; set; }

        public  ICollection<Game> Game { get; set; }
    }
}
