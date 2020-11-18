using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Membresia
    {
        public int MembresiaId { get; set; }
        public string Cvc_tarjeta { get; set; }
        public string Fecha_expiracion { get; set; }
        public int TarjetaId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }
    }
}
