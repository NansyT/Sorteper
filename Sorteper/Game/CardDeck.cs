using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class CardDeck
    {
        private List<AnimalCard> deck;

        public List<AnimalCard> Deck
        {
            get { return deck; }
            set { deck = value; }
        }

        public CardDeck()
        {
            Deck = MakeDeck();
        }

       
        private List<AnimalCard> MakeDeck()
        {
            List<string> animals = new List<string>() { "bear", "bee", "bull", "camel", "cat", "crab", "crocodile", "dog", "duck", "fish", "grasshopper", "ladybug", "mouse", "ostrich" }; //Maybe moved somewhere else
            List<AnimalCard> deck = new List<AnimalCard>();
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i] != "cat")
                {
                    for (int j = 0; j < 2; j++)
                    {
                        deck.Add(MakeCard(animals[i]));
                    }
                }
                else
                {
                    deck.Add(MakeCard(animals[i]));
                }
            }
            return deck;
        }

        private AnimalCard MakeCard(string name)
        {
            return new AnimalCard(name);
           
        }
    }
}
