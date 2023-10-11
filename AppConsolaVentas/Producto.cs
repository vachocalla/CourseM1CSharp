public class Producto
{
    // Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    // Constructor
    public Producto(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }
}