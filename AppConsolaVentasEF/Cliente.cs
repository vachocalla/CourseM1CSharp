using System;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    // Propiedades
    [Key]
    public long id { get; set; }
    public string? nombre { get; set; }
    public string? email { get; set; }
    public string? telefono { get; set; }

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
}