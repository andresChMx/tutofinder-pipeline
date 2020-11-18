using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class PagoConfig
    {
        public PagoConfig(EntityTypeBuilder<Pago> entityBuilder)
        {
            entityBuilder.Property(x => x.Descripcion)
                .IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CvcTarjeta)
                .IsRequired().HasMaxLength(4);
            entityBuilder.HasData(
                new Pago
                {
                    PagoId = 1,
                    TarjetaId = 1,
                    TutoriaId = 1,
                    Descripcion = " Pago de tutoria de redes",
                    CvcTarjeta = "123"
                });
        }
    }
}
