public class Venta
{
    // Propiedades
    public int Id { get; set; }
    public Cliente cliente { get; set; }
    public List<Producto> Productos { get; set; }
    public DateTime FechaVenta { get; set; }

    // Constructor
    public Venta(int id, Cliente _cliente, List<Producto> productos, DateTime fechaVenta)
    {
        Id = id;
        cliente = _cliente;
        Productos = productos;
        FechaVenta = fechaVenta;
    }

    // Método para calcular el total de la venta
    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var producto in Productos)
        {
            // Supongamos que cada producto tiene un precio (no se muestra aquí en la clase Producto)
            total += ObtenerPrecioProducto(producto);
        }
        return total;
    }

    private decimal ObtenerPrecioProducto(Producto producto)
    {
        // Aquí podrías implementar lógica para obtener el precio del producto
        // Puedes usar una base de datos o una lista de precios, por ejemplo.
        // Por simplicidad, asumiremos que cada producto tiene un precio fijo.
        return 10.0M; // Precio de ejemplo
    }
}