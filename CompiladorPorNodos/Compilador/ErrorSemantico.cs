using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class ErrorSemantico
    {
        public int valorError, linea;
        public string descripcion;
        public string lexema;

        public ErrorSemantico(int valorError,string lexema, int linea)
        {
            this.valorError = valorError;
            this.linea = linea;
            this.descripcion = ManejoErrores(valorError);
            this.lexema = lexema;
        }

        private static string ManejoErrores(int estado)
        {

            switch (estado)
            {
                case 506:
                    return "Variable Multideclarada";

                case 507:
                    return "Variable No Declarada";

                case 508:
                    return "Incompatibilidad de Tipos";

                default:
                    return "Error inesperado";

            }
        }
    }
}
