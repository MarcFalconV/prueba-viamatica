
public class PeliculaDto
{
    public int IdPelicula { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Duracion { get; set; }
    public bool? Activo { get; set; }
}

public class PeliculaCreacionDto
{
    public string Nombre { get; set; } = string.Empty;
    public int Duracion { get; set; }
}
