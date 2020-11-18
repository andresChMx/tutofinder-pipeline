using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public int PadreId { get; set; }
        public Padre Padre { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Grado_academico { get; set; }
        public string Correo { get; set; }
    }
}
