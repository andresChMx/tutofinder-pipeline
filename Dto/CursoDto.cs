using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class CursoCreateDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Grado_academico { get; set; }
    }
    public class CursoUpdateDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Grado_academico { get; set; }
    }
    public class CursoDto
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Grado_academico { get; set; }
    }
    public class CursoDtoPresentar
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Grado_academico { get; set; }
    }
}
