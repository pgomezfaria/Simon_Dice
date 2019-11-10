using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon_Dice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string query;
        public TextBox textBox, textBox2;
        private void Form2_Load(object sender, EventArgs e)
        {

            query = "Select * from puntuaciones";
            obtenerDatos(query);

        }

        /// <summary>
        /// Obtiene los datos de la base de datos
        /// </summary>
        /// <param name="query">Sentencia sql</param>
        public void obtenerDatos(string query)
        {
            try
            {
                string conexion = "Server=localhost;Database=db;User ID=root;Password=;Pooling=false;";
                MySqlConnection conn = new MySqlConnection(conexion);
                conn.Open();

                MySqlCommand mycomand = new MySqlCommand(query, conn);

                string datos = "";

                MySqlDataReader myreader = mycomand.ExecuteReader();

                while (myreader.Read())
                {
                    datos += myreader["nombre"].ToString() + " " + myreader["puntuacion"].ToString();
                    datos += Environment.NewLine;
                }

                if (datos == "")
                {
                    datos = "No se han encontrado resultados";
                }
                textBox1.Text = datos;
            }
            catch (MySqlException)
            {
                Form1.MuestraMensaje("Error al intentar la conexion", 1);
            }
            
        }

        /// <summary>
        /// Click ordenar por el nombre de A a Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeAAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY nombre asc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click ordenar por el nombre de Z a A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeZAAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY nombre desc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click ordenar por la puntuación de menor a mayor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeMenorAMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY puntuacion asc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click ordenar por la puntuación de mayor a menor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeMayorAMenorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY puntuacion desc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click ordenar por la fecha de más reciente a más antigua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeRecienteAAntiguaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY fecha desc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click ordenar por la fecha de más antigua a más reciente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeAntiguaARecienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY fecha asc";
            obtenerDatos(query);
        }

        /// <summary>
        /// Click buscar jugador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JugadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = "";

            if (ShowInputDialog("Nombre", false) == DialogResult.OK)
            {
                try
                {
                     Convert.ToInt16(textBox.Text);
                    Form1.MuestraMensaje("Parámetro no válido", 1);
                }
                catch (FormatException)
                {
                    nombre = textBox.Text;
                    query = "select * from puntuaciones where nombre='" + nombre + "'";
                    obtenerDatos(query);
                }
                catch (OverflowException)
                {
                    Form1.MuestraMensaje("Parámetro no válido", 1);
                }
                
                
            }
        }

       

        /// <summary>
        /// Muestra input dialog
        /// </summary>
        /// <param name="tit"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private DialogResult ShowInputDialog(string tit , bool flag)
        {
            int x = 0, y = 0, tam;
            if (flag)
            {
                tam = 90;
                y = 55;
            }
            else
            {
                tam = 70;
                y = 40;
            }
            
            System.Drawing.Size size = new System.Drawing.Size(400, tam);
            Form inputBox = new Form();

            inputBox.MaximizeBox=false;
            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Introduzca "+tit;

            textBox = new TextBox();
            if (flag)
            {
                textBox.Text = "Fecha inicial";
                textBox.GotFocus += new EventHandler(this.TextGotFocus);
                textBox.LostFocus += new EventHandler(this.TextLostFocus);
                textBox.Name = "txt1";
            }
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            inputBox.Controls.Add(textBox);
            

            if (flag)
            {
                
                textBox2 = new TextBox();
                textBox2.Text = "Fecha final";
                textBox2.Size = new System.Drawing.Size(size.Width - 10, 33);
                textBox2.Location = new System.Drawing.Point(5, 30);
                inputBox.Controls.Add(textBox2);
                textBox2.GotFocus += new EventHandler(this.TextGotFocus);
                textBox2.LostFocus += new EventHandler(this.TextLostFocus);
                textBox2.Name = "txt2";
            }
            

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, y);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, y);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();

            return result;
        }

       /// <summary>
       /// Click buscar puntuación
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void PuntuacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int punt = 0;

            if (ShowInputDialog("Puntuacion", false) == DialogResult.OK)
            {
                try
                {
                    punt = Convert.ToInt32(textBox.Text);
                    query = "select * from puntuaciones where puntuacion=" + punt;
                    obtenerDatos(query);
                }
                catch (FormatException)
                {
                    Form1.MuestraMensaje("Formato no valido", 1);
                }
                catch (OverflowException)
                {
                    Form1.MuestraMensaje("Numero demasiado grande", 1);
                }

            }
        }

        /// <summary>
        /// Obtiene donde entra el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Fecha inicial")
            {
                textBox.Text = "";
            }
            if (tb.Text == "Fecha final")
            {
                textBox2.Text = "";
            }
        }

        /// <summary>
        /// Obtiene donde sale el foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "" && tb.Name == "txt1")
            {
                textBox.Text = "Fecha inicial";
            
            }
            if (tb.Text == "" && tb.Name == "txt2")
            {
                textBox2.Text = "Fecha final";

            }
        }

        /// <summary>
        /// Click buscar fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string fecha = "";
            if (ShowInputDialog("Fecha(yy-mm-dd)", false) == DialogResult.OK)
            {
                fecha = textBox.Text;
                try
                {
                    Convert.ToDateTime(fecha);
                    query = "select * from puntuaciones where fecha='" + fecha + "'";

                    obtenerDatos(query);
                }
                catch (FormatException)
                {
                    Form1.MuestraMensaje("Fecha no válida", 1);
                }

            }
        }

        /// <summary>
        /// Click buscar rango de fechas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangoFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowInputDialog("Rango de fechas(yy-mm-dd)", true) == DialogResult.OK)
            {
                string inicial,final;
                try
                {
                    inicial = textBox.Text;
                    final = textBox2.Text;
                    Convert.ToDateTime(inicial);
                    Convert.ToDateTime(final);
                    query = "select * from puntuaciones where fecha between'" + inicial + "' AND '" + final + "'";
                    obtenerDatos(query);
                }
                catch (FormatException)
                {
                    Form1.MuestraMensaje("Rango de fechas no válido", 1);
                }
            }
        }

        /// <summary>
        /// Click guardar puntuaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarPuntuacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarPuntuaciones();
        }

        /// <summary>
        /// Guarda las puntuaciones en un archivo
        /// </summary>
        public void GuardarPuntuaciones()
        {

            string directory;
            directory = Environment.GetEnvironmentVariable("homepath");
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();        
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "puntuaciones.txt";
            saveFileDialog1.InitialDirectory = "c:"+directory;
            
            
            if (textBox1.Text != "No se han encontrado resultados")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter s = new StreamWriter(saveFileDialog1.FileName))
                        {
                            s.Write(textBox1.Text);
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Form1.MuestraMensaje("Error ArgumentNullException", 1);
                    }
                    catch (ArgumentException)
                    {
                        Form1.MuestraMensaje("Error ArgumentException", 1);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Form1.MuestraMensaje("Error DirectoryNotFoundException", 1);
                    }
                    catch (PathTooLongException)
                    {
                        Form1.MuestraMensaje("Error PathTooLongException", 1);
                    }
                    catch (IOException)
                    {
                        Form1.MuestraMensaje("Error IOException", 1);
                    }
                    
                    
                }

            }
            else
            {
                Form1.MuestraMensaje("No hay puntuaciones para guardar", 0);
            }
        }
    }
}
