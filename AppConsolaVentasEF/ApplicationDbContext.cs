
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext{
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Producto> Productos {get; set;}
    public DbSet<CompraProducto> CompraProductos {get; set;}
    public DbSet<Venta> Ventas {get; set;}
    

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ){
        if( !optionsBuilder.IsConfigured ){
            optionsBuilder.UseSqlServer("Server=LAPTOP-A7F9UEK5\\SQLEXPRESS; Database=AppConVentasEF; Integrated Security=True; Encrypt=false;");
        }
    }
}