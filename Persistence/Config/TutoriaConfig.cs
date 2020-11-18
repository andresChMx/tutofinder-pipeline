using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class TutoriaConfig
    {
        public TutoriaConfig(EntityTypeBuilder<Tutoria> entityBuilder)
        {
            entityBuilder.Property(x => x.Descripcion)
                .IsRequired().HasMaxLength(50);
            entityBuilder.HasData(
                new Tutoria
                {
                    TutoriaId = 1,
                    AlumnoId = 1,
                    DocenteId = 1,
                    CursoId = 1,
                    Costo = 30.25,
                    Descripcion = "Repaso de codigo Api",
                    Cantidad_minutos = 3
                });
        }
    }

}
