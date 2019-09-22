using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon_Dice
{
    class Modo
    {
        public LabelTextBox labelText;
        public bool flag;

        public Modo(LabelTextBox labelTextBox, bool bandera)
        {
            labelText = labelTextBox;
            flag = bandera;
        }
    }
}
