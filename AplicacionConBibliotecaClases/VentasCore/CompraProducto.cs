
using System;
using System.ComponentModel.DataAnnotations;

namespace VentasCore;
public class CompraProducto
{
    [Key]
    public long id { get; set; }
    public Producto producto { get; set; }
    public int cantidad { get; set; }

    public decimal costoCompra(){
        return producto.precio * cantidad;
    }

    public string toString(){
        return $"{id} \t{producto.nombre} \t{producto.precio} \t{cantidad} \t{costoCompra()}";
    }
}