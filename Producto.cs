using System;
using System.Collections.Generic;
using System.Text;

namespace ArticulosCRUD
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Producto(int id, string nombre, int cantidad, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio}";
        }
    }
}