using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Human
    {

        // Lista på kort som människan har.
        public List<Card> cards = new List<Card>();

        // Människan spelar Uno.
        public void play(Uno uno)
        {

            // Den här varibeln håller koll på hur många kort spelaren har tagit.
            int takenCards = 0;

            // Loopa tills spelaren är klart eller när spelaren har vunnit.
            while (true)
            {

                // Skrever ut statiskt information.
                Console.WriteLine();
                Console.WriteLine("The card on the table is [" + uno.tableCard + "]");
                Console.WriteLine("Your cards are: [" + string.Join(", ", cards) + "]");
                Console.WriteLine();
                Console.Write("Play a card, 'take' to take a card, or 'end' to quit your round: ");

                // Vänta tills spelaren har skrivit take eller end.
                var selectedCard = Console.ReadLine();

                Console.WriteLine();

                // När spelaren skriver end ska programmet kolla om de har tagit minst 3 kort annars ska inte end funka.
                if (selectedCard == "end")
                {
                    if (takenCards < 3)
                    {
                        Console.WriteLine("You need to take at least three cards");

                        // Gå tillbaka till början. Loop.
                        continue;
                    }
                    return;
                }

                // Spelaren har skrivit take, tar spelaren en kort från kortleken.
                else if (selectedCard == "take")
                {
                    var takenCard = uno.cardDeck.GetNextCard();

                    // Om korten är null betyder det att inga kort är kvar på kortleken.
                    // Då blir det oavgjort.
                    // Skrever det och slutar spelet.
                    if (takenCard == null)
                    {
                        Console.WriteLine("No more cards are available. This is a DRAW.");
                        Console.WriteLine("Press enter to end the game");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                    // Lägger till ny kortet och ökar takencards och går tillbaka till början.
                    Console.WriteLine("You took [" + takenCard + "]");
                    cards.Add(takenCard);
                    takenCards++;
                    continue;
                }

                // Spelaren måste har valt en kort att spela.
                // Dela upp färgen och värden.
                var cardTokens = selectedCard.Split(' ');

                // Formatet är färg mellanslag värde. Om det är mer än två delar så sägar programmet det är fel.
                if (cardTokens.Length != 2)
                {
                    Console.WriteLine("That is not a valid card");
                    continue;
                }

                // Gör siffran till en nummer. Kommer från stackoverflow.
                if (!int.TryParse(cardTokens[1], out int value))
                {
                    Console.WriteLine("That is not a valid card");
                    continue;
                }

                // Gör en nytt kort.
                var card = new Card(cardTokens[0], value);

                // Kolla om korten redan finns i spelarens kort. Om det gör inte det är det fel.
                if (!cards.Contains(card))
                {
                    Console.WriteLine("You don't have that card");
                    continue;
                }

                // Antigen färgen eller värden måste vara samma, om det är, tar bort korten från dina kort och lägger på borden.
                if (uno.tableCard.color == card.color || uno.tableCard.value == card.value)
                {
                    uno.tableCard = card;
                    cards.Remove(card);
                    Console.WriteLine("You put [" + card + "] on the table.");
                    
                    // Om spelaren har 0 kort vinner spelaren. Slutar programmet.
                    if (cards.Count == 0)
                    {
                        Console.WriteLine("You WIN!");
                        Console.WriteLine("Press enter to end the game");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    continue;
                } else
                {

                    // Om färgen eller värden är inte samma skriver ut att det är fel.
                    Console.WriteLine("That card (" + card + ") is not the same color or value as the table card: [" + uno.tableCard + "]. Try again.");
                }
            }

        }

    }
}
