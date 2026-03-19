using Microsoft.EntityFrameworkCore;
using WebApi2026Jmp1.Entities;

namespace WebApi2026Jmp1.Data;

public class AppDbContext : DbContext
{
    // Constructor que recibe configuraciones inyectadas desde Program.cs.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Representa la tabla Accounts en la base de datos.
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Llama configuracion base de Entity Framework Core.
        base.OnModelCreating(modelBuilder);

        // Configuracion explicita de la entidad Account.
        modelBuilder.Entity<Account>(entity =>
        {
            // Define Id como clave primaria.
            entity.HasKey(a => a.Id);

            // Requiere Name y limita su longitud.
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(120);

            // Define precision para valores monetarios.
            entity.Property(a => a.InitialBalance)
                .HasPrecision(18, 2);
        });
    }
}
