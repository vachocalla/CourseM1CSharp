// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
public class Program
{
    public static void Main(string[] args)
    {
        Persona persona1 = new Persona();
        persona1.Ci = "13564";
        persona1.Nombre = "Juan Perez";
        persona1.Edad = 22;
        persona1.MostrarDatos();
        persona1.Saludar();

        Console.WriteLine($"");

        Empleado empleado1 = new Empleado();
        empleado1.Ci = "987";
        empleado1.Nombre = "Maria F";
        empleado1.Edad = 25;
        empleado1.Salario = 12000.50M;
        empleado1.MostrarDatos();
        empleado1.Saludar();
    }
}