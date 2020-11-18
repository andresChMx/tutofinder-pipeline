using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class CursoConfig
    {
        public CursoConfig(EntityTypeBuilder<Curso> entityBuilder)
        {
            entityBuilder.Property(x => x.Nombre)
                .IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Descripcion)
                .IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Grado_academico)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new Curso
                {
                    CursoId=1,
                    Nombre = "AplicacionesWeb",
                    Grado_academico = "Secundaria",
                    Descripcion = "aquellas herramientas que los usuarios pueden utilizar accediendo a un servidor web de internet"

                });
        }
    }
}
