using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Tutoria
    {
        public int TutoriaId { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }
        public double Costo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_minutos { get; set; }
    }
}
