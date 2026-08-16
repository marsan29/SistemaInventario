using System;
using System.Collections.Generic;
using System.Text;
using SistemaInventario.Models;

namespace SistemaInventario.Services;
internal class ProductoService
{
    private readonly List<Producto> _productos; // private no puede ser modificada, readonly no se pude reasignar otra lista 
    private int _nextId = 1;
    private readonly JsonService _jsonService;

    public ProductoService(JsonService jsonservice) // Constructor
    { 
        this._jsonService = jsonservice; // Recibe el objeto 
        this._productos = _jsonService.CargarProductos(); // Se carga el JSON.

        if (_productos.Count > 0)
        {
            this._nextId = _productos.Max(producto => producto.Id) + 1; // Busca el ID más grande de todos los productos y sumale 1
        }
    }

    public void AgregarProducto(Producto producto) // Create
    {
        producto.Id = _nextId;
        _nextId++;
        _productos.Add(producto);
        _jsonService.GuardarProductos(_productos);
    }

    public IReadOnlyList<Producto> ObtenerProductos() // READ
    {
        return _productos; // Regresa la lista
    }

    public Producto? BuscarPorId(int id) // READ
    {
        foreach(Producto producto in _productos)
        {            
            if (producto.Id.Equals(id)) 
            { 
                return producto; // Retorna el producto que coincida con el ID
            }
        }

        return null; // Retorna Nulo si no se encontró el producto
    }
    public void ActualizarProducto() // UPDATE
    {
        _jsonService.GuardarProductos(_productos); // Guarda la lista a JSON en su estado actual
    }

    public void EliminarProducto(Producto producto) // DELETE
    {
        _productos.Remove(producto);
        _jsonService.GuardarProductos(_productos);
    }

}
