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

        private void Form2_Load(object sender, EventArgs e)
        {
            string conexion = "Server=localhost;Database=db;User ID=root;Password=;Pooling=false;";
            MySqlConnection conn = new MySqlConnection(conexion);
            conn.Open();

            string query = "Select * From puntuaciones";

            MySqlCommand mycomand = new MySqlCommand(query, conn);

            string datos = "";

            MySqlDataReader myreader = mycomand.ExecuteReader();

            while (myreader.Read())
            {
                datos+=myreader["nombre"].ToString()+" "+ myreader["puntuacion"].ToString();
                datos += Environment.NewLine;
            }

            textBox1.Text = datos;
           

        }

       
    }
}
