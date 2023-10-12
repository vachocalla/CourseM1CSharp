public class Cliente
{
    // Propiedades
    public long id { get; set; }
    public string nombre { get; set; }
    public string email { get; set; }
    public string telefono { get; set; }

    // Constructor
    public Cliente(){}
    public Cliente(
        /*long clienteId, */
        string clienteNombre, 
        string clienteEmail, 
        string clienteTelefono)
    {
        //id = clienteId;
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        nombre = clienteNombre;
        email = clienteEmail;
        telefono = clienteTelefono;
    }
    public string toString(){
        //Console.WriteLine($"{id}\t{nombre}\t{email}\t{telefono}");
        return $"{id}\t{nombre}\t{email}\t{telefono}";
    }

    public void leer(){
        //id = System.CurrentMilliseconds.
        Console.WriteLine("INGRESAR CLIENTE:");
        //Console.Write("Id:");
        //id = long.Parse(Console.ReadLine());
        id = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        Console.Write("Nombre:");
        nombre = Console.ReadLine();
        Console.Write("Email:");
        email = Console.ReadLine();
        Console.Write("Telefono:");
        telefono = Console.ReadLine();
    }
}