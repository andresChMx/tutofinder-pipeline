using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class MembresiaConfig
    {
        public MembresiaConfig(EntityTypeBuilder<Membresia> entityBuilder)
        {
            entityBuilder.Property(x => x.Cvc_tarjeta)
                .IsRequired().HasMaxLength(3);
            entityBuilder.Property(x => x.Fecha_expiracion)
                .IsRequired().HasMaxLength(10);
            entityBuilder.HasData(
                new Membresia
                {
                    MembresiaId = 1,
                    TarjetaId = 1,
                    DocenteId=1,
                    Cvc_tarjeta = "123",
                    Fecha_expiracion = "12/05/2021"
                });
        }
    }
}
