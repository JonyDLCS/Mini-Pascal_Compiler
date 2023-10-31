using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class Error
    {
        public int valorError, linea;
        public string descripcion;

        public Error(int valorError, int linea)
        {
            this.valorError = valorError;
            this.linea = linea;
            this.descripcion = ManejoErrores(valorError);
        }

        private static string ManejoErrores(int estado)
        {

            switch (estado)
            {
                case 500:
                    return "Se esperaba un digito";

                case 501:
                    return "Símbolo no válido";

                case 502:
                    return "Se esperaba un =";

                default:
                    return "Error inesperado";

            }
        }


    }

}
