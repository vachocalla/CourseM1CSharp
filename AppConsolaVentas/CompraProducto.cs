public class CompraProducto
{
    // Propiedades
    public long id { get; set; }
    public Producto producto { get; set; }
    public int cantidad { get; set; }

    // Constructor
    public CompraProducto(
        /*long compraProductoId, */
        Producto compraProductoProducto, 
        int compraProductoCantidad)
    {
        //id = compraProductoId;
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        producto = compraProductoProducto;
        cantidad = compraProductoCantidad;
    }

    public decimal costoCompra(){
        return producto.precio * cantidad;
    }

    public string toString(){
        return $"{id} \t{producto.nombre} \t{producto.precio} \t{cantidad} \t{costoCompra()}";
    }
}