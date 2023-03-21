using System.ComponentModel.DataAnnotations;

namespace Core.Entidades;

public class Pais
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } 
    public bool Estado { get; set; }
}