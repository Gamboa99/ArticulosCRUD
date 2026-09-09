using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArticulosCRUD
{
    internal class Menu
    {
        private readonly string Titulo;
        private readonly string[] Opciones;
        public ManejadorArticulos Manejador { get; set; }

        public Menu(string titulo, string[] opciones)
        {
            Titulo = titulo;
            Opciones = opciones;
            Manejador = new ManejadorArticulos();
        }

        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine(Titulo);
                Console.WriteLine(new string('=', Titulo.Length));
                for (int i = 0; i < Opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Opciones[i]}");
                }
                //Console.WriteLine("Gestor de artículos");
                //Console.WriteLine("===================");
                //Console.WriteLine("1. Agregar");
                //Console.WriteLine("2. Listar");
                //Console.WriteLine("3. Buscar");
                //Console.WriteLine("4. Modificar");
                //Console.WriteLine("5. Eliminar");
                Console.WriteLine("0. salir");
                string opcion = Console.ReadLine() ?? "";
                switch (opcion)
                {
                    case "1":

                        MostrarAgregar();
                        break;
                    case "2":

                        MostrarListar();
                        break;
                    case "3":

                        MostrarMenuBuscar();
                        break;
                    case "4":

                        MostrarModificar();
                        break;
                    case "5":

                        MostrarEliminar();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción Inválida.");
                        Console.ReadLine();
                        break;
                }
            }

        }

        public void MostrarMenuBuscar()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine(Titulo);
                Console.WriteLine(new string('=', Titulo.Length));
                for (int i = 0; i < Opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Opciones[i]}");
                }
                Console.WriteLine("Buscar artículos");
                Console.WriteLine("===================");
                Console.WriteLine("1. Por ID");
                Console.WriteLine("2. Por Nombre");
                //Console.WriteLine("3. Buscar");
                //Console.WriteLine("4. Modificar");
                //Console.WriteLine("5. Eliminar");
                Console.WriteLine("0. salir");
                string opcion = Console.ReadLine() ?? "";
                switch (opcion)
                {
                    case "1":

                        MostrarBuscar();
                        break;
                    case "2":

                        MostrarBuscarNombre();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción Inválida.");
                        Console.ReadLine();
                        break;
                }
            }

        }

        public void MostrarAgregar()
        {
            Console.Clear();
            Console.WriteLine("Agregar Producto");
            Console.WriteLine("=================");
            Console.WriteLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            decimal precio = decimal.TryParse(Console.ReadLine(), out decimal valor) ? valor : 0;
            Console.Write("Cantidad: ");
            int cantidad = int.TryParse(Console.ReadLine(), out int valor2) ? valor2 : 0;
            Manejador.AgregarProducto(nombre, cantidad, precio);
            Console.WriteLine("Producto creado correctamente");
            Console.ReadLine();
        }

        public void MostrarListar()
        {
            Console.Clear();
            Console.WriteLine("Listar Productos");
            Console.WriteLine("=================");
            Manejador.ListarProductos();
            Console.ReadLine();
        }

        public void MostrarBuscar()
        {
            int id;
            Console.Clear();
            Console.WriteLine("Buscar producto");
            Console.WriteLine("==========================");
            id = PedirValorEntero("ID");
            Producto resultado = Manejador.BuscarProductoID(id);
            if (resultado != null)
            {
                Console.WriteLine(resultado.ToString());
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.ReadLine();
        }

        public void MostrarBuscarNombre()
        {
            Console.Clear();
            Console.WriteLine("Buscar Por Nombre");
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            foreach (Producto item in Manejador.BuscarProductosPorNombre(nombre))
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public int PedirValorEntero(string v)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor no valido Ingresa nuevamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void MostrarModificar()
        {
            Console.Clear();
            Console.WriteLine("Modificar Producto");
            Console.WriteLine("==================");
            Console.Write("ID: ");
            int id = PedirValorEntero("ID");
            Producto producto = Manejador.BuscarProductoID(id);
            if (producto != null)
            {
                Console.WriteLine($"Producto encontrado: {producto.ToString()}");
                Console.Write("Nuevo Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Nuevo Precio: ");
                decimal precio = decimal.TryParse(Console.ReadLine(), out decimal valor) ? valor : 0;
                Console.Write("Nueva Cantidad: ");
                int cantidad = int.TryParse(Console.ReadLine(), out int valor2) ? valor2 : 0;
                Manejador.ModificarProducto(id, nombre, cantidad, precio);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.ReadLine();
        }

        public void MostrarEliminar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Producto");
            Console.WriteLine("==================");
            Console.Write("ID: ");
            int id = PedirValorEntero("ID del producto");
            Producto? producto = Manejador.BuscarProductoID(id);
            if (producto != null)
            {
                Console.WriteLine($"Producto encontrado: {producto.ToString()}");
                Console.WriteLine("¿Está seguro que desea eliminar este producto? (s/n)");
                string respuesta = Console.ReadLine()?.Trim() ?? "n";
                if (respuesta.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    Manejador.EliminarProducto(id);
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            Console.ReadLine();
        }

    }
}