using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
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
        private void Form2_Load(object sender, EventArgs e)
        {

            query = "Select * from puntuaciones";
            obtenerDatos(query);

        }

        public void obtenerDatos(string query)
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

            textBox1.Text = datos;
        }

        private void DeAAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY nombre asc";
            obtenerDatos(query);
        }

        private void DeZAAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY nombre desc";
            obtenerDatos(query);
        }

        private void DeMenorAMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY puntuacion asc";
            obtenerDatos(query);
        }

        private void DeMayorAMenorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY puntuacion desc";
            obtenerDatos(query);
        }

        private void DeRecienteAAntiguaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY fecha desc";
            obtenerDatos(query);
        }

        private void DeAntiguaARecienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query = "select * from puntuaciones ORDER BY fecha asc";
            obtenerDatos(query);
        }

        private void JugadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = "";

            if (ShowInputDialog("Nombre", false) == DialogResult.OK)
            {
                nombre = textBox.Text;
                query = "select * from puntuaciones where nombre='" + nombre + "'";
                obtenerDatos(query);
            }
        }

        public TextBox textBox, textBox2;
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
                    Form1.MuestraMensaje("Formato no valido", 0);
                }
                catch (OverflowException)
                {
                    Form1.MuestraMensaje("Numero demasiado grande", 0);
                }

            }
        }


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
                    Form1.MuestraMensaje("Fecha no válida", 0);
                }

            }
        }

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
                    Form1.MuestraMensaje("Rango de fechas no válido", 0);
                }
            }
        }
    }
}
