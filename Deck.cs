using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Deck
    {
        public List<Card> cards = new List<Card>();
        public Deck()
        {
            // Skapar olika färgerna på korten.
            var colors = new String[] { "red", "blue", "green", "yellow" };

            // Loopa alla färger.
            foreach (var color in colors)
            {
                // Loopa alla värden kan ha.
                for (int i = 0; i < 10; i++)
                {
                    // Lägg kort i din kortlek.
                    cards.Add(new Card(color, i));
                }
            }

            // Gör kortarna random.
            // Jag hittade på. https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
            Random rnd = new Random();
            cards = cards.OrderBy(item => rnd.Next()).ToList();

        }

        public Card GetNextCard()
        {

            // Ta nästa kort.
            // Om det finns inga kort skickar den null till Uno.cs.
            if (cards.Count == 0) return null;
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
