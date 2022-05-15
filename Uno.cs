using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Uno
    {

        // Skapar en kortlek. Skapar en dator spelare och skapar en vanlig spelare.
        public Deck cardDeck = new Deck();
        public Computer computer = new Computer();
        public Human human = new Human();

        // Kortet som finns på borden.
        public Card tableCard = null;

        public Uno()
        {
            // Algorithm att dela ut kort.
            // Programmen ger 7 kort till varje spelare.
            for (int i = 0; i < 7; i++)
            {
                computer.cards.Add(cardDeck.GetNextCard());
                human.cards.Add(cardDeck.GetNextCard());
            }

            // Lägger första korten på borden.
            tableCard = cardDeck.GetNextCard();
        }

        public void play()
        {

            // Först är de människans tur sen datorn. Loop.
            // Vi försätter tills någon vinner.
            // Loopen slutar aldrig men programmet avslutas när spelet är klart.
            while (true)
            {
                human.play(this);
                computer.play(this);
            }
        }

        // Programmet alltid börjar här.
        static void Main(string[] args)
        {
            Console.WriteLine("Starting simple UNO");
            
            // Skapa en ny Uno och börjar spelen.
            var uno = new Uno();
            uno.play();

            // Koden ska inte komma hit för att loopen ska vara oändligt.
        }
    }
}
