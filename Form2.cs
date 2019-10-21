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
    }
}
