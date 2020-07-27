using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGame
{
    class Game
    {
        private int currentPlayer;

        CardDeck deck = new CardDeck();
        Human human = new Human();
        Computer computer = new Computer();

        public void ChangeCurrentPlayer()
        {
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer = 0;
            }
        }
        private void SetCurrentPlayer()
        {
            Random rnd = new Random();

            currentPlayer = rnd.Next(0, 2);
        }
        // Starts the game by shuffling the deck and dealing the cards. Currentplayer changes and pairs are found.
        public void StartGame()
        {
            SetCurrentPlayer();
            if (currentPlayer == 0)
            {
                deck.Deck = computer.Shuffle(deck.Deck);
                computer.DealCards(deck.Deck, human, computer);
            }
            else
            {
                deck.Deck = human.Shuffle(deck.Deck);
                human.DealCards(deck.Deck, computer, human);
            }
            human.FindPair();
            computer.FindPair();
            ChangeCurrentPlayer();
        }
        //Picks a card from opponent, then finds the pair. Shuffles computers cards.
        public bool Turn()
        {
            int choice;
            if (currentPlayer == 0)
            {
                choice = computer.MakeChoice(human);
                computer.FindPair();
                computer.Hand = computer.Shuffle(computer.Hand);
                return true;
            }
            else
            {
                choice = int.Parse(Console.ReadLine());

                if (choice > (computer.Hand.Count - 1))
                {
                    Console.WriteLine("That number is too high");
                    return false;
                }
                else
                {
                    human.FindPair();
                    return true;
                }

            }
        } //+ Remove WriteLines

        public bool CheckForWin()
        {
            if (human.Hand.Count + computer.Hand.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string AnnounceWinner()
        {
            if (human.Hand.Count == 1)
            {
                return "You lost";
            }
            else
            {
                return "You Win!";
            }
        }
        public List<Player> GetPlayers()
        {
            return new List<Player>() { human, computer};
        }
    }
}
