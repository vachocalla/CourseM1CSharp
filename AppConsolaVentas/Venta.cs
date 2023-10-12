public class Venta
{
    // Propiedades
    public long id { get; set; }
    public Cliente cliente { get; set; }
    public List<CompraProducto> compraProductos { get; set; }
    public DateTime fechaVenta { get; set; }

    // Constructor
    public Venta(
        /*long ventaId, */
        Cliente ventaCliente, 
        List<CompraProducto> ventaCompraProductos, 
        DateTime ventaFechaVenta)
    {
        //id = ventaId;
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        cliente = ventaCliente;
        compraProductos = ventaCompraProductos;
        fechaVenta = ventaFechaVenta;
    }

    public void mostrarDetalleVenta()
    {
        Console.WriteLine($"Cliente: {cliente.nombre}");
        Console.WriteLine($"Productos Comprados:");
        decimal total = 0;
        foreach (var compraProducto in compraProductos)
        {
            Console.WriteLine($"\t {compraProducto.toString()}");
            total = total + compraProducto.costoCompra();
        }
        Console.WriteLine($"Total Compra: {total}");
    }

}