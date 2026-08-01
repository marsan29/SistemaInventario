
using SistemaInventario.Services;
using SistemaInventario.UI;

ProductoService productoService = new (); // No crees las dependencias dentro de la clase.
                                          // Recíbelas desde afuera.
MenuPrincipal menu = new(productoService);

menu.Iniciar();

