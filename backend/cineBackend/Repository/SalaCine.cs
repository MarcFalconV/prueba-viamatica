
namespace cineBackend.Repository;

public partial class SalaCine
{
    public int IdSala { get; set; }

    public string Nombre { get; set; } = null!;

    public int Estado { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
