using Microsoft.EntityFrameworkCore;

namespace cineBackend.Repository;

public partial class CineDemoContext : DbContext
{
    public CineDemoContext()
    {
    }

    public CineDemoContext(DbContextOptions<CineDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__pelicula__B5017F4DDC08387C");

            entity.ToTable("pelicula");

            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaSala).HasName("PK__pelicula__39BC477F5605537F");

            entity.ToTable("pelicula_salacine");

            entity.Property(e => e.IdPeliculaSala).HasColumnName("id_pelicula_sala");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeliculaSalacine_Pelicula");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdSalaCine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeliculaSalacine_SalaCine");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__sala_cin__D18B015B18EC104C");

            entity.ToTable("sala_cine");

            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
