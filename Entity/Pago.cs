using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int TarjetaId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public int TutoriaId { get; set; }
        public Tutoria Tutoria { get; set; }
        public string Descripcion { get; set; }
        public string CvcTarjeta { get; set; }
    }
}
