
using SistemaInventario.Services;
using SistemaInventario.UI;
using SistemaInventario.Utils;
//   program.cs crea las dependencias

try
{
    JsonService jsonService = new JsonService(); // Creamos el objeto encargado de trabajar con el archivo JSON.

    // Crea un ProductoService y le damos este JsonService que ya existe.
    ProductoService productoService = new(jsonService); // No crees las dependencias dentro de la clase.
                                                        // Recíbelas desde afuera.

    MenuPrincipal menu = new(productoService); // Estamos pasando una dependencia

    menu.Iniciar();
}
catch(PersistenciaException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("No se pudieron cargar los productos.");
    ConsolaHelper.Pausar();
}



//TryParse → entrada inválida.
//ArgumentException → regla del objeto incumplida.
//PersistenciaException → problema al guardar/cargar datos.