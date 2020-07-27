using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class Computer : Player
    {
        public int MakeChoice(Human human)
        {
            Random rnd = new Random();
            int choice = rnd.Next(0, human.Hand.Count - 1);
            return choice;
        }
    }
    
}
