using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class TarjetaCreateDto
    {
        
        public string Fecha_expiracion { get; set; }
        public string Nombre_poseedor { get; set; }
        public string Numero_tarjeta { get; set; }
    }
    public class TarjetaUpdateDto
    {
        public string Fecha_expiracion { get; set; }
        public string Nombre_poseedor { get; set; }
        public string Numero_tarjeta { get; set; }
    }
    public class TarjetaDto
    {
        public int TarjetaId { get; set; }
        public string Fecha_expiracion { get; set; }
        public string Nombre_poseedor { get; set; }
        public string Numero_tarjeta { get; set; }
    }
    public class TarjetaDtoPresentar
    {
        public string Fecha_expiracion { get; set; }
        public string Nombre_poseedor { get; set; }
        public string Numero_tarjeta { get; set; }
    }
}
