using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class InformeConfig
    {
        public InformeConfig(EntityTypeBuilder<Informe> entityBuilder)
        {         
            entityBuilder.Property(x => x.Descripcion)
                .IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Fecha)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new Informe
                {
                    InformeId =1,
                    Descripcion = " no hizo nada en todo el ciclo",
                    TutoriaId = 1,
                    Fecha = "12/02/2000"

                });
        }
    }
}
