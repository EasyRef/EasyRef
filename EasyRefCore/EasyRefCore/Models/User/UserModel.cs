using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.Models
{
    public class UserModel
    {
        public UserModel() { }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
