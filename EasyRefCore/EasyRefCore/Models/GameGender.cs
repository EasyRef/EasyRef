using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class GameGender
    {

        public GameGender() { }
        public int Id { get; set; }
        public string Gender { get; set; }

        public  ICollection<Game> Games { get; set; }
    }
}
