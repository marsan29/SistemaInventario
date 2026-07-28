using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Utils
{
    internal static class ConsolaHelper
    {
        public static void Pausar()
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
