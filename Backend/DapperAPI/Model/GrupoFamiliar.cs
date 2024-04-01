using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApi.Models
{
    public class GrupoFamiliar
    {
        public string Usuario { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Parentesco { get; set; }
        public int Edad { get; set; }
        public string MenorEdad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
