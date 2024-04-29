using Aplicacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Data;

public class AppDataContext : DbContext 
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : 
    base(options)
    { }

    public DbSet<Hospede> Hospedes { get; set; } = null!;
    public DbSet<Quarto> Quartos { get; set; } = null!;
    public DbSet<Reserva> Reservas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quarto>().HasData(
            new Quarto { Id = 1, Numero = 105, EstaDisponivel = true},
            new Quarto { Id = 2, Numero = 205, EstaDisponivel = false},
            new Quarto { Id = 3, Numero = 305, EstaDisponivel = true}
        );
    }
}