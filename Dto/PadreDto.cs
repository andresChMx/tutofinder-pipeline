using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Dto
{
    public class PadreCreateDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }

    }
    public class PadreUpdateDto
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }

    }
    public class PadreDto
    {
        public int PadreId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public List<AlumnoDtoPresentar> Alumnos { get; set; }
    }
    public class PadreDtoPresentar
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
    }
    public class FavoritoDto
    {
        public int FavoritoId { get; set; }
        public int PadreId { get; set; }
        public Padre Padre { get; set; }
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }
    }
    public class FavoritoDtoCreate
    {
        public int PadreId { get; set; }
        public int DocenteId { get; set; }
    }
}
