using Microsoft.EntityFrameworkCore;
using StreamFy.Core.Modelos;

namespace StreamFy.Infra.Dados;

public class StramFyContext : DbContext
{

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    public StramFyContext(DbContextOptions<StramFyContext> options) : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Musica>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Playlists)
            .WithOne();

        modelBuilder.Entity<Playlist>()
            .HasMany(p => p.Musicas)
            .WithMany();
    }
}



