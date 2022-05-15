using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Card
    {
        
        // Värdet på korten och färgen.
        public int value;
        public String color;
        
        // Skapa en kort med färg och värde.
        public Card(String color, int value)
        {
            this.color = color;
            this.value = value;
        }

        // Skriver ut färgen och värden på korten.
        public override String ToString()
        {
            return color + " " + value;
        }

        // Jämför om två kort är samma.
        public override bool Equals(object obj)
        {

            // Jämför om två strägarna är samma.
            return ToString() == obj.ToString();
        }

        // Gör en ny unikt nummer för varje kort.
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
