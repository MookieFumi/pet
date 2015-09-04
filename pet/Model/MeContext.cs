using System.Data.Entity;
using kk.Model.Entities;

namespace kk.Model
{
    public class MeContext : DbContext
    {
        public MeContext()
            : base("Me")
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().ToTable("Empresas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        }
    }
}