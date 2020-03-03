using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models.User
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Compound { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCoach { get; set; }
        public bool IsReferee { get; set; }
        public int? FieldSize { get; set; }
    }
}
