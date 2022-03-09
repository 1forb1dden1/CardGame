using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Deck
  {
    public List<Card> cards = new List<Card>();
    string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
    public Deck() => this.InsertCards();
    public void InsertCards()
    {
      for (int j = 0; j < 4; j++)
      {
        for (int i = 0; i < 13; i++)
        {
          cards.Add(new Card(i + 1, suit[j]));
        }
      }
    }
    public void ResetDeck()
    {
      InsertCards();
      Shuffle();
    }
    public Card TopCard()
    {
      if (cards.Count > 0)
      {
        Card topCard = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return topCard;
      }
      return null;
    }
    public void Shuffle()
    {
      Random rand = new Random();
      for (int i = cards.Count - 1; i > 0; i--)
      {
        int RandomIndex = rand.Next(i + 1);
        Card TempCard = cards[i];
        cards[i] = cards[RandomIndex];
        cards[RandomIndex] = TempCard;
      }
    }
    public void printDeck()
    {
      for (int i = 0; i < cards.Count(); i++)
      {
        Console.WriteLine(cards[i].Rank + " " + cards[i].Suit);
      }
    }

  }
}
