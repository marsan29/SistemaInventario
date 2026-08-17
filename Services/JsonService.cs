using System;
using System.Collections.Generic;
using System.Text;
using SistemaInventario.Models;
using System.Text.Json;
using System.IO;
// Una excepción es un problema que puede ocurrir durante la ejecución y que podemos capturar cuando sabemos cómo manejarlo.
namespace SistemaInventario.Services
{
    internal class JsonService
    {
        private readonly string _rutaArchivoJSON = "Data/productos.json";

        public void GuardarProductos(IReadOnlyList<Producto> productos) // Guardar productos en el JSON
        {
            // De lista a JSON
            try
            {
                JsonSerializerOptions opciones = new();
                opciones.WriteIndented = true;

                string json = JsonSerializer.Serialize(productos, opciones);
                File.WriteAllText(_rutaArchivoJSON, json);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new PersistenciaException("No se pudo acceder al archivo de productos. Sin permiso", ex);
            }
            catch (IOException ex)
            {
                //Console.Clear();
                //Console.WriteLine("No se pudo guardar los productos.");
                //Thread.Sleep(5000);
                throw new PersistenciaException("No se pudo guardar el producto", ex);
            }
            catch (JsonException ex )
            {
                //Console.Clear();
                //Console.WriteLine("Ocurrió un error al convertir los productos a JSON.");
                //Thread.Sleep(5000);
                throw new PersistenciaException("No se pudo convertir el producto a JSON", ex);
            }
            
        }

        public List<Producto> CargarProductos()
        {
            // De JSON a lista
            if (!File.Exists(_rutaArchivoJSON))  // Si el archivo no existe, devuelve una lista vacía
            {
                return new List<Producto>();
            }

            try
            {                
                string json = File.ReadAllText(_rutaArchivoJSON); // Data/productos.json

                List<Producto>? productos = JsonSerializer.Deserialize<List<Producto>>(json);

                return productos ?? new List<Producto>();
            }
            catch (JsonException ex ) // Puede ocurrir si el contenido no es JSON válido.
            {                
                throw new PersistenciaException("El archivo de productos contiene un formato JSON inválido.", ex); 
                // No voy a manejar esta excepción aquí.Continúa propagándola hacia quien llamó a este método.
            }
            catch (IOException ex) // Está relacionada con problemas de entrada/salida del archivo. // No se puede leer el archivo Archivo bloqueado o Problemas con el sistema de archivos
            {
               

                throw new PersistenciaException("No se pudo leer/cargar el archivo de productos.", ex); ;
            }
        }
    }
}
