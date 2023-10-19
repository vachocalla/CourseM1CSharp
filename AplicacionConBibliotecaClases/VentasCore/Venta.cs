
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VentasCore;
public class Venta
{
    [Key]
    public long id { get; set; }
    public Cliente cliente { get; set; }
    public List<CompraProducto> compraProductos { get; set; }
    public DateTime fechaVenta { get; set; }

    public static void compraVenta(ApplicationDbContext context){
        Console.WriteLine("\nCOMPRA VENTA");
        Cliente.mostrarClientes(context);
        Console.Write("Seleccione el 'id cliente ' que Comprara: ");
        long noCliente = long.Parse( Console.ReadLine() ) ;
        //Cliente cliente = context.Clientes.FirstOrDefault( x => x.id==noCliente );
        Cliente cliente = context.Clientes.Where( x => x.id==noCliente ).FirstOrDefault();

        List<CompraProducto> compraProductos = new List<CompraProducto>();

        while (true)
        {
            Console.WriteLine("\n\nMENU \n Seleccione una opción:");
            Console.WriteLine("1. Agregar Producto a Comprar");
            Console.WriteLine("0. Compra Completada");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nCOMPRA VENTA");
                        Producto.mostrarProductos( context );
                        Console.Write("Seleccione el 'id producto' a Comprar:");
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
        var ventas = context.Ventas.Where(v => true).Include(v => v.cliente).Include(v => v.compraProductos  ).ToList();
        
        foreach (var venta in ventas) {
            Cliente cliente = venta.cliente;
            Console.WriteLine($"Cliente: {cliente.nombre}");
            Console.WriteLine($"Productos Comprados:");
            List<CompraProducto> compraProductos = venta.compraProductos;
            
            decimal total = 0;
            foreach (var compraProducto in compraProductos)
            {
                var cp = context.CompraProductos.Where(x => x.id == compraProducto.id ).Include(x=>x.producto).FirstOrDefault();
                Console.WriteLine($"\t {compraProducto.toString()}");
                total = total + compraProducto.costoCompra();
            }
            Console.WriteLine($"Total Compra: {total}");
        }


    }

}