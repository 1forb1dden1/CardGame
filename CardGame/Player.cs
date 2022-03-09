using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Player
  {
    public List<Card> hand = new List<Card>();
    public int handRank = 0;
    public string name;
    public Player(string name) { this.name = name; }
    public int HandRank { get { return handRank; } set { handRank = value; } } // property
    public string Name { get { return name; } set { name = value; } }

  }
}
