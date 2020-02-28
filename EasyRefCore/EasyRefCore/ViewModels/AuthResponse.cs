using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRefCore.ViewModels
{
    public class AuthResponse
    {
       
        public AuthResponse()
        {

        }
      
        public string Token { get; set; }
        public int Expiration { get; set; }
     
    }
}
