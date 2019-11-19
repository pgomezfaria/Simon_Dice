namespace Simon_Dice
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ordenarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deAAZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deZAAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntuacionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deMenorAMayorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deMayorAMenorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deRecienteAAntiguaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deAntiguaARecienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jugadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntuacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fechaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangoDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarPuntuacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(309, 292);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenarToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.guardarPuntuacionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(353, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ordenarToolStripMenuItem
            // 
            this.ordenarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreToolStripMenuItem,
            this.puntuacionesToolStripMenuItem1,
            this.fechaToolStripMenuItem});
            this.ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            this.ordenarToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // nombreToolStripMenuItem
            // 
            this.nombreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deAAZToolStripMenuItem,
            this.deZAAToolStripMenuItem});
            this.nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            this.nombreToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.nombreToolStripMenuItem.Text = "Nombre";
            // 
            // deAAZToolStripMenuItem
            // 
            this.deAAZToolStripMenuItem.Name = "deAAZToolStripMenuItem";
            this.deAAZToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deAAZToolStripMenuItem.Text = "De A a Z";
            this.deAAZToolStripMenuItem.Click += new System.EventHandler(this.DeAAZToolStripMenuItem_Click);
            // 
            // deZAAToolStripMenuItem
            // 
            this.deZAAToolStripMenuItem.Name = "deZAAToolStripMenuItem";
            this.deZAAToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.deZAAToolStripMenuItem.Text = "De Z a A";
            this.deZAAToolStripMenuItem.Click += new System.EventHandler(this.DeZAAToolStripMenuItem_Click);
            // 
            // puntuacionesToolStripMenuItem1
            // 
            this.puntuacionesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deMenorAMayorToolStripMenuItem,
            this.deMayorAMenorToolStripMenuItem});
            this.puntuacionesToolStripMenuItem1.Name = "puntuacionesToolStripMenuItem1";
            this.puntuacionesToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.puntuacionesToolStripMenuItem1.Text = "Puntuaciones";
            // 
            // deMenorAMayorToolStripMenuItem
            // 
            this.deMenorAMayorToolStripMenuItem.Name = "deMenorAMayorToolStripMenuItem";
            this.deMenorAMayorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deMenorAMayorToolStripMenuItem.Text = "De menor a mayor";
            this.deMenorAMayorToolStripMenuItem.Click += new System.EventHandler(this.DeMenorAMayorToolStripMenuItem_Click);
            // 
            // deMayorAMenorToolStripMenuItem
            // 
            this.deMayorAMenorToolStripMenuItem.Name = "deMayorAMenorToolStripMenuItem";
            this.deMayorAMenorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deMayorAMenorToolStripMenuItem.Text = "De mayor a menor";
            this.deMayorAMenorToolStripMenuItem.Click += new System.EventHandler(this.DeMayorAMenorToolStripMenuItem_Click);
            // 
            // fechaToolStripMenuItem
            // 
            this.fechaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deRecienteAAntiguaToolStripMenuItem,
            this.deAntiguaARecienteToolStripMenuItem});
            this.fechaToolStripMenuItem.Name = "fechaToolStripMenuItem";
            this.fechaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.fechaToolStripMenuItem.Text = "Fecha";
            // 
            // deRecienteAAntiguaToolStripMenuItem
            // 
            this.deRecienteAAntiguaToolStripMenuItem.Name = "deRecienteAAntiguaToolStripMenuItem";
            this.deRecienteAAntiguaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deRecienteAAntiguaToolStripMenuItem.Text = "De reciente a antigua";
            this.deRecienteAAntiguaToolStripMenuItem.Click += new System.EventHandler(this.DeRecienteAAntiguaToolStripMenuItem_Click);
            // 
            // deAntiguaARecienteToolStripMenuItem
            // 
            this.deAntiguaARecienteToolStripMenuItem.Name = "deAntiguaARecienteToolStripMenuItem";
            this.deAntiguaARecienteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deAntiguaARecienteToolStripMenuItem.Text = "De antigua a reciente";
            this.deAntiguaARecienteToolStripMenuItem.Click += new System.EventHandler(this.DeAntiguaARecienteToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jugadorToolStripMenuItem,
            this.puntuacionToolStripMenuItem,
            this.fechaToolStripMenuItem1,
            this.rangoDToolStripMenuItem});
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // jugadorToolStripMenuItem
            // 
            this.jugadorToolStripMenuItem.Name = "jugadorToolStripMenuItem";
            this.jugadorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.jugadorToolStripMenuItem.Text = "Jugador";
            this.jugadorToolStripMenuItem.Click += new System.EventHandler(this.JugadorToolStripMenuItem_Click);
            // 
            // puntuacionToolStripMenuItem
            // 
            this.puntuacionToolStripMenuItem.Name = "puntuacionToolStripMenuItem";
            this.puntuacionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.puntuacionToolStripMenuItem.Text = "Puntuacion";
            this.puntuacionToolStripMenuItem.Click += new System.EventHandler(this.PuntuacionToolStripMenuItem_Click);
            // 
            // fechaToolStripMenuItem1
            // 
            this.fechaToolStripMenuItem1.Name = "fechaToolStripMenuItem1";
            this.fechaToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.fechaToolStripMenuItem1.Text = "Fecha";
            this.fechaToolStripMenuItem1.Click += new System.EventHandler(this.FechaToolStripMenuItem1_Click);
            // 
            // rangoDToolStripMenuItem
            // 
            this.rangoDToolStripMenuItem.Name = "rangoDToolStripMenuItem";
            this.rangoDToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.rangoDToolStripMenuItem.Text = "Rango de fechas";
            this.rangoDToolStripMenuItem.Click += new System.EventHandler(this.RangoFechasToolStripMenuItem_Click);
            // 
            // guardarPuntuacionesToolStripMenuItem
            // 
            this.guardarPuntuacionesToolStripMenuItem.Name = "guardarPuntuacionesToolStripMenuItem";
            this.guardarPuntuacionesToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.guardarPuntuacionesToolStripMenuItem.Text = "Guardar puntuaciones";
            this.guardarPuntuacionesToolStripMenuItem.Click += new System.EventHandler(this.GuardarPuntuacionesToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(353, 327);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Simon Dice";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ordenarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deAAZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deZAAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntuacionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deMenorAMayorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deMayorAMenorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deRecienteAAntiguaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deAntiguaARecienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jugadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntuacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fechaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rangoDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarPuntuacionesToolStripMenuItem;
    }
}