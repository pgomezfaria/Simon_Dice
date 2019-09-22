using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon_Dice
{
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
        }

        private void LabelTextBox_Load(object sender, EventArgs e)
        {
            Height = 100;
            Width = 300;
        }

        public enum ePosicion
        {
            IZQUIERDA, DERECHA
        }

        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posición cambia")]
        public event System.EventHandler CambiaPosicion;

        private ePosicion posicion = ePosicion.IZQUIERDA;
        [Category("Appearance")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]
        public ePosicion Posicion
        {
            set 
            {
                if (Enum.IsDefined(typeof(ePosicion), value))
                {
                    posicion = value;
                    recolocar();
                    if (CambiaPosicion != null)
                        CambiaPosicion(this, new EventArgs());
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }

        void colocar()
        {
            if (separacion > 0)
            {
                txt.Location = new Point(lbl.Location.X + lbl.Size.Width + Separacion);
            }
        }

        private int separacion = 50;
        [Category("Design")]
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    colocar();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                Refresh();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }

        [Category("Appearance")]
        [Description("Anchura asociada al TextBox del control")]
        public int Tamaño
        {
            set
            {
                txt.Width = value;
            }
            get
            {
                return txt.Width;
            }
        }
        void recolocar()
        {
            switch (posicion)
            {
                case ePosicion.DERECHA:
                    txt.Location = new Point(0, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case ePosicion.IZQUIERDA:
                    lbl.Location = new Point(0, 0);
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }

        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
    }
}
