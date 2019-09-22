using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon_Dice
{
    public partial class Form1 : Form
    {
        Button btnJugar, btnAceptar;
        public Form1()
        {
            InitializeComponent();

            btnJugar = new Button();
            btnJugar.Size = new Size(80, 30);
            btnJugar.Location = new Point(Width / 2 - btnJugar.Width, Height / 2 - btnJugar.Height);
            btnJugar.Text = "Jugar";
            btnJugar.Visible = true;
            btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            Controls.Add(btnJugar);
            lbl.Location = new Point(Width / 2 - lbl.Width, Height * 2 / 15 - lbl.Height);
            lbl.Visible = false;
        }

        List<Modo> modo;
        private void btnJugar_Click(object sender, EventArgs e)
        {
            string[] lista = new string[3];
            lista[0] = "nº jugadores";
            lista[1] = "nº botones(3-8)";
            lista[2] = "n º secuencias";
            btnJugar.Visible = false;
            lbl.Visible = true;

            int y = 50;

            LabelTextBox labelText ;
            modo = new List<Modo>();
            Modo mod;
            for(int i=0; i<3; i++)
            {
                labelText = new LabelTextBox();
                labelText.Size = new Size(20, 150);
                labelText.Location = new Point(lbl.Location.X-20, y);
                labelText.Tamaño = 30;
                labelText.TextLbl = lista[i];
                labelText.Visible = true;
                labelText.Separacion = 10;

                Controls.Add(labelText);
                y += 30;

                mod = new Modo(labelText, false);
                modo.Add(mod);
            }

            btnAceptar = new Button();
            btnAceptar.Location = new Point(lbl.Location.X, modo[2].labelText.Location.Y+ 30);
            btnAceptar.Size = new Size(80, 30);
            btnAceptar.Text = "Aceptar";
            btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            btnAceptar.Visible = true;
            Controls.Add(btnAceptar);
        }

        public void Comprueba(int numero)
        {
            string error="";
            int num=0;
            try
            {
                
                num = Convert.ToInt32(modo[numero].labelText.TextTxt);
                switch (numero)
                {
                    case 0:
                        if (num < 1)
                        {
                            MessageBox.Show("Numero de jugadores no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modo[numero].flag = false;
                        }
                        else
                        {
                            modo[numero].flag = true;
                        }
                        break;
                    case 1:
                        if (num < 3 || num > 8)
                        {
                            MessageBox.Show("Numero de botones no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modo[numero].flag = false;
                        }
                        else
                        {
                            modo[numero].flag = true;
                        }
                        break;
                    case 2:
                        if (num < 1)
                        {
                            MessageBox.Show("Numero de secuencias no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            modo[numero].flag = false;
                        }
                        else
                        {
                            modo[numero].flag = true;
                        }

                        break;
                }
            }
            catch (OverflowException)
            {
                modo[numero].flag = false;
                switch (numero)
                {
                    case 0:
                        error = "Numero de jugadores elevado";                       
                        break;
                    case 1:
                        error="Numero de botones elevado";
                        break;
                    case 2:
                        error="Numero de secuencias elevada";
                        break;
                }
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                modo[numero].flag = false;
                switch (numero)
                {
                    case 0:
                        error="Numero de jugadores no valido";
                        break;
                    case 1:
                        error= "Numero de botones no valido";
                        break;
                    case 2:
                        error= "Numero de secuencias no valido";
                        break;
                }
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            for(int i=0; i<3; i++)
            {
                Comprueba(i);
            }
            if(modo[0].flag==true && modo[1].flag == true && modo[2].flag == true)
            {
                
                for(int i=0; i<3; i++)
                {
                    modo[i].labelText.Visible = false;
                }
                btnAceptar.Visible = false;
                Jugadores();
            }
        }

        public void Jugadores()
        {

        }

        }
}
