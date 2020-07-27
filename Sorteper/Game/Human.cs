using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class Human : Player
    {
        public List<string> SeeCards(List<AnimalCard> hand)
        {
            List<string> cards = new List<string>();
            foreach (AnimalCard item in hand)
            {
                cards.Add(item.Name);
            }
            return cards;
        }
    }
}
