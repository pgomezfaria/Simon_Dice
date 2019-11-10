using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon_Dice
{
    class Jugador
    {
        public string nombre;
        public int punt;

        public Jugador(string nom, int puntu)
        {
            nombre = nom;
            punt = puntu;
        }
    }
}
