public class Producto
{
    // Propiedades
    public long id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal precio { get; set; }

    // Constructor
    public Producto(){
    }
    public Producto(
        /*long productoId, */
        string productoNombre, 
        string productoDescripcion, 
        decimal productoPrecio)
    {
        //id = productoId;
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        nombre = productoNombre;
        descripcion = productoDescripcion;
        precio = productoPrecio;
    }

    public string toString(){
        return $"{id}\t{nombre}\t{descripcion}\t{precio}";
    }

    public void leer(){
        //id = System.CurrentMilliseconds.
        Console.WriteLine("INGRESE PRODUCTO:");
        //Console.Write("Id:");
        //id = long.Parse(Console.ReadLine());
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        Console.Write("Nombre:");
        nombre = Console.ReadLine();
        Console.Write("Descripcion:");
        descripcion = Console.ReadLine();
        Console.Write("Precio:");
        precio = decimal.Parse(Console.ReadLine());
    }
}