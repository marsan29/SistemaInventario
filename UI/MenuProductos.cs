using SistemaInventario.Services;
using SistemaInventario.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaInventario.Models;
using System.Runtime.CompilerServices;

namespace SistemaInventario.UI;

internal class MenuProductos
{
    private readonly string _separador = new('=', 41); // es un dato propio del menú.
    private readonly ProductoService _productoService;
    public MenuProductos (ProductoService productoService)
    {
        this._productoService = productoService;
    }

    public void Iniciar()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            MostrarBanner();
            MostrarOpciones();
            string? opcion = LeerOpcion();

            ProcesarOpcion(opcion, ref salir);

        }
    }

    private void MostrarBanner() 
    {

        Console.WriteLine(_separador);
        Console.WriteLine($"{new string(' ', 8)}PRODUCTOS");
        Console.WriteLine(_separador);

    }

    private void MostrarOpciones()
    {
        Console.WriteLine();
        Console.WriteLine("1. Agregar producto");
        Console.WriteLine("2. Listar productos");
        Console.WriteLine("3. Buscar producto");
        Console.WriteLine("4. Editar producto");
        Console.WriteLine("5. Eliminar producto");
        Console.WriteLine("0. Volver");
        Console.WriteLine();
    }

    private string LeerOpcion()
    {
        Console.Write("Seleccione una opción: ");
        return Console.ReadLine();
    }

    private void ProcesarOpcion(string opcion, ref bool salir) 
    {
        if (string.IsNullOrWhiteSpace(opcion)) // Aplicamos Guard Clause 
        {                                       // (Evaluamos primero los casos que pueden causar problemas)
            return;                             // salir temprano cuando un dato no es válido.
        }

        switch (opcion.Trim())
        {
            case "1":
                AgregarProducto();
                break;
            case "2":
                ListarProductos();
                break;
            case "3":
                BuscarProducto();
                break;
            case "4":
                EditarProducto();
                break;
            case "5":
                EliminarProducto();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                salir = true;
                break;
            default:
                Console.WriteLine("Ingresa una opción válida");
                break;
        }
        ConsolaHelper.Pausar();
    }

    private void AgregarProducto()
    {
        Console.Clear();
        Console.WriteLine("==== AGREGAR PRODUCTO ====");

        Producto producto = new();
        
        producto.Nombre = ConsolaHelper.LeerTexto("Nombre: ");

        producto.Precio = ConsolaHelper.LeerDecimal("Precio: ");
        
        producto.Stock = ConsolaHelper.LeerEntero("Stock Inicial: ");

        producto.CategoriaId = ConsolaHelper.LeerEntero("Categoría: ");

        _productoService.AgregarProducto(producto);

        Console.WriteLine("Producto agregado correctamente");
    }

    private void ListarProductos()
    {
        IReadOnlyList<Producto> productos = _productoService.ObtenerProductos();

        if (productos.Count.Equals(0)) // Guard clause?
        {
            Console.WriteLine("No hay productos registrados");
            return;
        }
        Console.Clear();
        Console.WriteLine("\n==== PRODUCTOS ====");

        foreach (Producto producto in productos)
        {
            Console.WriteLine();
            Console.WriteLine(producto);
        }
    }

    private void BuscarProducto()
    {
        Console.Clear();
        Console.WriteLine("==== BUSCAR PRODUCTO ====");
        Console.WriteLine();
        int id = ConsolaHelper.LeerEntero("Ingrese el Id: ");
        Console.WriteLine();
        Producto? producto = _productoService.BuscarPorId(id);

        Console.WriteLine(producto?.ToString() ?? "Producto no encontrado."); // operador de propagación nula y el de coalescencia:

    }

    private void EditarProducto()
    {
        Console.Clear();
        Console.WriteLine("==== EDITAR PRODUCTO ====");
        Console.WriteLine();
        int id = ConsolaHelper.LeerEntero("Ingrese el Id: ");
        Console.WriteLine();
        Producto? producto = _productoService.BuscarPorId(id);

        if (producto is null)
        {
            Console.WriteLine("Producto no encontrado");
            return;
        }
        else
        {
            Console.WriteLine("Producto encontrado");
            Console.WriteLine(producto);
            Console.WriteLine();
        }

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("¿Qué desea editar?");
            MostrarOpciones();
            string? opcion = LeerOpcion();

            ProcesarOpcion(opcion, ref salir);
        }

         void MostrarOpciones()
        {
            Console.WriteLine();
            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Precio");
            Console.WriteLine("3. Stock");
            Console.WriteLine("4. Categoría");
            Console.WriteLine("0. Cancelar");
            Console.WriteLine();
        }

        void ProcesarOpcion(string opcion, ref bool salir)
        {
            if (string.IsNullOrWhiteSpace(opcion)) 
            {                                       
                return;                             
            }

            switch (opcion.Trim())
            {
                case "1":
                    EditarNombre(producto);
                    break;
                case "2":
                    EditarPrecio(producto);
                    break;
                case "3":
                    EditarStock(producto);
                    break;
                case "4":
                    EditarCategoria(producto);
                    break;               
                case "0":
                    Console.WriteLine("Saliendo del menu edicion...");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Ingrese una opcion válida");
                    break;
            }
        }        
    }

    private void EditarNombre(Producto producto)
    {
        Console.Clear();
        Console.WriteLine("===== EDITANDO NOMBRE =====");
        Console.WriteLine();
        producto.Nombre = ConsolaHelper.LeerTexto("Ingresa el nuevo nombre: ");
        Console.Clear();
        Console.WriteLine("Nombre Actualizado");
        Console.WriteLine();
        Console.WriteLine(producto);

    }

    private void EditarPrecio(Producto producto)
    {
        Console.Clear();
        Console.WriteLine("===== EDITANDO PRECIO =====");
        Console.WriteLine();
        producto.Precio = ConsolaHelper.LeerDecimal("Ingresa el nuevo precio: ");
        Console.Clear();
        Console.WriteLine("Precio Actualizado");
        Console.WriteLine();
        Console.WriteLine(producto);
    }

    private void EditarStock(Producto producto)
    {
        Console.Clear();
        Console.WriteLine("===== EDITANDO STOCK =====");
        Console.WriteLine();
        producto.Stock = ConsolaHelper.LeerEntero("Ingresa el nuevo stock: ");
        Console.Clear();
        Console.WriteLine("Stock Actualizado");
        Console.WriteLine();
        Console.WriteLine(producto);
    }

    private void EditarCategoria(Producto producto)
    {
        Console.Clear();
        Console.WriteLine("===== EDITANDO CATEGORIA =====");
        Console.WriteLine();
        producto.CategoriaId = ConsolaHelper.LeerEntero("Ingresa la nueva categoría: ");
        Console.Clear();
        Console.WriteLine("Categoria Actualizada");
        Console.WriteLine();
        Console.WriteLine(producto);
    }

    private void EliminarProducto()
    {
        Console.Clear();
        Console.WriteLine("==== ELIMINAR PRODUCTO ====");
        int id = ConsolaHelper.LeerEntero("Ingrese el Id: ");

        Producto producto = _productoService.BuscarPorId(id);

        if (producto is null)
        {
            Console.WriteLine("Producto no encontrado");
            return;
        }
        else
        {
            Console.WriteLine("Producto encontrado");
            Console.WriteLine(producto);
            Console.WriteLine();
        }


        while (true)
        {
            Console.Write("¿Está seguro de eliminar este producto? (S/N): ");
            string opcion = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrWhiteSpace(opcion) )
            {
                Console.WriteLine("Ingrese una opción");
                continue;
            }
            else if (opcion.Equals("s"))
            {
                _productoService.EliminarProducto(producto);
                Console.WriteLine("Producto eliminado correctamente.");
                return;
            }
            else if (opcion.Equals("n"))
            {
                Console.WriteLine("Operacion cancelada");
                return;
            }
            else
            {
                Console.WriteLine("Ingrese una opcion (S/N) ");
            }
        }
        
    }
}
