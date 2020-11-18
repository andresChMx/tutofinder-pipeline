using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class PadreConfig
    {
        public PadreConfig(EntityTypeBuilder<Padre> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombres)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Apellidos)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.DNI)
               .IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Correo)
                .IsRequired().HasMaxLength(50);
            entityBuilder.HasData(
                new Padre
                {
                    PadreId = 1,
                    Nombres = " Moises",
                    Apellidos = "Cahuana",
                    DNI = " 35826791",
                    Correo = "Moieses@hotmail.com"
                });
        }
    }
}
