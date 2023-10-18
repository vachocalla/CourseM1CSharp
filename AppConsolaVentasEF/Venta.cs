
using System;
using System.ComponentModel.DataAnnotations;

public class Venta
{
    [Key]
    public long id { get; set; }
    public Cliente cliente { get; set; }
    public List<CompraProducto> compraProductos { get; set; }
    public DateTime fechaVenta { get; set; }

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