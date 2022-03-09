using System;

namespace CardGame
{
  internal class Card
  {
    public int rank; 
    public string suit;
    public Card(int rank, string suit) { this.rank = rank; this.suit = suit; }
    public int Rank { get { return rank; } set { rank = value; } } 
    public string Suit { get { return suit; } set { suit = value; } } 

  }
}
