using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SistemaInventario.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        private decimal _precio;
        public decimal Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                if (value <=  0)
                {
                    throw new ArgumentException("El precio debe ser mayor que cero", nameof(value));

                }
                _precio = value;
            }
        }
        private int _stock;

        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                if (value < 0) 
                {
                    throw new ArgumentException("El stock debe ser mayor o igual que cero", nameof(value));
                }

                _stock = value;
            }
        }
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nNombre: {Nombre}\nPrecio: {Precio:C2}\nStock: {Stock}\nCategoria: {CategoriaId}";
        }
    }
}
