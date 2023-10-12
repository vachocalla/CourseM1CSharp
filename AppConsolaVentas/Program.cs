// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
public class Program
{
    public static List<Cliente> clientes = new List<Cliente>();
    public static List<Producto> productos = new List<Producto>();
    public static List<Venta> ventas = new List<Venta>();
    public static void Main(string[] args)
    {
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
                        Cliente c1 = new Cliente();
                        c1.leer();
                        clientes.Add(c1);
                        break;
                    case 2:
                        mostrarClientes();
                        break;
                    case 3:
                        Producto p1 = new Producto();
                        p1.leer();
                        productos.Add(p1);
                        break;
                    case 4:
                        mostrarProductos();
                        break;
                    case 5:
                        compraVenta();
                        break;
                    case 6:
                        mostrarVentas();
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

    public static void mostrarClientes(){
        Console.WriteLine( "\nCLIENTES" );
        Console.WriteLine( "No\tId\t\tNombre\tEmail\tTelefono" );
        var index = 1;
        foreach (var cliente in clientes) {
            Console.WriteLine( $"{index} \t{cliente.toString()}" );
            index++;
        }
    }
    public static void mostrarProductos(){
        Console.WriteLine( "\nPRODUCTOS" );
        Console.WriteLine( "No\tId\t\tNombre\tDescripcion\tPrecio" );
        var index = 1;
        foreach (var producto in productos) {
            Console.WriteLine( $"{index} \t{producto.toString()}" );
            index++;
        }
    }
    public static void compraVenta(){
        Console.WriteLine("\nCOMPRA VENTA");
        mostrarClientes();
        Console.Write("Seleccione el No de Persona que Compra:");
        int noCliente = int.Parse( Console.ReadLine() ) ;
        Cliente cliente = clientes[noCliente-1];
        List<CompraProducto> compraProductos = new List<CompraProducto>();

        while (true)
        {
            Console.WriteLine("\n\nMENU \n Seleccione una opción:");
            Console.WriteLine("1. Agregar Producto a Comprar");
            Console.WriteLine("0. Compra Compleda");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nCOMPRA VENTA");
                        mostrarProductos();
                        Console.Write("Seleccione el No de Producto a Comprar:");
                        int noProducto = int.Parse( Console.ReadLine() ) ;
                        Console.Write("Ingrese Cantidad a Comprar:");
                        int cantidad = int.Parse( Console.ReadLine() ) ;
                        CompraProducto cp = new CompraProducto(productos[noProducto-1], cantidad);
                        compraProductos.Add( cp );
                        break;
                    //case 0:
                    //    return; // Salir del programa
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
            }
            if(opcion==0){
                break;
            }
        }

        Venta venta = new Venta( cliente,compraProductos, DateTime.Now);
        ventas.Add(venta);
    }

    public static void mostrarVentas(){
        Console.WriteLine( "\nTODAS LAS VENTAS" );
        foreach (var venta in ventas) {
            venta.mostrarDetalleVenta();
        }
    }
    
}

/*
// Crear clientes
Cliente cliente1 = new Cliente(1, "Juan Perez", "juan@example.com", "123-456-7890");
Cliente cliente2 = new Cliente(2, "María Rodriguez", "maria@example.com", "987-654-3210");

Console.WriteLine( cliente1.toString() );
Console.WriteLine( cliente2.toString() );

Console.WriteLine(  );

// Crear productos
Producto producto1 = new Producto(101, "Tomatodo", "Para llevar el Te",10.0M);
Producto producto2 = new Producto(102, "Audifonos", "Para la musica",20.0M);

Console.WriteLine( producto1.toString() );
Console.WriteLine( producto2.toString() );

Console.WriteLine(  );

CompraProducto compraProducto1 = new CompraProducto(201, producto1, 2); // cliente1
CompraProducto compraProducto2 = new CompraProducto(202, producto2, 3); // cliente1

Console.WriteLine( compraProducto1.toString() ); // cliente1
Console.WriteLine( compraProducto2.toString() ); // cliente1
Console.WriteLine(  );

CompraProducto compraProducto3 = new CompraProducto(211, producto1, 5); // cliente2
Console.WriteLine( compraProducto3.toString() ); // cliente2
Console.WriteLine(  );

// Crear una venta
Venta venta1 = new Venta(1001, cliente1, new List<CompraProducto> { compraProducto1, compraProducto2 }, DateTime.Now);
Venta venta2 = new Venta(1002, cliente2, new List<CompraProducto> { compraProducto3 }, DateTime.Now);

venta1.mostrarDetalleVenta();
Console.WriteLine(  );
venta2.mostrarDetalleVenta();
*/