using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class Nodo
    {

        public string lex, 
                      tipo; //Token

        public int aux,  //Cualquier valor numerico, tipo, prioridad, posicion
                   linea;//Token

        public Nodo siguiente,
                    anterior;

        public Nodo(string dato) {
            this.lex = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Nodo(string dato, int aux) {
            this.lex = dato;
            this.aux = aux;
            this.siguiente = null;
            this.anterior = null;
        }

        //Token
        public Nodo(int valorToken, string lexema, int linea)
        {
            Dictionary<string, int> palabrasReservadas = new Dictionary<string, int>() {
                {"program"  , 200}, {"string"   , 201}, {"var"      , 202},
                {"integer"  , 203}, {"real"     , 204}, {"boolean"  , 205},
                {"begin"    , 206}, {"end"      , 207}, {"read"     , 208},
                {"write"    , 209}, {"if"       , 210}, {"then"     , 211},
                {"else"     , 212}, {"while"    , 213}, {"do"       , 214},
                {"and"      , 215}, {"or"       , 216}, {"not"      , 217},
                {"endif"    , 218}, {"endwhile" , 219}, {"true"     , 220},
                {"false"    , 221}
            };
            this.siguiente = null;
            this.anterior = null;
            this.aux = valorToken;
            if (valorToken == 100)
                this.aux = palabrasReservadas.TryGetValue(lexema, out int value) ? value : 100;
            this.linea = linea;
            this.lex = lexema;
            string temp;

            switch (this.aux)
            {
                case 100:
                    temp = "Identificador"; break;
                case 101:
                    temp = "Numero Entero"; break;
                case 102:
                    temp = "Numero Decimal"; break;

                case 103: case 104: case 105: case 106:
                    temp = "Operador Aritmético"; break;

                case 107: case 108: case 109: case 110: case 111: case 112:
                    temp = "Operador Relacional"; break;

                case 113:
                    temp = "Operador de Asignación"; break;

                case 114: case 115: case 116: case 117:
                    temp = "Símbolo de Puntuación"; break;

                case 118: case 119:
                    temp = "Símbolo de Agrupación"; break;

                case 120:
                    temp = "Cadena de Texto"; break;

                default:
                    temp = "Palabra Reservada"; break;

            }

            this.tipo = temp;
        }

        /*
        private string lex;
        public int aux;
        public Nodo sig, ant;
        

        public string Lex { get => lex; set => lex = value; }

        public Nodo(string lexema)
        {
            this.Lex = lexema;
        }

        public Nodo(string lexema,int tipo_prioridad)
        {
            this.Lex = lexema;
            this.aux = tipo_prioridad;
        }
        */
    }

    
}
