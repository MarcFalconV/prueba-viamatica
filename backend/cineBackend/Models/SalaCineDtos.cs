
public class SalaCineDto
{
  public int IdSala { get; set; }
  public string Nombre { get; set; } = string.Empty;
  public int Estado { get; set; }
  public bool Activo { get; set; }
}



public class SalaDisponibilidadDto
{
  public string Mensaje { get; set; } = string.Empty;
  public int TotalPeliculas { get; set; }
}