using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Dto
{
    public class TutoriaCreateDto
    {
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        public int DocenteId { get; set; }
        public double Costo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_minutos { get; set; }
    }
    public class TutoriaUpdateDto
    {
        public int AlumnoId { get; set; }
        public int CursoId { get; set; }
        public int DocenteId { get; set; }
        public double Costo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_minutos { get; set; }
    }
    public class TutoriaDto
    {
        public int TutoriaId { get; set; }
        public int AlumnoId { get; set; }
        public AlumnoDtoPresentar Alumno { get; set; }
        public int CursoId { get; set; }
        public CursoDtoPresentar Curso { get; set; }
        public int DocenteId { get; set; }
        public DocenteDtoPresentar Docente { get; set; }
        public double Costo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_minutos { get; set; }
       
    }
}
