using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Compilador.Lexico;

namespace Compilador
{
    public partial class compilador_Form : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        Lexico lex = new Lexico();
        Sintaxis sint = new Sintaxis();
        
        public compilador_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Aquí es para poder mover la ventana
        /// </summary>


        private void ejecutar_btn_Click(object sender, EventArgs e)
        {
            Lexico.listaToken = new ListaNodo()  ; Tokens_dataGridView.Rows.Clear();
            Lexico.listaError = new List<Error>(); Error_dataGridView.Rows.Clear();
            polish_dataGridView.Rows.Clear();
            semanticoErrors_dataGridView.Rows.Clear();

            lex.EjecutarLexico(codigoFuente_richBox.Text);

            Nodo tk = Lexico.listaToken.primero;
            while (tk != Lexico.listaToken.ultimo)
            {
                Tokens_dataGridView.Rows.Add(Tokens_dataGridView.RowCount, tk.aux, tk.lex, tk.tipo, tk.linea);
                tk = tk.siguiente;
            }

            foreach (Error er in Lexico.listaError)
                Error_dataGridView.Rows.Add(er.valorError, er.descripcion, er.linea);

            if (Lexico.listaError.Count == 0 && !Lexico.listaToken.estaVacia())
            {
                if (!sint.program())
                {
                    Error_dataGridView.Rows.Add(500, sint.p.lex, sint.p.linea);
                }
                else {
                    Nodo temp = sint.listaPolish.primero;

                    for (int i = 0; i < sint.polishSinCambio.Count; i++)
                    {
                        if (sint.polishSinCambio[i].StartsWith("%") && sint.polishSinCambio[i].EndsWith("%"))
                        {
                            polish_dataGridView.Rows.Add(sint.polishSinCambio[i].Trim('%'), (i+1 != sint.polishSinCambio.Count) ? sint.polishSinCambio[i+1] :"");
                            i++;
                            continue;
                        }
                        polish_dataGridView.Rows.Add("",sint.polishSinCambio[i]);
                    }


                    foreach (ErrorSemantico error in Sintaxis.errorsSemantico)
                    {
                        semanticoErrors_dataGridView.Rows.Add(error.valorError, error.lexema, error.descripcion, error.linea);
                    }

                    if (semanticoErrors_dataGridView.Rows.Count == 0)
                    

                        try
                        {
                            System.IO.File.WriteAllText(@"C:\CodigoObjeto\compi.asm", sint.archivoASM);
                            MessageBox.Show("El archivo en ensamblador ha sido creado exitosamente");
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.ToString());
                        }
                }

                foreach (ErrorSemantico error in Sintaxis.errorsSemantico)
                {
                    semanticoErrors_dataGridView.Rows.Add(error.valorError,error.lexema, error.descripcion, error.linea);
                }
            }
        }

        private void polish_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void compilador_Form_Load(object sender, EventArgs e)
        {

        }
    }
}

