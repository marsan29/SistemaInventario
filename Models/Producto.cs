using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nNombre: {Nombre}\nPrecio: {Precio:C2}\nStock: {Stock}\nCategoria: {CategoriaId}";
        }
    }
}
