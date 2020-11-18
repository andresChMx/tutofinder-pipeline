using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutoFinder.Entity;
using TutoFinder.Entity.Identity;
using TutoFinder.Persistence.Config;

namespace TutoFinder.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Informe> Informes { get; set; }
        public DbSet<Padre> Padres { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Tutoria> Tutorias { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new AlumnoConfig(builder.Entity<Alumno>());
            new CursoConfig(builder.Entity<Curso>());
            new DocenteConfig(builder.Entity<Docente>());
            new InformeConfig(builder.Entity<Informe>());           
            new PadreConfig(builder.Entity<Padre>());
            new PagoConfig(builder.Entity<Pago>());
            new TarjetaConfig(builder.Entity<Tarjeta>());
            new TutoriaConfig(builder.Entity<Tutoria>());
            new MembresiaConfig(builder.Entity<Membresia>());
            new FavoritoConfig(builder.Entity<Favorito>());
            new ApplicationUserConfig(builder.Entity<ApplicationUser>());
            new ApplicationRoleConfig(builder.Entity<ApplicationRole>());
        }
    }
}
