using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Dto
{
    public class AlumnoCreateDto
    {
        public int PadreId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Grado_academico { get; set; }
    }
    public class AlumnoUpdateDto
    {
        public int PadreId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Grado_academico { get; set; }
    }
    public class AlumnoDto
    {
        public int AlumnoId { get; set; }
        public int PadreId { get; set; }
        public PadreDtoPresentar Padre { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Grado_academico { get; set; }
    }
    public class AlumnoDtoPresentar
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Grado_academico { get; set; }
    }
}
