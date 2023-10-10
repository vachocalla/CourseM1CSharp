// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("MENU \n Seleccione una opción:");
            Console.WriteLine("1. Ejemplo de if");
            Console.WriteLine("2. Ejemplo de switch");
            Console.WriteLine("3. Ejemplo de for");
            Console.WriteLine("4. Ejemplo de while");
            Console.WriteLine("5. Ejemplo de do-while");
            Console.WriteLine("0. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        EjemploIf(16);
                        break;
                    case 2:
                        EjemploSwitch();
                        break;
                    case 3:
                        EjemploFor();
                        break;
                    case 4:
                        EjemploWhile();
                        break;
                    case 5:
                        EjemploDoWhile();
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
    public static void EjemploIf(int edad)
    {
        //int edad = 25;

        if (edad >= 18)
        {
            Console.WriteLine("Eres mayor de edad.");
        }
        else
        {
            Console.WriteLine("Eres menor de edad.");
        }
    }
    public static void EjemploSwitch()
    {
        int diaSemana = 3;
        string nombreDia;

        switch (diaSemana)
        {
            case 1:
                nombreDia = "Lunes";
                break;
            case 2:
                nombreDia = "Martes";
                break;
            case 3:
                nombreDia = "Miércoles";
                break;
            default:
                nombreDia = "Día no válido";
                break;
        }

        Console.WriteLine($"Hoy es {nombreDia}.");
    }
    public static void EjemploFor()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Iteración {i}");
        }
    }
    public static void EjemploWhile()
    {
        int contador = 0;

        while (contador < 5)
        {
            Console.WriteLine($"Contador: {contador}");
            contador++;
        }
    }
    public static void EjemploDoWhile()
    {
        int contador = 0;

        do
        {
            Console.WriteLine($"Contador: {contador}");
            contador++;
        } while (contador < 5);
    }
}
