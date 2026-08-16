using System;
using System.Collections.Generic;
using System.Text;
using SistemaInventario.Services;
using SistemaInventario.Utils;
namespace SistemaInventario.UI; 

internal class MenuPrincipal
{
    private readonly string _separador = new('=', 41); // es un dato propio del menú.
    private readonly ProductoService productoService;
    public MenuPrincipal(ProductoService productoService)
    {
        this.productoService = productoService;
    }
    public void Iniciar()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            MostrarBanner();
            MostrarOpciones();
            string? opcion = ConsolaHelper.LeerOpcion();

            ProcesarOpcion(opcion, ref salir);

        }

    }

    private void MostrarBanner()
    {
        Console.WriteLine(_separador);
        Console.WriteLine($"{new string(' ', 8)}SISTEMA DE INVENTARIO");
        Console.WriteLine(_separador);
    }

    private void MostrarOpciones()
    {
        Console.WriteLine();
        Console.WriteLine("1. Productos");
        Console.WriteLine("2. Categorías");
        Console.WriteLine("3. Entradas");
        Console.WriteLine("4. Salidas");
        Console.WriteLine("5. Reportes");
        Console.WriteLine("0. Salir");
        Console.WriteLine();            
    }

    private void ProcesarOpcion(string? opcion, ref bool salir)
    {
        if (string.IsNullOrWhiteSpace(opcion)) // Aplicamos Guard Clause 
        {                                       // (Evaluamos primero los casos que pueden causar problemas)
            return;                             // salir temprano cuando un dato no es válido.
        }

        switch (opcion)
        {
            case "1":
                MostrarMenuProductos();
                break;
            case "2":
                MostrarMenuCategorias();
                break;
            case "3":
                MostrarMenuEntradas();
                break;
            case "4":
                MostrarMenuSalidas();
                break;
            case "5":
                MostrarMenuReportes();
                break;
            case "0":
            //case "salir":
                Console.WriteLine("¡Hasta luego!");
                salir = true;
                break;
            default:
                Console.WriteLine("Ingresa una opción válida");
                ConsolaHelper.Pausar();
                break;
        }

        //ConsolaHelper.Pausar();
    }

    //private string? LeerOpcion()
    //{
    //    Console.Write("Seleccione una opción: ");
    //    return Console.ReadLine();
    //}

    private void MostrarMenuProductos()
    {
        MenuProductos menuProductos = new(productoService); // target-typed new // Inyecccion de dependencias
        menuProductos.Iniciar();
    }

    private void MostrarMenuCategorias()
    {
        Console.WriteLine("Módulo Categorías en construcción.");
        ConsolaHelper.Pausar();
    }

    private void MostrarMenuEntradas()
    {
        Console.WriteLine("Módulo Entradas en construcción.");
        ConsolaHelper.Pausar();
    }

    private void MostrarMenuSalidas()
    {
        Console.WriteLine("Módulo Salidas en construcción.");
        ConsolaHelper.Pausar();
    }

    private void MostrarMenuReportes()
    {
        Console.WriteLine("Módulo Reportes en construcción.");
        ConsolaHelper.Pausar();
    }


}

