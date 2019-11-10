namespace Simon_Dice
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevaPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntuacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musica = new System.Windows.Forms.CheckBox();
            this.sonido = new System.Windows.Forms.CheckBox();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comoSeJuegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modoMuerteSubitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronometro = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(255, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(66, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Modo juego:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(327, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Muerte súbita";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPartidaToolStripMenuItem,
            this.puntuacionesToolStripMenuItem,
            this.coloresToolStripMenuItem,
            this.creditosToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevaPartidaToolStripMenuItem
            // 
            this.nuevaPartidaToolStripMenuItem.Name = "nuevaPartidaToolStripMenuItem";
            this.nuevaPartidaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.nuevaPartidaToolStripMenuItem.Text = "&Nueva partida";
            this.nuevaPartidaToolStripMenuItem.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // puntuacionesToolStripMenuItem
            // 
            this.puntuacionesToolStripMenuItem.Name = "puntuacionesToolStripMenuItem";
            this.puntuacionesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.puntuacionesToolStripMenuItem.Text = "&Puntuaciones";
            this.puntuacionesToolStripMenuItem.Click += new System.EventHandler(this.PuntuacionesToolStripMenuItem_Click);
            // 
            // coloresToolStripMenuItem
            // 
            this.coloresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boton1ToolStripMenuItem,
            this.boton2ToolStripMenuItem,
            this.boton3ToolStripMenuItem,
            this.boton4ToolStripMenuItem,
            this.boton5ToolStripMenuItem,
            this.boton6ToolStripMenuItem,
            this.boton7ToolStripMenuItem,
            this.boton8ToolStripMenuItem});
            this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            this.coloresToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.coloresToolStripMenuItem.Text = "Colores";
            // 
            // boton1ToolStripMenuItem
            // 
            this.boton1ToolStripMenuItem.Name = "boton1ToolStripMenuItem";
            this.boton1ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton1ToolStripMenuItem.Text = "Boton 1";
            this.boton1ToolStripMenuItem.Click += new System.EventHandler(this.Boton1ToolStripMenuItem_Click);
            // 
            // boton2ToolStripMenuItem
            // 
            this.boton2ToolStripMenuItem.Name = "boton2ToolStripMenuItem";
            this.boton2ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton2ToolStripMenuItem.Text = "Boton 2";
            this.boton2ToolStripMenuItem.Click += new System.EventHandler(this.Boton2ToolStripMenuItem_Click);
            // 
            // boton3ToolStripMenuItem
            // 
            this.boton3ToolStripMenuItem.Name = "boton3ToolStripMenuItem";
            this.boton3ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton3ToolStripMenuItem.Text = "Boton 3";
            this.boton3ToolStripMenuItem.Click += new System.EventHandler(this.Boton3ToolStripMenuItem_Click);
            // 
            // boton4ToolStripMenuItem
            // 
            this.boton4ToolStripMenuItem.Name = "boton4ToolStripMenuItem";
            this.boton4ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton4ToolStripMenuItem.Text = "Boton 4";
            this.boton4ToolStripMenuItem.Click += new System.EventHandler(this.Boton4ToolStripMenuItem_Click);
            // 
            // boton5ToolStripMenuItem
            // 
            this.boton5ToolStripMenuItem.Name = "boton5ToolStripMenuItem";
            this.boton5ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton5ToolStripMenuItem.Text = "Boton 5";
            this.boton5ToolStripMenuItem.Click += new System.EventHandler(this.Boton5ToolStripMenuItem_Click);
            // 
            // boton6ToolStripMenuItem
            // 
            this.boton6ToolStripMenuItem.Name = "boton6ToolStripMenuItem";
            this.boton6ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton6ToolStripMenuItem.Text = "Boton 6";
            this.boton6ToolStripMenuItem.Click += new System.EventHandler(this.Boton6ToolStripMenuItem_Click);
            // 
            // boton7ToolStripMenuItem
            // 
            this.boton7ToolStripMenuItem.Name = "boton7ToolStripMenuItem";
            this.boton7ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton7ToolStripMenuItem.Text = "Boton 7";
            this.boton7ToolStripMenuItem.Click += new System.EventHandler(this.Boton7ToolStripMenuItem_Click);
            // 
            // boton8ToolStripMenuItem
            // 
            this.boton8ToolStripMenuItem.Name = "boton8ToolStripMenuItem";
            this.boton8ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.boton8ToolStripMenuItem.Text = "Boton 8";
            this.boton8ToolStripMenuItem.Click += new System.EventHandler(this.Boton8ToolStripMenuItem_Click);
            // 
            // creditosToolStripMenuItem
            // 
            this.creditosToolStripMenuItem.Name = "creditosToolStripMenuItem";
            this.creditosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.creditosToolStripMenuItem.Text = "Creditos";
            this.creditosToolStripMenuItem.Click += new System.EventHandler(this.CreditosToolStripMenuItem_Click);
            // 
            // musica
            // 
            this.musica.AutoSize = true;
            this.musica.Checked = true;
            this.musica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.musica.Location = new System.Drawing.Point(537, 28);
            this.musica.Name = "musica";
            this.musica.Size = new System.Drawing.Size(60, 17);
            this.musica.TabIndex = 6;
            this.musica.Text = "Musica";
            this.musica.UseVisualStyleBackColor = true;
            this.musica.CheckedChanged += new System.EventHandler(this.Musica_CheckedChanged);
            // 
            // sonido
            // 
            this.sonido.AutoSize = true;
            this.sonido.Checked = true;
            this.sonido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sonido.Location = new System.Drawing.Point(537, 52);
            this.sonido.Name = "sonido";
            this.sonido.Size = new System.Drawing.Size(59, 17);
            this.sonido.TabIndex = 7;
            this.sonido.Text = "Sonido";
            this.sonido.UseVisualStyleBackColor = true;
            this.sonido.CheckedChanged += new System.EventHandler(this.Sonido_CheckedChanged);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comoSeJuegaToolStripMenuItem,
            this.modoMuerteSubitaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // comoSeJuegaToolStripMenuItem
            // 
            this.comoSeJuegaToolStripMenuItem.Name = "comoSeJuegaToolStripMenuItem";
            this.comoSeJuegaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.comoSeJuegaToolStripMenuItem.Text = "¿Como se juega?";
            this.comoSeJuegaToolStripMenuItem.Click += new System.EventHandler(this.ComoSeJuegaToolStripMenuItem_Click);
            // 
            // modoMuerteSubitaToolStripMenuItem
            // 
            this.modoMuerteSubitaToolStripMenuItem.Name = "modoMuerteSubitaToolStripMenuItem";
            this.modoMuerteSubitaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modoMuerteSubitaToolStripMenuItem.Text = "Modo muerte subita";
            this.modoMuerteSubitaToolStripMenuItem.Click += new System.EventHandler(this.ModoMuerteSubitaToolStripMenuItem_Click);
            // 
            // cronometro
            // 
            this.cronometro.AutoSize = true;
            this.cronometro.Location = new System.Drawing.Point(12, 32);
            this.cronometro.Name = "cronometro";
            this.cronometro.Size = new System.Drawing.Size(43, 13);
            this.cronometro.TabIndex = 8;
            this.cronometro.Text = "0:00:00";
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(624, 527);
            this.Controls.Add(this.cronometro);
            this.Controls.Add(this.sonido);
            this.Controls.Add(this.musica);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simon Dice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevaPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntuacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boton8ToolStripMenuItem;
        private System.Windows.Forms.CheckBox musica;
        private System.Windows.Forms.ToolStripMenuItem creditosToolStripMenuItem;
        private System.Windows.Forms.CheckBox sonido;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comoSeJuegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modoMuerteSubitaToolStripMenuItem;
        private System.Windows.Forms.Label cronometro;
    }
}

