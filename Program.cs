namespace ArticulosCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titulo = "Gestor de Articulos";
            string[] opciones = ["Agregar", "Listar", "Buscar", "Modificar", "Eliminar"];
            Menu menu = new Menu(titulo, opciones);
            menu.MostrarMenu();
        }
    }
}