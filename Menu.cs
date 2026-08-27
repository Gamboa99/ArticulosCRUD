using System;
using System.Collections.Generic;
using System.Text;

namespace ArticulosCRUD
{
    internal class Menu
    {
        public Menu()
        {

        }

        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar) 
            {
                Console.Clear();
                Console.WriteLine("Gestor de Articulos");
                Console.WriteLine("===================");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Buscar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("0. Salir");
                string opcion = Console.ReadLine() ?? ""; 
                switch(opcion) 
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        MostrarAgregar();
                        break;
                    case "2":
                        MostrarListar();
                        break;
                    case "3":
                        MostrarBuscar();
                        break;
                    case "4":
                        MostrarModificar();
                        break;
                    case "5":
                        MostrarEliminar();
                        break;

                    default:
                        Console.WriteLine("Opción Invalida");
                        Console.ReadLine();
                        break;
                }
            }
          

        }
        public void MostrarAgregar() 
        {
            Console.Clear();
            Console.WriteLine("Opción Agregar Seleccionada");
            Console.ReadLine();
        }
        public void MostrarListar() 
        {
            Console.Clear();
            Console.WriteLine("Opción Listar Seleccionada");
            Console.ReadLine();
        }
        public void MostrarBuscar() 
        {
            Console.Clear();
            Console.WriteLine("Opción Buscar Seleccionada");
            Console.ReadLine();
        }
        public void MostrarModificar()
        {
            Console.Clear();
            Console.WriteLine("Opción Modificar Seleccionada");
            Console.ReadLine();
        }
        public void MostrarEliminar() 
        {
            Console.Clear();
            Console.WriteLine("Opción Eliminar Seleccionada");
            Console.ReadLine();
        }
    }
}
