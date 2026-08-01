using System;
using System.Collections.Generic;
using System.Text;
using SistemaInventario.Models;

namespace SistemaInventario.Services;

internal class ProductoService
{
    private readonly List<Producto> _productos = new(); // private no puede ser modificada readonly no se pude reasignar otra lista 
    private int _nextId = 1;
    public void AgregarProducto(Producto producto)
    {
        producto.Id = _nextId;
        _nextId++;
        _productos.Add(producto);   

    }

    public IReadOnlyList<Producto> ObtenerProductos()
    {
        return _productos;
    }

    public Producto? BuscarPorId(int id)
    {
        foreach(Producto producto in _productos)
        {            
            if (producto.Id.Equals(id)) 
            { 
                return producto;
            }
        }

        return null;
    }

    public void EliminarProducto(Producto producto)
    {
        _productos.Remove(producto);
    }

}
