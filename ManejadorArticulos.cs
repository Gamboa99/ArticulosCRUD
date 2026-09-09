using System;
using System.Collections.Generic;
using System.Text;

namespace ArticulosCRUD
{
    internal class ManejadorArticulos
    {
        private List<Producto> ListaProductos;
        public ManejadorArticulos()
        {
            ListaProductos = new List<Producto>();
        }
        public void AgregarProducto(string nombre, int cantidad, decimal precio)
        {
            Producto producto = new Producto(ListaProductos.Count + 1, nombre, cantidad, precio);
            ListaProductos.Add(producto);
        }
        public void ListarProductos()
        {
            foreach (Producto item in ListaProductos)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public Producto BuscarProductoID(int id)
        {
            foreach (Producto producto in ListaProductos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }
            return null;
        }
        public List<Producto> BuscarProductosPorNombre(string nombre)
        {
            return ListaProductos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void ModificarProducto(int id, string nombre, int cantidad, decimal precio)
        {
            Producto producto = BuscarProductoID(id);
            if (producto != null)
            {
                producto.Nombre = nombre;
                producto.Cantidad = cantidad;
                producto.Precio = precio;
                Console.WriteLine("Producto actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(int id)
        {
            Producto producto = BuscarProductoID(id);
            if (producto != null)
            {
                ListaProductos.Remove(producto);
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }


    }
}