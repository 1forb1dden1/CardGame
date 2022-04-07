using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class GameBoard
  {
    private List<Card> cards = new List<Card>();
    private int played = 0;
    private int wins = 0;
    private int loses = 0;
    public List<Card> Cards { get { return cards; } set { cards = value; } }
    public int Played { get {return played;} set { played = value; } }
    public int Wins { get {return wins;} set { wins = value; } }
    public int Loses { get { return loses;} set { loses = value; } }
    public GameBoard(int S, Deck D)
    {
      for ( int i = 0; i < S; i++)
      {
        Cards.Add(D.TopCard());
      }
      Played = 0;
      Wins = 0;
      Loses = 0;
    }
    public void DisplayDeckCount(Deck d)
    {
      Console.WriteLine("Deck Count: " + d.Cards.Count() + "\n");
    }
    public void DisplayCards(GameBoard G)
    {
      int i = 1;
      foreach (var card in G.Cards)
      {
        Console.WriteLine("Card" + (i) + ": " + card.Rank);
        i++;
      }
    }
/*public void ReplaceCard(List<Card> p, Deck D, int index)
    {
      p.RemoveAt(index - 1);
      p.Insert(index - 1, D.TopCard());
    }*/
    public void DisplayScore()
    {
      Console.WriteLine("Wins: " + Wins + "\n" + "Loses: " + Loses );
    }
  }
}
