using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Domain.Entities
{
    public class Usuarios
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
