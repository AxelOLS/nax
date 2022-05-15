using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Computer
    {

        // Skapar en lista på kort som datorn ska hålla.
        public List<Card> cards = new List<Card>();

        // Kod för datorn ska spela.
        public void play(Uno uno)
        {

            // Variabel för hur många kort datorn har tagit.
            int takenCards = 0;

            while (true)
            {
                
                // Skriver ut statusen.
                Console.WriteLine();
                Console.WriteLine("The card on the table is [" + uno.tableCard + "]");
                Console.WriteLine("Computer cards are: [" + string.Join(", ", cards) + "]");
                Console.WriteLine();

                // korten som datorn kanske spelar.
                Card selectedCard = null;

                // Loopa alla kort som datorn har.
                foreach (var card in cards)
                {

                    // Kolla om färgen eller värden är samma.
                    if (card.color == uno.tableCard.color || card.value == uno.tableCard.value)
                    {
                        selectedCard = card;
                    }
                }

                // Om datorn kan hitta en kort lägg korten på borden.
                if (selectedCard != null)
                {
                    Console.WriteLine("Computer plays [" + selectedCard + "]");
                    uno.tableCard = selectedCard;
                    cards.Remove(selectedCard);

                    // Om datorn har 0 kort vinner datorn och slutar programmet.
                    if (cards.Count == 0)
                    {
                        Console.WriteLine("Computer WINS!");
                        Console.WriteLine("Press enter to end the game");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else
                    {
                        // Börja om igen, Loop.
                        continue;
                    }
                }


                // Datorn hittade inga kort så den tar en kort från kortleken.

                var takenCard = uno.cardDeck.GetNextCard();

                // Om det blir inga kort i kortleken blir det null och spelen blir oavgjort och slutar programmet.
                if (takenCard == null)
                {
                    Console.WriteLine("No more cards are available. This is a DRAW.");
                    Console.WriteLine("Press enter to end the game");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                // Datorn tar en ny kort.
                Console.WriteLine("Computer takes [" + takenCard + "]");
                cards.Add(takenCard);

                takenCards++;

                // Om datorn har tagit 3 kort slutar den att ta mer och blir spelarens tur igen.
                if (takenCards == 3)
                {
                    Console.WriteLine("Computer has taken three cards and ends the round with [" + string.Join(", ", cards) + "]");
                    return;
                }
            }

        }

    }
}
