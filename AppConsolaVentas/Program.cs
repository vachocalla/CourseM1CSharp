// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
public class Program
{
    public static void Main(string[] args)
    {
        // Crear clientes
        Cliente cliente1 = new Cliente(1, "Juan Perez", "juan@example.com", "123-456-7890");
        Cliente cliente2 = new Cliente(2, "María Rodriguez", "maria@example.com", "987-654-3210");

        // Crear productos
        Producto producto1 = new Producto(101, "Producto A", "Descripción del Producto A");
        Producto producto2 = new Producto(102, "Producto B", "Descripción del Producto B");

        // Crear una venta
        List<Producto> productosVenta1 = new List<Producto> { producto1, producto2 };
        /*List<Producto> productosVenta1 = new List<Producto>();
        productosVenta1.Add(producto1);
        productosVenta1.Add(producto2);*/

        Venta venta1 = new Venta(1001, cliente1, productosVenta1, DateTime.Now);

        // Calcular el total de la venta
        decimal totalVenta1 = venta1.CalcularTotal();

        // Imprimir información de la venta
        Console.WriteLine("Información de la Venta:");
        Console.WriteLine($"ID de Venta: {venta1.Id}");
        Console.WriteLine($"Cliente: {venta1.cliente.Nombre}");
        Console.WriteLine("Productos:");
        foreach (var producto in venta1.Productos)
        {
            int x;
            x=10;
            Console.WriteLine($"- {producto.Nombre}: {ObtenerPrecioProducto(producto):C}");
        }
        Console.WriteLine($"Total de la Venta: {totalVenta1:C}");
    }
    

    private static decimal ObtenerPrecioProducto(Producto producto)
    {
        // Aquí podrías implementar la lógica real para obtener el precio del producto.
        // En este ejemplo, se usa un precio fijo.
        return 10.0M; // Precio de ejemplo
    }
}