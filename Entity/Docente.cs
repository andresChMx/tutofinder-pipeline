using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Docente
    {
        public int DocenteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Domicilio { get; set; }
        public string Correo { get; set; }
        public string Disponibilidad { get; set; }
        public string Numero_cuenta { get; set; }
        public string Membresia { get; set; }
        public List<Tutoria> Tutorias { get; set; }
    }
}
