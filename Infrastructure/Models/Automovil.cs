namespace Infrastructure.Models;

public class Automovil{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public float Kilometraje { get; set; }
    public MarcaAutomovil Marca { get; set; }

}