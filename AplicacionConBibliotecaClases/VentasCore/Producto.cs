
using System;
using System.ComponentModel.DataAnnotations;

namespace VentasCore;

public class Producto
{
    [Key]
    public long id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal precio { get; set; }

    public string toString(){
        return $"{id}\t{nombre}\t{descripcion}\t{precio}";
    }

    public void leer(){
        Console.WriteLine("INGRESE PRODUCTO:");
        Console.Write("Nombre:");
        nombre = Console.ReadLine();
        Console.Write("Descripcion:");
        descripcion = Console.ReadLine();
        Console.Write("Precio:");
        precio = decimal.Parse(Console.ReadLine());
    }

    public static void registrarProducto( ApplicationDbContext context ){
        Producto p1 = new Producto();
        p1.leer();
        context.Productos.Add( p1 );
        context.SaveChanges();
    }

    public static void mostrarProductos( ApplicationDbContext context ){
        Console.WriteLine( "\nPRODUCTOS" );
        Console.WriteLine( "No\tId\t\tNombre\tDescripcion\tPrecio" );
        var productos = context.Productos.ToList();
        foreach (var producto in productos) {
            Console.WriteLine( $"{producto.toString()}" );
        }
    }
}