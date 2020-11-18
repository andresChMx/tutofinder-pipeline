using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class InformeCreateDto
    {

        public int TutoriaId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
    public class InformeUpdateDto
    {
        public int TutoriaId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
    public class InformeDto
    {
        public int InformeId { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int TutoriaId { get; set; }
        public TutoriaDto Tutoria { get; set; }
    }
}
