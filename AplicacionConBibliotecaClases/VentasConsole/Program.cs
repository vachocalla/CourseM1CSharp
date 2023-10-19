using VentasCore;

public class Program{
    public static void Main(string[] args){
        using var context = new ApplicationDbContext();
        
        while (true)
        {
            Console.WriteLine("\n\nMENU \n Seleccione una opción:");
            Console.WriteLine("1. Registrar Cliente");
            Console.WriteLine("2. Mostrar Clientes");
            Console.WriteLine("3. Registrar Producto");
            Console.WriteLine("4. Mostrar Productos");
            Console.WriteLine("5. Realizar Compra/Venta");
            Console.WriteLine("6. Mostrar Ventas");
            Console.WriteLine("0. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Cliente.registrarCliente(context);
                        break;
                    case 2:
                        Cliente.mostrarClientes(context);
                        break;
                    case 3:
                        Producto.registrarProducto( context );
                        break;
                    case 4:
                        Producto.mostrarProductos(context);
                        break;
                    case 5:
                        Venta.compraVenta(context);
                        break;
                    case 6:
                        Venta.mostrarVentas(context);
                        break;
                    case 0:
                        return; // Salir del programa
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
            }
        }

    }

    
    
    
}

/*var cliente1 = new Cliente{
    nombre = "Juan Perez",
    email = "juan@juan",
    telefono = "123",
};
context.Clientes.Add( cliente1 );
context.SaveChanges();

Console.WriteLine("Finalizado");

var producto1 = new Producto();
producto1.leer();

context.Productos.Add( producto1 );
context.SaveChanges();

Console.WriteLine("Finalizado");*/