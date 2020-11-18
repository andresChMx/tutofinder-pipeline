using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Entity
{
    public class Favorito
    {
        public int FavoritoId { get; set; }
        public int PadreId { get; set; }
        public Padre Padre { get; set; }
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }
    }
}
