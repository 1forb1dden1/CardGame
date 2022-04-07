using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Deck
  {
    private List<Card> cards = new List<Card>();
    string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
    public List<Card> Cards { get { return cards; } set { Cards = value; } }
    public Deck()
    {
      InsertCards();
    }
    public Deck(int s)
    {
      Card c1 = new Card(8, "Clubs");
      Card c2 = new Card(11, "Clubs");
      Card c3 = new Card(12, "Clubs");
      Card c4 = new Card(13, "Clubs");
      Card c5 = new Card(3, "Clubs");
      Cards.Add(c1);
      Cards.Add(c5);
      Cards.Add(c2);
      Cards.Add(c3);
      Cards.Add(c4);
      for (int i = 0; i < 3; i++)
      {
        Cards.Add(c4);
        Cards.Add(c5);
      }
    }
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
    public void ResetDeck(Deck D)
    {
      D.Cards.Clear(); // right
      D.InsertCards();
      D.Shuffle();
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
    public void printDeck()
    {
      for (int i = 0; i < cards.Count(); i++)
      {
        Console.WriteLine(cards[i].Rank + " " + cards[i].Suit);
      }
    }
  }
}
