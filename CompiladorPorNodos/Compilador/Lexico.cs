using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class Lexico
    {
        private string codigoFuente;    // atributo que representa la ENTRADA del lexico.
        private int linea;
        public static ListaNodo listaToken = new ListaNodo();
        public static List<Error> listaError = new List<Error>();
        

        private int[,] matrizTransicion =
        /*		l		d		+		-		*		/		;		.		:		,		(		)		"		>		<		=		/s		/n		/t		oc	*/
 /*	0	*/  {{  1   ,   2   ,   103 ,   104 ,   105 ,   5   ,   114 ,   115 ,   8   ,   117 ,   118 ,   119 ,   9   ,   10  ,   11  ,   12  ,   0   ,   0   ,   0   ,   501 },
/*	1	*/	{   1   ,   1   ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 ,   100 },
/*	2	*/	{   101 ,   2   ,   101 ,   101 ,   101 ,   101 ,   101 ,   3   ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 ,   101 },
/*	3	*/	{   500 ,   4   ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 ,   500 },
/*	4	*/	{   102 ,   4   ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 ,   102 },
/*	5	*/	{   106 ,   106 ,   106 ,   106 ,   6   ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 ,   106 },
/*	6	*/	{   6   ,   6   ,   6   ,   6   ,   7   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   },
/*	7	*/	{   6   ,   6   ,   6   ,   6   ,   6   ,   -1   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   ,   6   },
/*	8	*/	{   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   116 ,   113 ,   116 ,   116 ,   116 ,   116 },
/*	9	*/	{   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   120 ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   ,   9   },
/*	10	*/	{   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   107 ,   108 ,   107 ,   107 ,   107 ,   107 },
/*	11	*/	{   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   109 ,   112 ,   109 ,   110 ,   109 ,   109 ,   109 ,   109 },
/*	12	*/	{   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   502 ,   111 ,   502 ,   502 ,   502 ,   502 }};


        


        public void EjecutarLexico(string codigoFuente)
        {
            linea = 1;
            char charActual;
            string lexema = "";
            codigoFuente += " ";
            int estado = 0, columna; // presenta la columna de la matriz
            listaToken.agregarVar = true;
            char[] caracteres = codigoFuente.ToCharArray();

            for (int puntero = 0; puntero < caracteres.Length; puntero++)
            {
                charActual = caracteres[puntero] ;

                if (charActual.Equals('\n'))
                {
                    linea++;
                }

                lexema += charActual;
                columna = RegresarColumna(charActual);
                estado = matrizTransicion[estado, columna];

                if (estado == 0 && lexema.Length != 0)
                    lexema = lexema.Remove(lexema.Length - 1);

                if (estado == -1)
                {
                    lexema = "";
                    estado = 0;
                }
                
                if (estado >= 100) //detectar estados finales
                {
                    if (lexema.Length > 1 && (
                        estado != 108 &&
                        estado != 110 &&
                        estado != 111 &&
                        estado != 112 &&
                        estado != 113 &&
                        estado != 120))
                    {
                        lexema = lexema.Remove(lexema.Length - 1);
                        puntero--;
                    }

                    if (estado >= 500)
                    {
                        listaError.Add(new Error(estado,linea));
                        estado = 0; lexema = "";
                        continue;
                    }

                    listaToken.push(new Nodo(estado, lexema, linea)); //agrego el tokena a la lista
                    estado = 0; lexema = "";
                }
            }
        } //metodo principal de la clase lexico



        private int RegresarColumna(char caracter)
        {
            if (char.IsLetter(caracter))
            {
                return 0;
            }
            else if (char.IsDigit(caracter))
            {
                return 1;
            }
            else if (caracter.Equals('+'))
            {
                return 2;
            }
            else if (caracter.Equals('-'))
            {
                return 3;
            }
            else if (caracter.Equals('*'))
            {
                return 4;
            }
            else if (caracter.Equals('/'))
            {
                return 5;
            }
            else if (caracter.Equals(';'))
            {
                return 6;
            }
            else if (caracter.Equals('.'))
            {
                return 7;
            }
            else if (caracter.Equals(':'))
            {
                return 8;
            }
            else if (caracter.Equals(','))
            {
                return 9;
            }
            else if (caracter.Equals('('))
            {
                return 10;
            }
            else if (caracter.Equals(')'))
            {
                return 11;
            }
            else if (caracter.Equals('"'))
            {
                return 12;
            }
            else if (caracter.Equals('>'))
            {
                return 13;
            }

            else if (caracter.Equals('<'))
            {
                return 14;
            }
            else if (caracter.Equals('='))
            {
                return 15;
            }

            else if (caracter.Equals(' '))
            {
                return 16;
            }
            else if (caracter.Equals('\n'))
            {
                return 17;
            }

            else if (caracter.Equals('\t'))
            {
                return 18;
            }
            else  //simbolo desconocido
            {
                return 19;
            }
        }



    }
}
