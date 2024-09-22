using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Models;

namespace API_AgroGest.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración del mapeo de la entidad a la tabla en la base de datos
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // Nombre de la tabla en la base de datos
                entity.HasKey(e => e.Id); // Tipo de datos de la columna en la tabla
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product"); // Nombre de la tabla en la base de datos
                entity.HasKey(e => e.Id); // Tipo de datos de la columna en la tabla
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client"); // Nombre de la tabla en la base de datos
                entity.HasKey(e => e.Id); // Tipo de datos de la columna en la tabla
            });
        }
    }
}
