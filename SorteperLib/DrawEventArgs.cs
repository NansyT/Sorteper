using SorteperGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class DrawEventArgs : EventArgs
    {
        Player drawFrom;
        
        public Player DrawFrom { get => drawFrom; private set => drawFrom = value; }

        private AnimalCard card;

        public AnimalCard Card
        {
            get { return card; }
            private set { card = value; }
        }
        private int index;

        public int Index
        {
            get { return index; }
            private set { index = value; }
        }


        public DrawEventArgs(AnimalCard card, Player drawnFrom, int index)
        {
            Card = card;
            DrawFrom = drawnFrom;
            Index = index;
        }
    }
}
