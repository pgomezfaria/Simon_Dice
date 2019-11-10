using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace Simon_Dice
{
    public partial class Form1 : Form
    {

        Button btnJugar, botonesJuego , btnAcept, secuencia;
        List<ToolStripMenuItem> listaTool = new List<ToolStripMenuItem>();
        SoundPlayer player, playSecuencia;
        List<Modo> modo;
        LabelTextBox labelText;
        Modo mod;
        int y = 50, horas = 0, minutos=0, segundos=0, numBotones , numSecu , xstring = 170, ystring = 200 , pos , cont = 0, numJugador = 0, contSecuencias = 0;
        bool nuevaPartida = true, flagPintar = true, flagSonido = true, flagMusica = true, flagChecked = false, banderaEliminados = false, banderaPulsarBoton = false, banderaSecuencia, flagsubita = false, flagañadir = false;
        static List<Jugador> jugadores;
        Jugador jugador;
        List<Color>  coloresBoton;
        List<Button> listaBotones;
        List<Jugador> jugadoresEliminados;
        Color color;      
        List<int> listaSecuencias;
        Thread hilo;
        string[] lista;
        public Form1()
        {           
            InitializeComponent();

            this.MouseWheel += Form_MouseWheel;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(crono);
            timer.Start();

            lista = new string[3];
            lista[0] = "nº jugadores";
            lista[1] = "nº botones(3-8)";
            lista[2] = "n º secuencias";
            player = new SoundPlayer();
            playSecuencia = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\musica.wav";
            playSecuencia.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\secuencia.wav";
            player.PlayLooping();

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

        /// <summary>
        /// Detecta el scroll con el ratón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Cronometro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void crono(object sender, EventArgs e)
        {
            segundos++;
            
            if (segundos > 59)
            {
                minutos++;
                segundos = 0;
            }
            if (minutos > 59){
                horas++;
                minutos = 0;
            }
            cronometro.Text = String.Format("{0:00}", horas) + ":" + String.Format("{0:00}", minutos) + ":" + String.Format("{0:00}",segundos);
        }

        /// <summary>
        /// Click del botón jugar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJugar_Click(object sender, EventArgs e)
        {
            flagPintar = false;
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
                    banderaEliminados = false;
                    Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    nuevaPartida = false;
                }
            }
            else
            {
                Refresh();
                nuevaPartida = true;
            }
            
            if (nuevaPartida)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Visible = false;
                }
                cronometro.Visible = true;
                musica.Visible = true;
                sonido.Visible = true;
                menuStrip1.Visible = true;
                lbl.Visible = true;

                jugadores = new List<Jugador>();
                jugadoresEliminados = new List<Jugador>();
                modo = new List<Modo>();
                listaBotones = new List<Button>();
                
                secuencia = new Button();

                checkBox1.Visible = false;

                eliminarListas();

                checkBox1.Location = new Point(lbl.Location.X + 80, lbl.Location.Y);
                checkBox1.Visible = true;

                
                btnJugar.Visible = false;
                lbl.Visible = true;

                crearLabelTextBox(3, true);
                creaBoton(2, false);
            }
            
        }

        /// <summary>
        /// Eliminar el contenido de las listas
        /// </summary>
        public void eliminarListas()
        {
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
        }
       

        /// <summary>
        /// Comprueba que los datos introducidos en cada textbox son válidos
        /// </summary>
        /// <param name="modoJuego">Numero asociado a la parte del juego</param>
        /// <param name="numero">Numero asociado al textbox</param>
        public void Comprueba(int modoJuego, int numero)
        {
            string error = "";
            int num = 0;
            int j = numero + 1;
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
                        try
                        {
                            
                            modo[numero].flag = false;
                            Convert.ToInt32(modo[numero].labelText.TextTxt);
                            MuestraMensaje("El nombre del jugador "+j+" no es válido", 0);
                        }
                        catch (FormatException)
                        {
                            modo[numero].flag = true;
                            
                            for (int i=0; i<modo.Count; i++)
                            {
                                if (i != numero)
                                {
                                    if (modo[numero].labelText.TextTxt == modo[i].labelText.TextTxt)
                                    {
                                        modo[numero].flag = false;
                                        MuestraMensaje("Jugador " +j +" repetido: " + modo[i].labelText.TextTxt, 0);
                                        break;
                                    }
                                }
                                
                            }
                            
                        }
                        
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

        /// <summary>
        /// Click del botón aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                btnAcept.Visible = false;
                Jugadores();
            }
        }
       
        /// <summary>
        /// Pantalla del juego donde se pide el nombre de los jugadores
        /// </summary>
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

            crearLabelTextBox(num, false);

            //btnAcept = new Button();
            //btnAcept.Location = new Point(lbl.Location.X, modo[num-1].labelText.Location.Y + 30);
            //btnAcept.Size = new Size(80, 30);
            //btnAcept.Text = "Aceptar";
            //btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            //btnAcept.Visible = true;
            //Controls.Add(btnAcept);
            creaBoton(num - 1, true);
        }

        /// <summary>
        /// Crea el componente labelTextBox
        /// </summary>
        /// <param name="num">Numero de labelTextBox</param>
        /// <param name="flag">Texto del componente</param>
        public void crearLabelTextBox(int num, bool flag)
        {
            int j = 1;
            y = lbl.Location.Y + 20;
            for (int i = 0; i < num; i++)
            {
                labelText = new LabelTextBox();
                labelText.Size = new Size(20, 150);
                labelText.Location = new Point(lbl.Location.X - 20, y);
                labelText.Tamaño = 60;
                if (flag)
                {
                    labelText.TextLbl = lista[i];
                }
                else
                {
                    labelText.TextLbl = "Jugador " + j;
                }
                
                labelText.Visible = true;
                labelText.Separacion = 10;
                Controls.Add(labelText);
                y += 30;
                mod = new Modo(labelText, false);
                modo.Add(mod);
                j++;
            }
        }
        
        /// <summary>
        /// Crea un boton
        /// </summary>
        /// <param name="num">Posicion de la lista</param>
        /// <param name="flag">Tipo de click que se quiere asociar</param>
        public void creaBoton(int num, bool flag)
        {
            btnAcept = new Button();
            btnAcept.Location = new Point(lbl.Location.X, modo[num].labelText.Location.Y + 30);
            btnAcept.Size = new Size(80, 30);
            btnAcept.Text = "Aceptar";
            if (flag)
            {
                btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            }
            else
            {
                btnAcept.Click += new System.EventHandler(this.btnAceptar_Click);
            }
            
            btnAcept.Visible = true;
            Controls.Add(btnAcept);
        }

        /// <summary>
        /// Click del botón aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Pantalla donde se realiza el juego
        /// </summary>
        public void Juego()
        {
            flagPintar = false;
            coloresToolStripMenuItem.Visible = true;
            for (int i = 0; i < numBotones; i++)
            {
                listaTool[i].Visible = true;
            }

            for (int i=0; i<modo.Count; i++)
            {
                jugador = new Jugador(modo[i].labelText.TextTxt, 0);
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
        
        /// <summary>
        /// Click de los botones con colores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void b_Click(object sender, System.EventArgs e)
        {
            if (flagSonido)
            {
                playSecuencia.PlayLooping();
            }
            
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
            
            hilo.Start();
            hilo.Join();

            playSecuencia.Stop();
            if (flagMusica)
            {
                player.PlayLooping();
            }
            
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
                flagPintar = true;
                xstring = 170;
                ystring = 150;
                Refresh();
               // btnJugar.Visible=true;
            }
        }

        /// <summary>
        /// Click del botón secuencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void secuencia_Click(object sender, EventArgs e)
        {
            if (flagSonido)
            {
                playSecuencia.PlayLooping();
            }
            
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
            playSecuencia.Stop();
            if (flagMusica)
            {
                player.PlayLooping();
            }
            
            MuestraMensaje("Turno para: " + jugadores[numJugador].nombre, 0);
            
        }

        /// <summary>
        /// Muestra un messagebox
        /// </summary>
        /// <param name="msg">String que se quiere mostrar</param>
        /// <param name="num">Tipo de icono del messagebox</param>
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

        
        /// <summary>
        /// Click del boton 1 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(0);
        }

        /// <summary>
        /// Cambia el color del boton 
        /// </summary>
        /// <param name="boton">Numero del boton</param>
        public void colorBoton(int boton)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                listaBotones[boton].BackColor = color.Color;
                coloresBoton[boton] = color.Color;
            }
        }

        /// <summary>
        /// Click del boton 2 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(1);
        }

        /// <summary>
        /// Click del boton 3 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(2);
        }

        /// <summary>
        /// Click del boton 4 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(3);
        }

        /// <summary>
        /// Click del boton 5 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(4);
        }

        /// <summary>
        /// Click del boton 6 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(5);
        }

        /// <summary>
        /// Click del boton 7 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(6);
        }

        /// <summary>
        /// Click del boton 8 de menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorBoton(7);
        }

        /// <summary>
        /// Detecta cuando la propiedad checked de música cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Musica_CheckedChanged(object sender, EventArgs e)
        {
            if (musica.Checked)
            {
                player.PlayLooping();
                flagMusica = true;
            }
            else
            {
                player.Stop();
                flagMusica = false;
            }
        }

        /// <summary>
        /// Detecta cuando la propiedad checked de sonido cambia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sonido_CheckedChanged(object sender, EventArgs e)
        {
            if (sonido.Checked)
            {
                flagSonido = true;
            }
            else
            {
                flagSonido = false;
            }
        }

        private void ComoSeJuegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuestraMensaje("Este juego es una adaptación del juego de mesa Simón dice. En este juego los jugadores deberán demostrar que tienen una buena memoria y seguir la lista de secuencias que saca el ordenador.", 0);
        }

        private void ModoMuerteSubitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuestraMensaje("A diferencia del modo clásico del juego, en este modo, son los propios jugadores los que crean la lista de secuencias y por lo tanto, compiten entre ellos", 0);
        }

        /// <summary>
        /// Detecta el scroll con las barras de desplazamiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            Refresh();
        }


        /// <summary>
        /// Click de créditos de menú strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MuestraMensaje("Musica: https://audionautix.com", 0);
        }

        /// <summary>
        /// Click de puntuaciones de menú strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PuntuacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        /// <summary>
        /// Cuando el usuario cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Cambia el color del botón a transparente y lo cambia de nuevo al establecido
        /// </summary>
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
        
        /// <summary>
        /// Comprueba que se ha seleccionado el botón correspondiente a la lista de secuencias y también permite añadir nuevas secuencias
        /// </summary>
        public void CompuebaBoton()
        {
          
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

        /// <summary>
        /// Inserta puntuaciones en una base de datos
        /// </summary>
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
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Pinta en el formulario
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush myBrush = new SolidBrush(Color.IndianRed);
            g.FillEllipse(myBrush, new Rectangle(80, 80, 70, 70));
            myBrush = new SolidBrush(Color.Chocolate);
            g.FillEllipse(myBrush, new Rectangle(500, 80, 70, 70));
            myBrush = new SolidBrush(Color.Gold);
            g.FillEllipse(myBrush, new Rectangle(80, 220, 70, 70));
            myBrush = new SolidBrush(Color.Aquamarine);
            g.FillEllipse(myBrush, new Rectangle(500, 220, 70, 70));
            myBrush = new SolidBrush(Color.LimeGreen);
            g.FillEllipse(myBrush, new Rectangle(80, 370, 70, 70));
            myBrush = new SolidBrush(Color.MediumVioletRed);
            g.FillEllipse(myBrush, new Rectangle(500, 370, 70, 70));
            LinearGradientBrush linear = new LinearGradientBrush(
                new Point(0, 0),
                new Point(200, 100),
                Color.FromArgb(255, 0, 0, 255),   // opaque blue
                Color.FromArgb(255, 0, 255, 0));
            Font font;
            font = new Font(this.Font.FontFamily, (float)(this.Font.Size *8));
            if (flagPintar)
            {
                g.DrawString("Simon", font, linear, xstring, ystring);
            }
            
                
        }
    }
}
