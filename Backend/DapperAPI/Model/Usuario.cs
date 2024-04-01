using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Passd { get; set; }
        public string Nombre { get; set; }
    }
}
