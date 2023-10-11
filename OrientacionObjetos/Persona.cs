public class Persona{
    // Atributos (propiedades)
    public string Ci { get; set; }
    public string Nombre { get; set; }

    public int Edad { get; set; }

    // Método
    public void Saludar()
    {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Ci: {Ci}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
    }
}