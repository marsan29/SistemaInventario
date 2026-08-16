using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Services
{
    internal class PersistenciaException : Exception // Exception Wrapping o empaquetado de excepciones
    {
        // una excepción personalizada:
        public PersistenciaException(string mensaje, Exception exepcionOriginal) : base (mensaje, exepcionOriginal) // -> Le pasa esos datos al constructor de Exception.
        {

        }
    }
}
