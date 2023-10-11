public class Cliente
{
    // Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    // Constructor
    public Cliente(int id, string nombre, string email, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        Telefono = telefono;
    }
}