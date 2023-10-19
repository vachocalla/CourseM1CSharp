using System;
using System.ComponentModel.DataAnnotations;

namespace VentasCore;
public class Cliente
{
    // Propiedades
    [Key]
    public long id { get; set; }
    public string nombre { get; set; }
    public string email { get; set; }
    public string telefono { get; set; }

    public string toString(){
        return $"{id}\t{nombre}\t{email}\t{telefono}";
    }

    public void leer(){
        Console.WriteLine("INGRESAR CLIENTE:");
        Console.Write("Nombre:");
        nombre = Console.ReadLine();
        Console.Write("Email:");
        email = Console.ReadLine();
        Console.Write("Telefono:");
        telefono = Console.ReadLine();
    }

    public static void registrarCliente( ApplicationDbContext context ){
        Cliente c1 = new Cliente();
        c1.leer();
        context.Clientes.Add( c1 );
        context.SaveChanges();
    }

    public static void mostrarClientes( ApplicationDbContext context ){
        Console.WriteLine( "\nCLIENTES" );
        Console.WriteLine( "No\tId\t\tNombre\tEmail\tTelefono" );
        var clientes = context.Clientes.ToList();
        foreach (var cliente in clientes) {
            Console.WriteLine( $"{cliente.toString()}" );
        }
    }
}