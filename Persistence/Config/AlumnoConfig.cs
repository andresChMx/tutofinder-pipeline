using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class AlumnoConfig
    {
        public AlumnoConfig(EntityTypeBuilder<Alumno> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombres)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Apellidos)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.DNI)
                .IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Correo)
                .IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Grado_academico)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new Alumno
                {
                    AlumnoId = 1,
                    PadreId =1,
                    Nombres = "Lucho",
                    Apellidos = "Cardenas",
                    DNI = "75863340",
                    Correo ="lucho13@gmail.com",
                    Grado_academico = "Secundaria"                                     
                }); 
        }
    }
}
