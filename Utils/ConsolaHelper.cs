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

        public static int LeerEntero(string mensaje)
        {
            
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int entero)) //Guard clause?
                {
                    return entero;
                }

                Console.WriteLine("Ingresa un numero entero");
            }
        }

        public static decimal LeerDecimal(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if(decimal.TryParse(Console.ReadLine(),out decimal numerodecimal))
                {
                    return numerodecimal;
                }

                Console.WriteLine("Entrada no válida. Ingresa un número ");
            }
        }

        public static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto) || int.TryParse(texto, out _))
                {
                    Console.WriteLine("Ingresa un nombre válido");
                    continue;
                }

                return texto;
            }
        }

    }
}
