
using System;
using System.ComponentModel.DataAnnotations;

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
}