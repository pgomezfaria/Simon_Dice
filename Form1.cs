using MySql.Data.MySqlClient;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Simon_Dice
{
    public partial class Form1 : Form
    {
        Button btnJugar, btnAceptar;
        List<ToolStripMenuItem> listaTool = new List<ToolStripMenuItem>();
        public Form1()
        {
            InitializeComponent();
          
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\musica.wav";
            
            player.Play();

            btnJugar = new Button();
            btnJugar.Size = new Size(80, 30);
            btnJugar.Location = new Point(Width / 2 - btnJugar.Width, 100);
            btnJugar.Text = "Jugar";
            btnJugar.Visible = true;
            btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            Controls.Add(btnJugar);
            lbl.Location = new Point(Width / 2 - lbl.Width-20, 30);
            lbl.Visible = false;
            checkBox1.Visible = false;
            coloresToolStripMenuItem.Visible = false;
            listaTool.Add(boton1ToolStripMenuItem);
            listaTool.Add(boton2ToolStripMenuItem);
            listaTool.Add(boton3ToolStripMenuItem);
            listaTool.Add(boton4ToolStripMenuItem);
            listaTool.Add(boton5ToolStripMenuItem);
            listaTool.Add(boton6ToolStripMenuItem);
            listaTool.Add(boton7ToolStripMenuItem);
            listaTool.Add(boton8ToolStripMenuItem);
            for (int i = 0; i < listaTool.Count; i++)
            {
                listaTool[i].Visible = false;
            }
            coloresBoton = new List<Color>();
            coloresBoton.Add(Color.Red);
            coloresBoton.Add(Color.Green);
            coloresBoton.Add(Color.Blue);
            coloresBoton.Add(Color.Black);
            coloresBoton.Add(Color.Yellow);
            coloresBoton.Add(Color.Brown);
            coloresBoton.Add(Color.Pink);
            coloresBoton.Add(Color.Orange);
        }

        List<Modo> modo;
        LabelTextBox labelText;
        Modo mod;
        int y = 50;

        int numSecu;
        bool nuevaPartida = true;
        private void btnJugar_Click(object sender, EventArgs e)
        {
            coloresToolStripMenuItem.Visible = false;
            for (int i = 0; i < listaTool.Count; i++)
            {
                listaTool[i].Visible = false;
            }
            if (sender.ToString()=="&Nueva partida")
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que quiere empezar una nueva partida?", "Simon Dice", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    nuevaPartida = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    nuevaPartida = false;
                }
            }
            
            if (nuevaPartida)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Visible = false;
                }
                menuStrip1.Visible = true;
                lbl.Visible = true;

                jugadores = new List<Jugador>();
                jugadoresEliminados = new List<Jugador>();
                modo = new List<Modo>();
                listaBotones = new List<Button>();
                
                secuencia = new Button();

                checkBox1.Visible = false;
                if (modo.Count > 0)
                {              
                    modo.Clear();
                }
                if (listaBotones.Count > 0)
                {
                    
                        listaBotones.Clear();
                    
                }
                if (jugadoresEliminados.Count > 0)
                {
                    jugadoresEliminados.Clear();
                }

                if (jugadores.Count > 0)
                {
                    jugadores.Clear();
                }
                if (listaBotones.Count > 0)
                {
                    listaBotones.Clear();
                }
                if (secuencia.Visible)
                {
                    secuencia.Visible = false;
                }
                if (coloresBoton.Count > 0)
                {
                    coloresBoton.Clear();
                }




                checkBox1.Location = new Point(lbl.Location.X + 80, lbl.Location.Y);
                checkBox1.Visible = true;

                string[] lista = new string[3];
                lista[0] = "nº jugadores";
                lista[1] = "nº botones(3-8)";
                lista[2] = "n º secuencias";
                btnJugar.Visible = false;
                lbl.Visible = true;

                y = lbl.Location.Y + 20;
                for (int i = 0; i < 3; i++)
                {
                    labelText = new LabelTextBox();
                    labelText.Size = new Size(20, 150);
                    labelText.Location = new Point(lbl.Location.X - 20, y);
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
                btnAceptar.Location = new Point(lbl.Location.X, modo[2].labelText.Location.Y + 30);
                btnAceptar.Size = new Size(80, 30);
                btnAceptar.Text = "Aceptar";
                btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
                btnAceptar.Visible = true;
                Controls.Add(btnAceptar);
            }
            
        }
        int numBotones;
        public void Comprueba(int modoJuego, int numero)
        {
            string error = "";
            int num = 0;
            try
            {
                if (modoJuego == 1)
                {
                    num = Convert.ToInt32(modo[numero].labelText.TextTxt);
                    switch (numero)
                    {
                        case 0:
                            if (num < 1)
                            {
                                MuestraMensaje("Numero de jugadores no válido", 1);
                                
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
                                MuestraMensaje("Numero de botones no válido", 1);                
                                modo[numero].flag = false;
                            }
                            else
                            {
                                modo[numero].flag = true;
                                numBotones = num;
                            }
                            break;
                        case 2:
                            if (num < 1)
                            {
                                MuestraMensaje("Numero de secuencias no válida", 1);                             
                                modo[numero].flag = false;
                            }
                            else
                            {
                                modo[numero].flag = true;
                                numSecu = num;
                            }

                            break;
                    }
                }
                else
                {
                    if (modo[numero].labelText.TextTxt == "")
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        modo[numero].flag = true;
                    }
                }
                
            }
            catch (OverflowException)
            {
                if (modoJuego == 1)
                {
                    modo[numero].flag = false;
                    switch (numero)
                    {
                        case 0:
                            error = "Numero de jugadores elevado";
                            break;
                        case 1:
                            error = "Numero de botones elevado";
                            break;
                        case 2:
                            error = "Numero de secuencias elevada";
                            break;
                    }
                    MuestraMensaje(error, 1);
                    
                }
                    
            }
            catch (FormatException)
            {
                if (modoJuego == 1)
                {
                    modo[numero].flag = false;
                    switch (numero)
                    {
                        case 0:
                            error = "Numero de jugadores no valido";
                            break;
                        case 1:
                            error = "Numero de botones no valido";
                            break;
                        case 2:
                            error = "Numero de secuencias no valido";
                            break;
                    }
                    MuestraMensaje(error, 1);
                    
                }
                else
                {
                    modo[numero].flag = false;
                    int jugador=numero+1;
                    MuestraMensaje("Jugador " + jugador + " no válido", 1);
                                      
                }
                    
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Comprueba(1,i);
            }
            if (modo[0].flag == true && modo[1].flag == true && modo[2].flag == true)
            {

                for (int i = 0; i < 3; i++)
                {
                    modo[i].labelText.Visible = false;
                }
                btnAceptar.Visible = false;
                Jugadores();
            }
        }
        Button btnAcept;
        bool flagChecked = false;
        public void Jugadores()
        {
            
            if (checkBox1.Checked)
            {
                flagChecked = true;
            }
            else
            {
                flagChecked = false;
            }
            checkBox1.Visible = false;
            
            y = 50;
            int num = Convert.ToInt32(modo[0].labelText.TextTxt);
            modo.Clear();
            int j = 1;
            for (int i = 0; i < num; i++)
            {
                labelText = new LabelTextBox();
                labelText.Size = new Size(20, 150);
                labelText.Location = new Point(lbl.Location.X - 20, y);
                labelText.Tamaño = 60;
                labelText.TextLbl = "Jugador " + j;
                labelText.Visible = true;
                labelText.Separacion = 10;
                Controls.Add(labelText);
                y += 30;
                mod = new Modo(labelText, false);
                modo.Add(mod);
                j++;
            }

            btnAcept = new Button();
            btnAcept.Location = new Point(lbl.Location.X, modo[num-1].labelText.Location.Y + 30);
            btnAcept.Size = new Size(80, 30);
            btnAcept.Text = "Aceptar";
            btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            btnAcept.Visible = true;
            Controls.Add(btnAcept);
        }
        static List<Jugador> jugadores;
        Jugador jugador;
        List<Color> colores;
        private void btnAcept_Click(object sender, EventArgs e)
        {
            bool flag = false;

            for(int i=0; i<modo.Count; i++)
            {
                Comprueba(2, i);
            }
            for(int i=0; i<modo.Count; i++)
            {
                if (modo[i].flag == false)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                lbl.Visible = false;
                Juego();
                
            }
            
        }

        Button botonesJuego;
         List<Color> coloresBoton;
        List<Button> listaBotones;
        List<Jugador> jugadoresEliminados;
        Color color;
       
        static Button secuencia;
        public void Juego()
        {
            
            
            

            coloresToolStripMenuItem.Visible = true;
            for (int i = 0; i < numBotones; i++)
            {
                listaTool[i].Visible = true;
            }

            

            


            for (int i=0; i<modo.Count; i++)
            {
                colores = new List<Color>();
                jugador = new Jugador(modo[i].labelText.TextTxt, colores, 0);
                jugadores.Add(jugador);
                modo[i].labelText.Visible = false;
            }
            
            modo.Clear();
            btnAcept.Visible = false;
            int x = 200, y=80, j=1;
            for (int i = 0; i < numBotones; i++)
            {
                botonesJuego = new Button();
                botonesJuego.Size = new Size(80, 50);
                botonesJuego.Location = new Point(x, y);
               
                botonesJuego.BackColor = coloresBoton[i];
                botonesJuego.Click += new System.EventHandler(this.b_Click);
                if (j % 2 == 0)
                {
                    y += 100;
                    x = 200;
                }
                else
                {
                    x += 200;
                }
                j++;
                Controls.Add(botonesJuego);
                listaBotones.Add(botonesJuego);
            }

            if (flagChecked==false)
            {
               
                secuencia.Size = new Size(80, 40);
                secuencia.Location = new Point(lbl.Location.X + 50, listaBotones[numBotones - 1].Location.Y + 100);
                secuencia.Text = "Nueva secuencia";
                secuencia.Click += new EventHandler(this.secuencia_Click);
                secuencia.Visible = true;
                Controls.Add(secuencia);
            }
            else
            {
                MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
                banderaSecuencia = false;
            }
            
            listaSecuencias = new List<int>();
                 
        }
        static int pos;
        bool banderaEliminados = false;
        public void b_Click(object sender, System.EventArgs e)
        {
            
            color = ((Button)sender).BackColor;
            pos= coloresBoton.IndexOf(color);

            if (flagChecked)
            {
                if (listaSecuencias.Count < 1)
                {
                    flagañadir = true;                
                }
                else
                {
                    
                    if (flagañadir==false)
                    {
                        banderaPulsarBoton = true;
                        flagsubita = true;
                    }
                    
                }
            }
            else
            {
                flagsubita = false;
            }

            hilo = new Thread(CambiaColor);
            Console.WriteLine("Comienza hilo");
            hilo.Start();
            hilo.Join();

            
            if (banderaSecuencia)
            {
                secuencia.Visible = true;
            }
            if (banderaEliminados)
            {
                for(int i=0; i<listaBotones.Count; i++)
                {
                    listaBotones[i].Visible = false;
                }
                btnJugar.Visible=true;
            }
        }
       static List<int> listaSecuencias;
        Thread hilo;

       static bool banderaPulsarBoton = false;
        public void secuencia_Click(object sender, EventArgs e)
        {
            int num;
            banderaSecuencia = false;
            Random random = new Random();
            for(int i=0; i<numSecu; i++)
            {
                num = random.Next(0, numBotones);
                listaSecuencias.Add(num);              
            }
            for(int i=0; i<listaSecuencias.Count; i++)
            {
                pos = listaSecuencias[i];
                hilo = new Thread(CambiaColor);
                hilo.Start();
                hilo.Join();
                Thread.Sleep(500);              
            }

            secuencia.Visible = false;

            banderaPulsarBoton = true;
            MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
        }

        public static void MuestraMensaje(string msg, int num)
        {
            if (num == 0)
            {
                MessageBox.Show(msg, "Simon dice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(msg, "Simon dice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        bool banderaSecuencia, flagsubita = false, flagañadir = false;
        static int cont = 0, numJugador=0, contSecuencias=0;

        private void Boton1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(0);
        }

        public void colorBoton(int boton)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                listaBotones[boton].BackColor = color.Color;
                coloresBoton[boton] = color.Color;
            }
        }

        private void Boton2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(1);
        }

        private void Boton3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(2);
        }

        private void Boton4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(3);
        }

        private void Boton5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(4);
        }

        private void Boton6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(5);
        }

        private void Boton7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(6);
        }

        private void Boton8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(7);
        }

        private void PuntuacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir?", "Simon Dice", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        public void CambiaColor()
        {
            for (int j = 0; j < 2; j++)
            {
                if (j % 2 == 0)
                {
                    listaBotones[pos].BackColor = Color.Transparent;
                }
                else
                {
                    listaBotones[pos].BackColor = coloresBoton[pos];
                }
                Thread.Sleep(500);
            }

            
                CompuebaBoton();
            
            

        }
        
        public void CompuebaBoton()
        {
            Console.WriteLine("Bandera añadir: " + flagañadir + " Nº secuencia: " + contSecuencias);
            if (flagañadir)
            {
                listaSecuencias.Add(pos);
                contSecuencias++;
                if (contSecuencias == numSecu)
                {
                    flagañadir = false;
                    numJugador++;
                    banderaPulsarBoton = true;
                    if (numJugador == jugadores.Count)
                    {
                        numJugador = 0;
                    }
                    MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
                    cont = 0;
                    contSecuencias = 0;
                }
                
            }
            else
            {
                if (banderaPulsarBoton)
                {

                    if (pos == listaSecuencias[cont])
                    {
                        int x = listaSecuencias.Count - 1;
                        jugadores[numJugador].punt++;


                        if (x == cont)
                        {
                            cont = -1;
                            jugadores[numJugador].punt += 5;

                            if (flagsubita)
                            {
                                MuestraMensaje("Escoja nueva secuencia", 0);
                                flagañadir = true;
                            }
                            if (flagañadir == false)
                            {
                                numJugador++;
                                if (jugadores.Count == numJugador)
                                {
                                    numJugador = 0;
                                    if (flagChecked == false)
                                    {
                                        banderaSecuencia = true;
                                    }

                                    banderaPulsarBoton = false;

                                }
                                else
                                {
                                    MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
                                }
                            }
                            


                        }
                    }
                    else
                    {
                        cont = -1;
                        MuestraMensaje("Se ha equivocado de secuencia", 1);

                        jugadoresEliminados.Add(jugadores[numJugador]);
                        jugadores.Remove(jugadores[numJugador]);

                        if (jugadores.Count < 1)
                        {
                            MuestraMensaje("Todos los jugadores han perdido", 0);
                            banderaPulsarBoton = false;
                            banderaEliminados = true;
                            insertarPuntuaciones();
                        }
                        else
                        {
                            if (flagChecked)
                            {
                                if (numJugador == jugadores.Count)
                                {
                                    numJugador = 0;
                                }
                                MuestraMensaje("Turno para: " + jugadores[numJugador].nombre,0);
                            }
                            else
                            {
                                if (jugadores.Count != numJugador)
                                {
                                    MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
                                    banderaEliminados = false;
                                    banderaSecuencia = false;
                                }
                                else
                                {
                                    if (flagChecked == false)
                                    {
                                        banderaSecuencia = true;
                                    }

                                    banderaPulsarBoton = false;
                                    numJugador = 0;
                                }
                            }
                            
                        }
                    }
                    cont++;

                }
            }
            
        }

        public void insertarPuntuaciones()
        {
            
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "Server=localhost;Port=3306;Database=db;Uid=root;Pwd=;";
                con.Open();
  
                DateTime fecha = DateTime.Today;
                int año = fecha.Year;
                int mes = fecha.Month;
                int dia = fecha.Day;
                string f = año + "-" + mes + "-" + dia;

                MySqlCommand comm = con.CreateCommand();
                for(int i=0; i<jugadoresEliminados.Count; i++)
                {
                    comm.CommandText = "INSERT INTO puntuaciones VALUES('"+jugadoresEliminados[i].nombre+"',"+jugadoresEliminados[i].punt+",'"+ f + "')";
                    comm.ExecuteNonQuery();
                }
                

                

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
