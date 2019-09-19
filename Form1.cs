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
        Button btnJugar;
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
        //List<LabelTextBox> lblText;
        LabelTextBox labelText;
        private void btnJugar_Click(object sender, EventArgs e)
        {
            string[] lista = new string[3];
            lista[0] = "nº jugadores";
            lista[1] = "nº botones";
            lista[2] = "n º secuencias";
            btnJugar.Visible = false;
            lbl.Visible = true;
            //lblText = new List<LabelTextBox>();
            labelText = new Simon_Dice.LabelTextBox();
            labelText.Location = new System.Drawing.Point(292, 104);
            labelText.Name = "labelTextBox1";
            labelText.Posicion = Simon_Dice.LabelTextBox.ePosicion.IZQUIERDA;
            labelText.Separacion = 0;
            labelText.Size = new System.Drawing.Size(253, 150);
            labelText.TabIndex = 1;
            labelText.Tamaño = 100;
            labelText.TextLbl = "lbl";
            labelText.TextTxt = "";
            Controls.Add(labelText);
        }

    }
}
