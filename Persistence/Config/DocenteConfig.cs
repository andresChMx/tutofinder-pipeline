using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class DocenteConfig
    {
        public DocenteConfig(EntityTypeBuilder<Docente> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombres)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Apellidos)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Correo)
                .IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.DNI)
                .IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Domicilio)
                .IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Disponibilidad)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Numero_cuenta)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Membresia)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new Docente
                {
                    DocenteId = 1,
                    Nombres = " Henrry",
                    Apellidos = " Mendoza",
                    DNI = "16534786",
                    Domicilio = "San Miguel calle puquina los condominios la waka",
                    Correo = "henrry@gmail.com",
                    Disponibilidad = "No Disponible",
                    Numero_cuenta = "2534586198371450",
                    Membresia = "Activa"
                });

           
        }
    }
}
