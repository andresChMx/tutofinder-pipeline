using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoFinder.Entity;

namespace TutoFinder.Persistence.Config
{
    public class FavoritoConfig
    {
        public FavoritoConfig(EntityTypeBuilder<Favorito> entityBuilder)
        { }
    }
}
