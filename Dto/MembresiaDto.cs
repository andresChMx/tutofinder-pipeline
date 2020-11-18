using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class MembresiaCreateDto
    {
        public int TarjetaId { get; set; }
        public int DocenteId { get; set; }
        public string Cvc_tarjeta { get; set; }
        public string Fecha_expiracion { get; set; }
    }
    public class MembresiaUpdateDto
    {
        public int MembresiaId { get; set; }
        public int TarjetaId { get; set; }
        public int DocenteId { get; set; }
        public string Cvc_tarjeta { get; set; }
        public string Fecha_expiracion { get; set; }

      
    }
    public class MembresiaDto
    {
        public int MembresiaId { get; set; }
        public int TarjetaId { get; set; }
        public TarjetaDtoPresentar Tarjeta { get; set; }
        public int DocenteId { get; set; }
        public DocenteDtoPresentar Docente { get; set; }
        public string Cvc_tarjeta { get; set; }
        public string Fecha_expiracion { get; set; }
    }
}
