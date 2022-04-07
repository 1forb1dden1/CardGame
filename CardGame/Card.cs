using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Card
  {
    private int rank; 
    private string suit;
    public Card(int rank, string suit) { this.rank = rank; this.suit = suit; }
    public int Rank { get { return rank; } set { rank = value; } } 
    public string Suit { get { return suit; } set { suit = value; } }
    public override string ToString()
    {
      return rank.ToString();
    }
  }
}
