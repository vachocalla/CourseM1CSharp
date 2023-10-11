public class Empleado : Persona
{
    // Ci
    // Nombre
    // Edad
    public decimal Salario { get; set; }

    public void MostrarDatos()
    {
        Console.WriteLine($"Ci: {Ci}");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Salario: {Salario}");
    }

}