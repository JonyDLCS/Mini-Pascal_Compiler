using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compilador.Nodo;

namespace Compilador
{
    internal class ListaNodo
    {
        public bool agregarVar;
        public Nodo primero = null;
        public Nodo ultimo = null;

        public bool estaVacia()
        {
            return primero == null;
        }

        public void push(Nodo a)
        {
            if (agregarVar)
            {
                if (estaVacia())
                {
                    this.primero = a;
                    this.ultimo = a;
                    a.siguiente = null;
                    a.anterior = null;
                }
                else
                {
                    a.anterior = ultimo;
                    ultimo.siguiente = a;
                    a.siguiente = null;
                    ultimo = a;
                }
            }
        }

        public Nodo borrarInicio()
        {
            Nodo resultado;
            Nodo sig;
            if (!estaVacia())
            {
                resultado = primero;
                sig = primero.siguiente;
                primero = sig;
                if (primero == null) ultimo = null;
                return resultado;
            }
            else return null;
        }

        public void type(int tipoDato)
        {
            Nodo aux;
            aux = primero;
            if (agregarVar)
                while (aux != null)
                {
                    aux.aux = tipoDato;
                    aux = aux.siguiente;
                }

        }

        public Nodo pop()
        {
            Nodo resultado;
            if (!this.estaVacia())
            {

                if (primero.siguiente != null)
                {
                    resultado = ultimo;
                    ultimo = ultimo.anterior;
                    ultimo.siguiente = null;
                    return resultado;
                }
                else
                {
                    resultado = primero;
                    primero = null;
                    ultimo = null;
                    return resultado;
                }
            }
            else return null;
        }

        public bool find(string valor)
        {
            Nodo aux = primero;
            int posicion = 0;
            if (!this.estaVacia())
            {
                while (!aux.lex.Equals(valor))
                {
                    if (aux == ultimo) return false;
                    aux = aux.siguiente;
                    posicion++;
                }
                return true;
            }
            return false;
        }

        public void insertaInicio(Nodo a)
        {
            if (primero == ultimo && primero == null)
            {
                primero = a;
                ultimo = a;
                a.siguiente = null;
            }
            else
            {
                a.siguiente = primero;
                primero = a;
            }
        }

        public void recorreLista()
        {
            Nodo aux;
            aux = primero;
            while (aux != null)
            {
                Console.WriteLine(aux.lex);
                aux = aux.siguiente;
            }
        }


        /*
       
        private List<Nodo> nodos= new List<Nodo>();

        internal List<Nodo> Nodos { get => nodos; set => nodos = value; }
        public bool AgregarVar { get => agregarVar; set => agregarVar = value; }

        public void push(Nodo nodo) {
            if (AgregarVar)
                this.Nodos.Add(nodo);
            
        }
        public Nodo pop()
        {
            if (Nodos.Count > 0)
            {
                Nodo temp = Nodos[Nodos.Count - 1];
                Nodos.RemoveAt(Nodos.Count - 1);
                return temp;
            }
            return null;
       
        }

        public bool find(string lexema) {
            foreach (Nodo x in Nodos)
                if (x.Lex.Equals(lexema))
                    return true;

            return false;
        }

        

      public Nodo last() {
            return Nodos.Count > 0? Nodos[Nodos.Count - 1]: new Nodo("error");
        }

        */
    }
}
