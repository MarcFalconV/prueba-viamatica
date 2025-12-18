
public class ProgramarRequestDto
{
  public int IdSalaCine { get; set; }
  public int IdPelicula { get; set; }
  public DateTime FechaPublicacion { get; set; }
  public DateTime FechaFin { get; set; }
}

public class CarteleraRequestDto
{
  public int IdPeliculaSala { get; set; }
  public string NombrePelicula { get; set; } = string.Empty;
  public string NombreSala { get; set; } = string.Empty;
  public DateTime FechaPublicacion { get; set; }
  public DateTime FechaFin { get; set; }
}


public class ProgramarFuncionDto
{
  public int IdSalaCine { get; set; }
  public int IdPelicula { get; set; }
  public DateTime FechaPublicacion { get; set; }
  public DateTime FechaFin { get; set; }
}