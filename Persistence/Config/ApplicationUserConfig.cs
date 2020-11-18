using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TutoFinder.Entity.Identity;

namespace TutoFinder.Persistence.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(20);
            entityBuilder.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(20);

            entityBuilder.HasMany(e => e.UserRoles)
                         .WithOne(e => e.User)
                         .HasForeignKey(e => e.UserId)
                          .IsRequired();
        }
    }
}
