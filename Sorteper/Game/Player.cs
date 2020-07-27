using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class Player
    {
        public event EventHandler CardDrawn;
		private List<AnimalCard> hand;

		public List<AnimalCard> Hand
		{
			get { return hand; }
			set { hand = value; }
		}

        public List<AnimalCard> Shuffle(List<AnimalCard> sortedDeck)
		{
            Random rnd = new Random();
            List<AnimalCard> unsortedDeck = new List<AnimalCard>();
            for (int i = sortedDeck.Count; i > 0; i--)
            {
                int rndNo = rnd.Next(1, i + 1) - 1;
                unsortedDeck.Add(sortedDeck[rndNo]);
                sortedDeck.Remove(sortedDeck[rndNo]);
            }
            return unsortedDeck;
        } //! Works!
        public void DealCards(List<AnimalCard> deck, Player player1, Player player2)
        {
            List<AnimalCard> hand1 = new List<AnimalCard>();
            List<AnimalCard> hand2 = new List<AnimalCard>();
            int last = 0;
            for (int i = 0; i < deck.Count; i++)
            {
                if (last == 0)
                {
                    hand1.Add(deck[i]);
                    
                    last = 1;
                }
                else
                {
                    hand2.Add(deck[i]);
                    last = 0;
                }
            }
            player1.Hand = hand1;
            player2.Hand = hand2;
        }  //! Seems to work
        //Finds pairs by compairing the cards' names
        public List<AnimalCard> FindPair()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                for (int j = i + 1; j < hand.Count; j++)
                {
                    if (hand[i].Name == hand[j].Name)
                    {
                        hand.Remove(hand[i]);
                        hand.Remove(hand[j - 1]);
                        j = i;
                    }
                    else { }
                }
            }
            return hand;
        } //! Works!
        public AnimalCard Draw(int choice, Player otherPlayer)
        {
            AnimalCard card = otherPlayer.Hand[choice];
            hand.Add(otherPlayer.Hand[choice]);
            otherPlayer.Hand.RemoveAt(choice);
            CardDrawn?.Invoke(this, new DrawEventArgs(card, otherPlayer, choice));
            return card;
        } //! Seems to work
    }
}
