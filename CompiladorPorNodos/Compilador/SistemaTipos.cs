using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class SistemaTipos
    {
        private static Dictionary<string, Dictionary<int, Dictionary<int,int>>> sistemaTipos = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>() {
            {"+"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,101 },//int,int = int
                     { 102,102 }}//int,real = real
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,102 },
                     { 102,102 }}
                },
                {120,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 120,120 }}
                }}
            },

            {"-"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,101 },//int,int = int
                     { 102,102 }}//int,real = real
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,102 },
                     { 102,102 }}
                },
                {120,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 120,120 }}
                }}
            },

            {"*"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,101 },
                     { 102,102 }}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,102 },
                     { 102,102 }}
                }}
            },

            {"/"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,102 },
                     { 102,102 }}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,102 },
                     { 102,102 }}
                }}
            },
            //============================================================
            {":="  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,1 }}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,1 },
                     { 102,1 }}
                },
                {120,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 120,1}}
                }}
            },
            {"="  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                },
                {120,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 120,205}}
                }}
            },
            {"<>"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                },
                {120,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 120,205}}
                }}
            },
            {">"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                }}
            },
            {"<"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                }}
            },
            {">="  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                }}
            },
            {"<="  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{101,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205}}
                },
                //real
                {102,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 101,205 },
                     { 102,205 }}
                }}
            },
            {"or"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{205,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 205,205 }}
                }}
            },
            {"and"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{205,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 205,205 }}
                }}
            },
            {"not"  , new Dictionary<int, Dictionary<int,int>>()
                //operando1
                //int
                {{205,new Dictionary<int,int>()
                    //ope2,resultado
                    {{ 205,205 }}
                }}
            },

        };

        private int respuesta(string operador, int op1, int op2) {
            int value;
            try
            {
                return sistemaTipos[operador][op1][op2];
            }
            catch (Exception)
            {
                Sintaxis.errorsSemantico.Add(new ErrorSemantico(508,"d",2));
                return -1;
                throw;
            }

        }

    }
}
