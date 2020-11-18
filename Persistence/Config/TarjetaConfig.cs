using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class TarjetaConfig
    {
        public TarjetaConfig(EntityTypeBuilder<Tarjeta> entityBuilder)
        {
            entityBuilder.Property(x => x.Fecha_expiracion)
                .IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.Nombre_poseedor)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Numero_tarjeta)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new Tarjeta
                {
                    TarjetaId = 1,
                    Fecha_expiracion = "20/02/2025",
                    Nombre_poseedor = " Henry Papi",
                    Numero_tarjeta = "255.255.255.0"
                    
                });
        }
    }
}
