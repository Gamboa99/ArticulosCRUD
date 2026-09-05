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
        public Producto BuscarProductoPorID(int id)
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
    }
}