using Microsoft.EntityFrameworkCore;
using StreamFy.Core.Modelos;

namespace StreamFy.Infra.Dados;

public class StramFyContext : DbContext
{

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Autor> Autores { get; set; }
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

        modelBuilder.Entity<Autor>()
        .HasMany(a => a.Musicas)
        .WithOne(m => m.Autor)
        .HasForeignKey(m => m.AutorId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Autor>().HasData(
        new Autor { Id = 1, Nome = "Queen" },
        new Autor { Id = 2, Nome = "Led Zeppelin" },
        new Autor { Id = 3, Nome = "Eagles" },
        new Autor { Id = 4, Nome = "Guns N' Roses" },
        new Autor { Id = 5, Nome = "John Lennon" },
        new Autor { Id = 6, Nome = "Nirvana" },
        new Autor { Id = 7, Nome = "Oasis" },
        new Autor { Id = 8, Nome = "The Beatles" },
        new Autor { Id = 9, Nome = "Bob Dylan" },
        new Autor { Id = 10, Nome = "Michael Jackson" }
        );

        modelBuilder.Entity<Musica>().HasData(
            new Musica { Id = 1, Nome = "Bohemian Rhapsody", AutorId = 1 },
            new Musica { Id = 2, Nome = "Stairway to Heaven", AutorId = 2 },
            new Musica { Id = 3, Nome = "Hotel California", AutorId = 3 },
            new Musica { Id = 4, Nome = "Sweet Child O' Mine", AutorId = 4 },
            new Musica { Id = 5, Nome = "Imagine", AutorId = 5 },
            new Musica { Id = 6, Nome = "Smells Like Teen Spirit", AutorId = 6 },
            new Musica { Id = 7, Nome = "Wonderwall", AutorId = 7 },
            new Musica { Id = 8, Nome = "Hey Jude", AutorId = 8 },
            new Musica { Id = 9, Nome = "Like a Rolling Stone", AutorId = 9 },
            new Musica { Id = 10, Nome = "Billie Jean", AutorId = 10 }
        );
    }
}



