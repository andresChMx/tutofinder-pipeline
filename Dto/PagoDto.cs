using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class PagoCreateDto
    {
        public int TarjetaId { get; set; }
        public int TutoriaId { get; set; }
        public string Descripcion { get; set; }
        public string CvcTarjeta { get; set; }
    }
    public class PagoUpdateDto
    {
        public int TarjetaId { get; set; }
        public int TutoriaId { get; set; }
        public string Descripcion { get; set; }
        public string CvcTarjeta { get; set; }
    }
    public class PagoDto
    {
        public int PagoId { get; set; }
        public string Descripcion { get; set; }
        public string CvcTarjeta { get; set; }
        public int TarjetaId { get; set; }
        public TarjetaDto Tarjeta { get; set; }
        public int TutoriaId { get; set; }
        public TutoriaDto Tutoria { get; set; }
    }
    public class PagoDtoPresentar
    {
        public string Descripcion { get; set; }
        public string CvcTarjeta { get; set; }
    }
}
