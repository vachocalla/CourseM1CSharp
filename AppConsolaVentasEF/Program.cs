// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

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
                        Cliente c1 = new Cliente();
                        c1.leer();
                        context.Clientes.Add( c1 );
                        context.SaveChanges();
                        break;
                    case 2:
                        mostrarClientes(context);
                        break;
                    case 3:
                        Producto p1 = new Producto();
                        p1.leer();
                        context.Productos.Add( p1 );
                        context.SaveChanges();
                        break;
                    case 4:
                        mostrarProductos(context);
                        break;
                    case 5:
                        compraVenta(context);
                        break;
                    case 6:
                        mostrarVentas(context);
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

    public static void mostrarClientes( ApplicationDbContext context ){
        Console.WriteLine( "\nCLIENTES" );
        Console.WriteLine( "No\tId\t\tNombre\tEmail\tTelefono" );
        var clientes = context.Clientes.ToList();
        foreach (var cliente in clientes) {
            Console.WriteLine( $"{cliente.toString()}" );
        }
    }

    public static void mostrarProductos( ApplicationDbContext context ){
        Console.WriteLine( "\nPRODUCTOS" );
        Console.WriteLine( "No\tId\t\tNombre\tDescripcion\tPrecio" );
        var productos = context.Productos.ToList();
        foreach (var producto in productos) {
            Console.WriteLine( $"{producto.toString()}" );
        }
    }
    public static void compraVenta(ApplicationDbContext context){
        Console.WriteLine("\nCOMPRA VENTA");
        mostrarClientes(context);
        Console.Write("Seleccione el No de Persona que Compra:");
        long noCliente = long.Parse( Console.ReadLine() ) ;
        Cliente cliente = context.Clientes.FirstOrDefault( x => x.id==noCliente );
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
                        mostrarProductos( context );
                        Console.Write("Seleccione el No de Producto a Comprar:");
                        long noProducto = long.Parse( Console.ReadLine() ) ;
                        Producto producto = context.Productos.FirstOrDefault( x => x.id==noProducto );
                        Console.Write("Ingrese Cantidad a Comprar:");
                        int cantidad = int.Parse( Console.ReadLine() ) ;
                        CompraProducto cp = new CompraProducto{
                            producto=producto , 
                            cantidad=cantidad
                        };
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

        foreach (var cps in compraProductos) {
            context.CompraProductos.Add(cps);
            context.SaveChanges();
        }

        Venta venta = new Venta{
            cliente=cliente,
            compraProductos=compraProductos,
            fechaVenta=DateTime.Now
        };
        context.Ventas.Add(venta);
        context.SaveChanges();
    }

    public static void mostrarVentas(ApplicationDbContext context){
        Console.WriteLine( "\nTODAS LAS VENTAS" );
        var ventas = context.Ventas.ToList();
        
        foreach (var venta in ventas) {
            venta.mostrarDetalleVenta();
        }
    }
}

/*
var cliente1 = new Cliente{
            nombre = "Juan Perez",
            email = "juan@juan",
            telefono = "123",
        };
        context.Clientes.Add( cliente1 );
        context.SaveChanges();
*/

/*var cliente2 = new Cliente();
        cliente2.leer();

        context.Clientes.Add( cliente2 );
        context.SaveChanges();*/

/*var cliente2 = new Cliente();
        cliente2.leer();

        context.Clientes.Add( cliente2 );
        context.SaveChanges();*/