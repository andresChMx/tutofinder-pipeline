using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Informe
    {   
        [Key]
        public int InformeId { get; set; }
        public int TutoriaId { get; set; }
        public Tutoria Tutoria { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
}
