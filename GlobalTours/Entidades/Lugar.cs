namespace GlobalTours.Entidades;

public class Lugar
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public string ImagenMiniatura { get; set; }
    public bool Destacado { get; set; }
    public bool Disponible { get; set; }
    public int CategoriaId { get; set; }
}