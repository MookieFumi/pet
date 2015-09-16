using System.Data.Entity;
using pet.dal.Model.Entities;
using pet.dal.Model.Entities.Carioca;

namespace pet.dal.Model
{
    public class MeContext : DbContext
    {
        public MeContext()
            : base("Me")
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }

        public virtual DbSet<TipoZona> TiposZona { get; set; }
        public DbSet<TipoContenedor> TiposContenedor { get; set; }
        public DbSet<TipoUbicacion> TiposUbicacion { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Contenedor> Contenedores { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>().ToTable("Empresas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Tienda>().ToTable("Tiendas");

            modelBuilder.Entity<TipoZona>().ToTable("_TiposZona");
            modelBuilder.Entity<TipoContenedor>().ToTable("_TiposContenedores");
            modelBuilder.Entity<TipoUbicacion>().ToTable("_TiposUbicaciones");
            modelBuilder.Entity<Zona>().ToTable("Zonas");
            modelBuilder.Entity<Contenedor>().ToTable("Contenedores");
            modelBuilder.Entity<Ubicacion>().ToTable("Ubicaciones");
        }
    }
}