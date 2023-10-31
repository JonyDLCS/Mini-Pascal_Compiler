using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    internal class Sintaxis
    {
        public Nodo p, inicioPolish;
        private ListaNodo tk;
        private ListaNodo listaVars = new ListaNodo();
        private ListaNodo listaTemp = new ListaNodo();
        public ListaNodo listaPolish = new ListaNodo();
        private List<string[]> listaCuadruplos;
        public List<string> polishSinCambio;
        public static List<ErrorSemantico> errorsSemantico;
        public string archivoASM;
        private int numApuntadores = 0;
        private List<string> palabrasFin = new List<string> {
                "end","endif","endwhile","else"
            };
        private int tempVariables;




        // Daran true si se hizo con exito, o agregaran un error a la lista y regresaran false
        public bool program()
        {
            archivoASM = "";
            tk = Lexico.listaToken;
            listaCuadruplos = new List<string[]>();
            listaTemp = new ListaNodo();
            listaVars = new ListaNodo();
            listaPolish = new ListaNodo();
            listaPolish.agregarVar = true;
            errorsSemantico = new List<ErrorSemantico>();
            numApuntadores = 0;
            p = tk.primero;


            if (!tk.estaVacia())
            {
                if (p.aux == 200)
                {
                    p = p.siguiente;
                    if (p.aux == 100)
                    {
                        p = p.siguiente;
                        if (p.aux == 114)
                        {
                            p = p.siguiente;
                            if (block())
                            {
                                p = p.siguiente;
                                if (p.aux == 115) {
                                    polishSinCambio = new List<string>();
                                    leerPolish(inicioPolish);//la semantica fue correcta
                                    for (Nodo i = listaPolish.primero ;  i!=null; i = i.siguiente)
                                    {
                                        polishSinCambio.Add(i.lex);
                                    }
                                    Console.WriteLine("\n-LISTA POLISH-\n");
                                    for (int i = 0; i < polishSinCambio.Count; i++)
                                    {
                                        string lineaPolish = "";
                                        if (polishSinCambio[i].StartsWith("%") && polishSinCambio[i].EndsWith("%"))
                                        {
                                            lineaPolish += "|";
                                            lineaPolish += polishSinCambio[i].Trim('%');
                                            for (int j = (12 - ((polishSinCambio[i].Length < 12) ? polishSinCambio[i].Length : 12)); j > 0; j--)
                                                lineaPolish += " ";
                                            lineaPolish += "|";
                                            i++;
                                        }
                                        lineaPolish += polishSinCambio[i];

                                        for (int j = (10 - ((polishSinCambio[i].Length < 10) ? polishSinCambio[i].Length : 10)); j > 0; j--)
                                            lineaPolish += " ";
                                        if (i > 0)
                                        {
                                            Console.WriteLine((polishSinCambio[i - 1].StartsWith("%")) ? (lineaPolish + "|") : ("|          |" + lineaPolish + "|"));
                                        }
                                        else {
                                            Console.WriteLine("|          |"+lineaPolish+"|");
                                        }
                                        
                                    }
                                    crearCuadruplos();
                                    archivoASM = crearArchivoAsm();
                                    return true;
                                };
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool block()
        {
            listaTemp.agregarVar = true;
            listaVars.agregarVar = true;
            if (variableDeclarationPart())
            {
                listaTemp.agregarVar = false;
                listaVars.agregarVar = false;
                return statementPart();
            }
            return false;
        }

        private bool variableDeclarationPart()
        {
            if (p.aux == 202)
            {
                p = p.siguiente;
                return multipleVariableDeclarations(true);
            }
            return false;
        }

        private bool variableDeclaration()
        {

            if (multipleVariables(true))
            {
                if (p.aux == 116)
                {
                    p = p.siguiente;
                    return type();
                }
            }

            return false;
        }

        private bool type()
        {
            int temp = p.aux;
            if (temp == 201 || temp == 203 || temp == 204 || temp == 205)
            {
                listaTemp.type(temp);
                while (!listaTemp.estaVacia())
                {
                    listaVars.push(listaTemp.pop());
                }
                return true;
            };
            return false;
        }

        private bool statementPart()
        {
            if (p.aux == 206) {
                p = p.siguiente;
                inicioPolish = p;
                if (multipleStatements(true))
                    return p.aux == 207;

            }
            return false;
        }

        private bool statement()
        {
            Nodo temp = p;
            if (simpleStatement())
                return true;
            else
            {
                p = temp;
                return structuredStatement();
            }
        }

        private bool simpleStatement()
        {
            Nodo temp = p;
            if (assignmentStatement())
                return true;

            p = temp;
            if (readStatement())
                return true;

            p = temp;
            return writeStatement();
        }

        private bool assignmentStatement()
        {
            if (p.aux == 100)
            {
                revisarNoDeclarada();
                p = p.siguiente;
                if (p.aux == 113)
                {
                    p = p.siguiente;
                    return expresion();
                }
            }
            return false;
        }

        private bool readStatement()
        {

            if (p.aux == 208)
            {
                p = p.siguiente;
                if (p.aux == 118)
                {
                    p = p.siguiente;
                    if (multipleVariables(true)) {
                        return p.aux == 119;
                    }
                }
            }
            return false;
        }

        private bool writeStatement()
        {
            if (p.aux == 209)
            {
                p = p.siguiente;
                if (p.aux == 118)
                {
                    p = p.siguiente;
                    if (multipleVariables(true))
                    {
                        return p.aux == 119;
                    }
                    else if (p.aux == 120 || p.aux == 101 || p.aux == 102)
                    {
                        p = p.siguiente;
                        return p.aux == 119;
                    }
                }
            }


            return false;
        }

        private bool structuredStatement()
        {
            Nodo temp = p;
            if (ifStatement())
                return true;

            p = temp;
            return whileStatement();
        }

        private bool ifStatement()
        {
            if (p.aux == 210)
            {
                p = p.siguiente;
                if (p.aux ==118)
                {
                    p = p.siguiente;
                }
                if (expresion())
                {
                    p = p.siguiente;
                    if (p.aux == 119)
                    {
                        p = p.siguiente;
                    }
                    if (p.aux == 211)
                    {
                        p = p.siguiente;
                        if (multipleStatements(true))
                        {
                            if (p.aux == 212)
                            {
                                p = p.siguiente;
                                if (multipleStatements(true))
                                {
                                    return p.aux == 218;
                                }
                            }

                            return p.aux == 218;
                        }
                    }
                }
            }
            return false;
        }

        private bool whileStatement()
        {
            if (p.aux == 213)
            {
                p = p.siguiente;
                if (p.aux == 118)
                {
                    p = p.siguiente;
                }
                if (expresion())
                {
                    
                    p = p.siguiente;
                    if (p.aux == 119)
                    {
                        p = p.siguiente;
                    }
                    if (p.aux == 214)
                    {
                        p = p.siguiente;
                        if (multipleStatements(true))
                        {
                            return p.aux == 219;
                        }
                    }
                }
            }
            return false;
        }

        private bool expresion()
        {
            if (simpleExpresion(true)) {
                Nodo temp = p;
                p = p.siguiente;
                if (relationalOperator())
                {
                    p = p.siguiente;
                    return simpleExpresion(true);
                }
                p = temp;
                return true;
            }
            return false;

        }

        private bool relationalOperator()
        {
            return p.aux == 109 || p.aux == 110 || p.aux == 108 ||
                   p.aux == 107 || p.aux == 111 || p.aux == 112;
        }

        private bool simpleExpresion(bool turno)
        {
            Nodo temp = p;
            if (!turno)
            {
                if (sign())
                {
                    p = p.siguiente;
                    return term(true);
                }

                p = temp;
                if (term(true)) return true;



            }


            p = temp;
            if (simpleExpresion(false))
            {
                p = p.siguiente;
                if (addingOperator())
                {
                    p = p.siguiente;
                    return term(true);
                }
            }

            p = temp;
            if (sign())
            {
                p = p.siguiente;
                return term(true);
            }

            p = temp;
            if (term(true)) return true;



            return false;

        }

        private bool addingOperator()
        {
            return p.aux == 103 || p.aux == 104 || p.aux == 216;
        }

        private bool term(bool turno)
        {
            Nodo temp = p;

            if (turno && term(false))
            {
                p = p.siguiente;
                if (multiplyingOperator())
                {
                    p = p.siguiente;
                    return factor();
                }
            }
            p = temp;

            return factor();
        }

        private bool multiplyingOperator()
        {
            return p.aux == 105 || p.aux == 106 || p.aux == 215;
        }

        private bool factor() {
            Nodo temp = p;

            if (unsignedConstant()) return true;

            p = temp;
            if (p.aux == 100) {
                revisarNoDeclarada();
                return true;
            }

            p = temp;
            if (expresion()) return true;

            p = temp;
            if (p.aux == 217)
            {
                p = p.siguiente;
                return factor();
            }

            return false;
        }

        private bool unsignedConstant() {
            Nodo temp = p;
            if (unsignedNumber()) return true;

            p = temp;
            if (p.aux == 120) return true;

            p = temp;
            if (p.aux == 100)
            {
                revisarNoDeclarada();
                return true;
            }
            return false;


        }

        private bool unsignedNumber() {
            return p.aux == 101 || p.aux == 102;
        }

        private bool sign() {
            return p.aux == 103 || p.aux == 104;
        }




        private bool multipleVariables(bool huboComa) {
            Nodo temp = p;
            //ab,c,s:
            if (!huboComa)
            {
                if (p.aux == 117)
                {
                    p = p.siguiente;
                    return multipleVariables(true);
                }
                else
                {
                    return true;
                }
            }

            if (p.aux == 100)
            {
                if (listaTemp.agregarVar)
                    if (!listaTemp.find(p.lex) && !listaVars.find(p.lex))

                        listaTemp.push(new Nodo(p.lex));
                    else
                    {
                        errorsSemantico.Add(new ErrorSemantico(506, p.lex, p.linea));
                    }

                else
                    revisarNoDeclarada();

                p = p.siguiente;
                return multipleVariables(false);
            }


            return false;

        }


        private bool multipleStatements(bool huboPuntoComa)
        {
            Nodo temp = p;

            if (!huboPuntoComa)
            {
                if (p.aux == 114)
                {
                    p = p.siguiente;
                    return multipleStatements(true);
                }

                if (palabrasFin.Contains(p.anterior.lex))
                    return multipleStatements(true);

                return palabrasFin.Contains(p.lex);
            }

            if (statement())
            {
                p = p.siguiente;
                return multipleStatements(false);
            }

            return palabrasFin.Contains(p.lex);
        }


        private bool multipleVariableDeclarations(bool huboPuntoComa) {

            if (!huboPuntoComa)
            {
                if (p.aux == 114)
                {
                    p = p.siguiente;
                    return multipleVariableDeclarations(true);
                }

                return false;
            }

            if (variableDeclaration())
            {
                p = p.siguiente;
                return multipleVariableDeclarations(false);
            }


            return huboPuntoComa && p.aux == 206;
        }

        private void revisarNoDeclarada() {
            if (!listaVars.find(p.lex))
            {
                foreach (ErrorSemantico x in errorsSemantico)
                {
                    if (x.valorError == 507 && x.lexema.Equals(p.lex))
                        return;
                }
                errorsSemantico.Add(new ErrorSemantico(507, p.lex, p.linea));
            }
        }
        //.......................................................



        private Nodo leerPolish(Nodo inicio) {
            List<string> palabrasFin = new List<string> {
                "end","endif","endwhile","else"
            };

            Nodo Temp = inicio;
            int saltos = 0, saltos2 = 0;

            ListaNodo pilaPolish = new ListaNodo();
            pilaPolish.agregarVar = true;
            listaPolish.agregarVar = true;

            for (; Temp != tk.ultimo; Temp = Temp.siguiente)
            {
                string lex = Temp.lex;
                int x = leerPrioridad(lex);


                switch (lex)
                {
                    case "while":
                        saltos = numApuntadores; numApuntadores++;
                        listaPolish.push(new Nodo("%D" + saltos + "%"));
                        pilaPolish.push(new Nodo("("));
                        continue;
                    case "do":
                        while (!pilaPolish.estaVacia())
                        {
                            if (pilaPolish.ultimo.lex.Equals("("))
                            {
                                pilaPolish.pop();
                                break;
                            }
                            listaPolish.push(pilaPolish.pop());
                        }

                        saltos2 = numApuntadores; numApuntadores++;
                        listaPolish.push(new Nodo("JMPF C" + saltos2));
                        Temp = leerPolish(Temp.siguiente);
                        listaPolish.push(new Nodo("JMP D" + saltos));
                        listaPolish.push(new Nodo("%C" + saltos2 + "%"));
                        continue;
                    case "if":
                        pilaPolish.push(new Nodo("("));
                        continue;
                    case "then":
                        while (!pilaPolish.estaVacia())
                        {
                            if (pilaPolish.ultimo.lex.Equals("("))
                            {
                                pilaPolish.pop();
                                break;
                            }
                            listaPolish.push(pilaPolish.pop());
                        }
                        saltos = numApuntadores; numApuntadores++;
                        listaPolish.push(new Nodo("JMPF A" + saltos));
                        Temp = leerPolish(Temp.siguiente);
                        if (Temp.lex.Equals("else"))
                        {
                            saltos2 = numApuntadores; numApuntadores++;
                            listaPolish.push(new Nodo("JMP B" + saltos2));
                            listaPolish.push(new Nodo("%A" + saltos + "%"));
                            Temp = leerPolish(Temp.siguiente);
                            listaPolish.push(new Nodo("%B" + saltos2 + "%"));
                        }
                        else
                            listaPolish.push(new Nodo("%A" + saltos + "%"));
                        continue;
                    case ")":
                        while (!pilaPolish.estaVacia())
                        {
                            if (pilaPolish.ultimo.lex.Equals("("))
                            {
                                pilaPolish.pop();
                                break;
                            }

                            listaPolish.push(pilaPolish.pop());
                        }
                        if (pilaPolish.ultimo.lex.Equals("read") || pilaPolish.ultimo.lex.Equals("write"))
                        {
                            listaPolish.push(pilaPolish.pop());
                        }
                        continue;
                    case ";":
                        while (!pilaPolish.estaVacia())
                            listaPolish.push(pilaPolish.pop());
                        continue;
                    default:
                        break;
                }

                if (palabrasFin.Contains(lex))
                {
                    while (!pilaPolish.estaVacia())
                        listaPolish.push(pilaPolish.pop());
                    return Temp;
                }


                if (x == 7 && !(lex.Equals("read") || lex.Equals("write"))) {
                    listaPolish.push(new Nodo(lex));
                    continue;
                }

                if (pilaPolish.estaVacia())
                {
                    pilaPolish.push(new Nodo(lex, x));
                    continue;
                }


                while (!pilaPolish.estaVacia())
                {
                    if (pilaPolish.ultimo.aux > x || pilaPolish.ultimo.aux == 0)
                    {
                        pilaPolish.push(new Nodo(lex, x));
                        break;
                    }

                    listaPolish.push(pilaPolish.pop());
                    if (pilaPolish.estaVacia())
                    {
                        pilaPolish.push(new Nodo(lex, x));
                        break;
                    }
                }
            }
            Console.WriteLine("Lista Polish");
            return null;

        }

        private void crearCuadruplos()
        {
            List<string> operadorResultadoTemp = new List<string> {
                "+","-","/","*","<",">","<=",">=","<>","=="
            };
            List<string> operadorResultadoVar = new List<string> {
                "read",":="
            };
            List<string> operadorSinResultado = new List<string> {
                "write"
            };

            int contadorTerminos = 0;
            listaPolish.agregarVar = true;
            Nodo operando1 = null, operando2 = null;
            Nodo opRestante = null;
            bool hayVarTemp = false;
            string etiqueta = "";
            string lineaCuadruplo;
            string[] cuadruplo = new string[5];
            for (int i = 0; i < cuadruplo.Length; i++)
                cuadruplo[i] = "";


            Console.WriteLine("\n-CUADRUPLOS-\n");

            for (Nodo Actual = listaPolish.primero; Actual != null; Actual = Actual.siguiente)
            {
                if (operadorResultadoTemp.Contains(Actual.lex))      //Operadores con resultado temporal
                {
                    cuadruplo[0] = Actual.lex;
                    cuadruplo[3] = "T" +tempVariables.ToString();
                    etiqueta = cuadruplo[3];
                    if (hayVarTemp)
                    {
                        if (contadorTerminos > 0)
                        {
                            cuadruplo[2] = etiqueta;
                            Nodo terminoActual = opRestante;
                            contadorTerminos--;
                            for (int i = 0; i < contadorTerminos; i++)
                            {
                                terminoActual = opRestante.siguiente;
                            }
                            cuadruplo[1] = terminoActual.lex;
                           
                        }
                    }
                    
                    hayVarTemp = true;
                    tempVariables++;
                }
                else if (operadorResultadoVar.Contains(Actual.lex)) //Operadores con resultado en operando
                {
                    if (hayVarTemp)
                    {

                        if (contadorTerminos > 0)
                        {
                            Nodo terminoActual = opRestante;
                            contadorTerminos--;
                            for (int i = 0; i < contadorTerminos; i++)
                            {
                                terminoActual = opRestante.siguiente;
                            }
                            cuadruplo[3] = terminoActual.lex;
                            
                        }
                        
                        cuadruplo[1] = etiqueta;
                        hayVarTemp = false;
                    }
                    else
                    {
                        cuadruplo[3] = cuadruplo[1];
                        cuadruplo[1] = cuadruplo[2];
                        cuadruplo[2] = "";
                    }
                    cuadruplo[0] = Actual.lex;

                }
                else if (operadorSinResultado.Contains(Actual.lex)) //Operadores sin resultado
                {
                    cuadruplo[0] = Actual.lex;
                    hayVarTemp = false;
                }
                else if (Actual.lex.StartsWith("JMP"))
                {
                    if (hayVarTemp)
                        cuadruplo[1] = etiqueta;
                    string[] salto = Actual.lex.Split(' ');
                    cuadruplo[0] = salto[0];
                    cuadruplo[3] = salto[1];
                    hayVarTemp = false;
                }
                else if (Actual.lex.StartsWith("%") && Actual.lex.EndsWith("%"))
                {
                    cuadruplo[4] = Actual.lex.Trim('%');
                    if (Actual.siguiente == null)
                    {
                        lineaCuadruplo = "";
                        for (int i = 0; i < cuadruplo.Length; i++)
                        {
                            lineaCuadruplo += "|";
                            lineaCuadruplo += cuadruplo[i];
                            for (int j = (15 - ((cuadruplo[i].Length < 15) ? cuadruplo[i].Length : 15)); j > 0; j--)
                                lineaCuadruplo += " ";
                        }
                        Console.WriteLine(lineaCuadruplo);
                        listaCuadruplos.Add(new string[5] { cuadruplo[0], cuadruplo[1], cuadruplo[2], cuadruplo[3], cuadruplo[4] });
                        for (int i = 0; i < cuadruplo.Length; i++)
                            cuadruplo[i] = "";
                    }
                    continue;
                }
                else //Operandos
                {
                    if (operando1 == null)
                    {
                        operando1 = Actual;
                        cuadruplo[1] = Actual.lex;
                        continue;
                    }
                    else if (operando2 == null && opRestante == null)
                    {
                        operando2 = Actual;
                        cuadruplo[2] = Actual.lex;
                        continue;
                    }
                    else
                    {
                        if (opRestante == null)
                        {
                            opRestante = operando1;
                            contadorTerminos++;
                        }
                        else
                            contadorTerminos++;

                        cuadruplo[1] = cuadruplo[2];
                        operando1 = operando2;
                        cuadruplo[2] = Actual.lex;
                        operando2 = Actual;
                        continue;
                    }
                }


                lineaCuadruplo = "";
                for (int i = 0; i < cuadruplo.Length; i++)
                {
                    lineaCuadruplo += "|";
                    lineaCuadruplo += cuadruplo[i];
                    for (int j = (15 - ((cuadruplo[i].Length < 15) ? cuadruplo[i].Length : 15)); j > 0; j--)
                        lineaCuadruplo += " ";
                }
                Console.WriteLine(lineaCuadruplo);
                listaCuadruplos.Add(new string[5] { cuadruplo[0], cuadruplo[1], cuadruplo[2], cuadruplo[3], cuadruplo[4]});
                for (int i = 0; i < cuadruplo.Length; i++)
                    cuadruplo[i] = "";



                if (contadorTerminos == 0)
                {
                    opRestante = null;
                }
                operando1 = null; operando2 = null;
            }
            return;
        }

        private string crearArchivoAsm() {
            string archivoAsm = "INCLUDE MACROS.MAC\nDOSSEG\n.MODEL SMALL\nSTACK 100h\n.DATA\n";
            //SECCION VARIABLES


            for (Nodo Actual = listaVars.primero; Actual!=null; Actual = Actual.siguiente)
            {
                switch (Actual.aux)
                {
                    case 120:
                    case 201:
                        archivoAsm += "\t\t" + Actual.lex+ " DB '','$' \n" ;
                        break;
                    default:
                        archivoAsm += "\t\t" + Actual.lex +" DB ?, '$'\n";
                        break;
                }
            }


            listaVars.agregarVar = true;
            string entreDataYPrograma =".CODE\n.386\nBEGIN:\n\tMOV AX, @DATA\n\tMOV DS, AX\n\tCALL COMPI\n\tMOV AX, 4C00H\n\tINT 21H\nCOMPI PROC\n";
            //SECCION PROGRAMA
            string seccionPrograma = "";
            string variablesTemporalesDeclaracion = "";
            foreach (string[] cuad in listaCuadruplos)
            {
                for (int i = 1; i < cuad.Length-2; i++)
                    if (!listaVars.find(cuad[i])&& !cuad[i].Equals(""))
                    {
                        string valorVar = cuad[i];
                        string varNombre = "T" + tempVariables.ToString(); int varTipo;
                        if (int.TryParse(cuad[i], out _) || float.TryParse(cuad[i], out _))
                            varTipo = (int.TryParse(cuad[i], out _)) ? 203 : 204;
                        else if (cuad[i][0].Equals('"')) 
                            varTipo = 201;
                        else
                            varTipo = 205;
                        variablesTemporalesDeclaracion += "\t\t" + varNombre+ " DB "+valorVar+", '$'\n";
                        listaVars.push(new Nodo(varNombre, varTipo));
                        cuad[i] = varNombre;
                        tempVariables++;
                    }

                if (!cuad[4].Equals(""))
                {
                    seccionPrograma += "\t" + cuad[4] + ":\n";
                }
                switch (cuad[0])
                {
                    case "<":
                    case ">":
                    case "<=":
                    case ">=":
                        if ((esEntero(cuad[1]) || esReal(cuad[1])) && (esEntero(cuad[2]) || esReal(cuad[2])))
                        {
                            //VARIABLES TEMPORALES BOOLEANAS

                            listaVars.push(new Nodo(cuad[3], 205));
                            archivoAsm += "\t\t" + cuad[3] + " DB ? , '$'\n";
                            if (cuad[0].Equals("<"))
                            {
                                seccionPrograma += "\t\tI_MENOR " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";

                            }
                            else if (cuad[0].Equals(">"))
                            {
                                seccionPrograma += "\t\tI_MAYOR " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";

                            }
                            else if (cuad[0].Equals("<="))
                            {
                                seccionPrograma += "\t\tI_MENORIGUAL " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";

                            }
                            else
                                seccionPrograma += "\t\tI_MAYORIGUAL " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";

                            continue;
                        }
                        break;

                    case "==":
                    case "<>":
                        if ((esEntero(cuad[1]) || esReal(cuad[1])) && (esEntero(cuad[2]) || esReal(cuad[2])))
                        {
                            //VARIABLES TEMPORALES BOOLEANAS
                            listaVars.push(new Nodo(cuad[3], 205));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            if (cuad[0].Equals("=="))
                            {
                                seccionPrograma += "\t\tI_IGUAL " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";

                            } else
                                seccionPrograma += "\t\tI_DIFERENTES " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";


                            continue;
                        }
                        else if (esString(cuad[1]) && esString(cuad[2]))
                        {
                            //VARIABLES TEMPORALES BOOLEANAS
                            listaVars.push(new Nodo(cuad[3], 205));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            continue;
                        }
                        break;
                    case "+":
                        if (esEntero(cuad[1]) && esEntero(cuad[2]))
                        {
                            //VARIABLES TEMPORALES ENTERAS
                            listaVars.push(new Nodo(cuad[3], 203));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            seccionPrograma += "\t\tSUMAR " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        if (((esEntero(cuad[1]) || esReal(cuad[1])) && esReal(cuad[2])))
                        {
                            //VARIABLES TEMPORALES REALES
                            listaVars.push(new Nodo(cuad[3], 204));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            seccionPrograma += "\t\tSUMAR " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        else if (esString(cuad[1]) && esString(cuad[2]))
                        {
                            //VARIABLES TEMPORALES STRING
                            listaVars.push(new Nodo(cuad[3], 201));
                            archivoAsm += "\t\t" + cuad[3] + " DB '', '$'\n";
                            seccionPrograma += "\t\tCONCATENAR " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        break;
                    case "-":
                    case "*":
                        if (esEntero(cuad[1]) && esEntero(cuad[2]))
                        {

                            //VARIABLES TEMPORALES ENTERAS
                            listaVars.push(new Nodo(cuad[3], 203));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            if (cuad[0].Equals("*"))
                                seccionPrograma += "\t\tMULTI " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            else
                                seccionPrograma += "\t\tRESTA " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        if (((esEntero(cuad[1]) || esReal(cuad[1])) && esReal(cuad[2])))
                        {
                            //VARIABLES TEMPORALES REALES
                            listaVars.push(new Nodo(cuad[3], 204));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            if (cuad[0].Equals("*"))
                                seccionPrograma += "\t\tMULTI " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            else
                                seccionPrograma += "\t\tRESTA " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        break;
                    case "/":
                        if ((esEntero(cuad[1]) || esReal(cuad[1])) && (esEntero(cuad[2]) || esReal(cuad[2])))
                        {
                            //VARIABLES TEMPORALES REALES
                            listaVars.push(new Nodo(cuad[3], 204));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            seccionPrograma += "\t\tDIVIDE " + cuad[1] + ", " + cuad[2] + ", " + cuad[3] + "\n";
                            continue;
                        }
                        break;
                    case ":=":
                        if ((esEntero(cuad[1]) && esEntero(cuad[3])) ||
                           (esReal(cuad[1]) && (esReal(cuad[3]) || esEntero(cuad[3]))))
                        {
                            seccionPrograma += "\t\tI_ASIGNAR " + cuad[3] + ", " + cuad[1] + "\n";
                            continue;
                        }
                        if (esString(cuad[1]) && esString(cuad[3]))
                        {
                            seccionPrograma += "\t\tS_ASIGNAR " + cuad[3] + ", " + cuad[1] + "\n";
                            continue;
                        }
                        break;
                    case "read":
                        seccionPrograma += "\t\tREAD " + cuad[3] +"\n";
                        continue;
                    case "write":
                        if (esEntero(cuad[1]) || esReal(cuad[1]))
                        {
                            seccionPrograma += "\t\tWRITE " + cuad[1] + "\n";
                            continue;
                        }
                        if (esString(cuad[1]))
                        {
                            seccionPrograma += "\t\tWRITECADENA " + cuad[1] + "\n";
                            continue;
                        }
                        break;
                    case "or":
                    case "and":
                    case "not":
                        if (esBool(cuad[1]) || esBool(cuad[2]))
                        {
                            //VARIABLES TEMPORALES REALES
                            listaVars.push(new Nodo(cuad[3], 204));
                            archivoAsm += "\t\t" + cuad[3] + " DB ?, '$'\n";
                            continue;
                        }
                        break;
                    case "JMP":
                        seccionPrograma += "\t\t"+cuad[0]+" " + cuad[3] + "\n";
                        continue;
                    case "JMPF":
                        seccionPrograma += "\t\tJF " + cuad[1] + ", " + cuad[3] + "\n";

                        continue;
                    default:
                        break;
                }
                if (!cuad[4].Equals("")) continue;
                errorsSemantico.Add(new ErrorSemantico(508, cuad[1] + cuad[0] + cuad[2], 0));
            }



            archivoAsm += variablesTemporalesDeclaracion;
            archivoAsm += entreDataYPrograma;
            archivoAsm += seccionPrograma;
            archivoAsm += "\t\tret\nCOMPI ENDP\nEND BEGIN";
            return archivoAsm;
        }

        private bool esEntero(string cuad) {
            if (int.TryParse(cuad, out _)) return true;

            if (listaVars.find(cuad))
            {
                Nodo var = listaVars.primero;
                while (!var.lex.Equals(cuad))
                    var = var.siguiente;

                return var.aux == 203;
            }
            return false;
        }

        private bool esReal(string cuad) {
            if (float.TryParse(cuad, out _)) return true;

            if (listaVars.find(cuad))
            {
                Nodo var = listaVars.primero;
                while (!var.lex.Equals(cuad))
                    var = var.siguiente;

                return var.aux == 204;
            }
            return false;
        }

        private bool esBool(string cuad) {
            if (cuad.Equals("true")||cuad.Equals("false")) return true;

            if (listaVars.find(cuad))
            {
                Nodo var = listaVars.primero;
                while (!var.lex.Equals(cuad))
                    var = var.siguiente;

                return var.aux == 205;
            }
            return false;
        }

        private bool esString(string cuad) {
            if (cuad[0].Equals('"')) return true;

            if (listaVars.find(cuad))
            {
                Nodo var = listaVars.primero;
                while (!var.lex.Equals(cuad))
                    var = var.siguiente;

                return var.aux == 201;
            }
            return false;
        }

        private int leerPrioridad(string lexema) {
            switch (lexema)
            {
                case "(":
                case ")":
                    return 0;
                case "^":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 3;
                case ">":
                case "<":
                case "==":
                case "<=":
                case ">=":
                case "<>":
                    return 4;
                case "and":
                case "or":
                case "not":
                    return 5;
                case ":=":
                    return 6;
                default:
                    return 7;
            }
        }

    }
}
