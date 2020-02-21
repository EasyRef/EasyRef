using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class Game
    {
        public Game() { }

        //testar branch och pusch, går att ta bort denna kommentar
        public int GameId { get; set; }
        public int? CoachId { get; set; }
   
        public int? RefereeId { get; set; }
      
        public int? SecondRefereeId { get; set; }
   
        public int? ThirdRefereeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int GameGenderId { get; set; }
        public int GameAgeId { get; set; }
        public string FieldLocation { get; set; }
        public int? GameFieldSizeId { get; set; }
        public int? GameDivisionId { get; set; }

        public  Coach Coach { get; set; }
        public  Referee Referee { get; set; }
        public Referee SecondReferee { get; set; }
        public Referee ThirdReferee { get; set; }
        public  GameFieldSize GameFieldSize { get; set; }

        public  GameDivision GameDivision { get; set; }
        public  GameGender GameGender { get; set; }
        public  GameAge GameAge { get; set; }



        //public EnrolledGames Games { get; set; }
    }
}
