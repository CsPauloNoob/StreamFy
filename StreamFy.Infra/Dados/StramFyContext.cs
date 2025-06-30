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

        modelBuilder.Entity<Musica>().HasData(
            new Musica { Id = 1, Nome = "Bohemian Rhapsody" },
            new Musica { Id = 2, Nome = "Stairway to Heaven" },
            new Musica { Id = 3, Nome = "Hotel California" },
            new Musica { Id = 4, Nome = "Sweet Child O' Mine" },
            new Musica { Id = 5, Nome = "Imagine" },
            new Musica { Id = 6, Nome = "Smells Like Teen Spirit" },
            new Musica { Id = 7, Nome = "Wonderwall" },
            new Musica { Id = 8, Nome = "Hey Jude" },
            new Musica { Id = 9, Nome = "Like a Rolling Stone" },
            new Musica { Id = 10, Nome = "Billie Jean" }
        );
    }
}



