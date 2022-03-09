using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Game
  {
    public int CalculateTotalRank(List<Card> p)
    {
      int total = 0;
      for (int i = 0; i < p.Count; i++)
      {
        total += p[i].Rank;
      }
      return total;
    }
    public void DealCards(Deck D, int total_cards, params List<Card>[] list)
    {
      if (list.Length * total_cards < D.cards.Count)
      {
        for (int i = 0; i < total_cards; i++) // cards
        {
          for (int j = 0; j < list.Length; j++) // total players 
          {
            list[j].Add(D.TopCard());
          }
        }
      }
      else
      {
        throw new Exception("Deck ran out of cards!");
      }
    }
    public void HigherRank(params Player[] list)
    {
      int highest = list[0].HandRank;
      int position = 0;
      for (int i = 0; i < list.Length; i++)
      {
        if (list[i].HandRank > highest)
        {
          highest = list[i].HandRank;
          position = i;
        }
      }
      Console.WriteLine(list[position].name + " has the highest ranking hand! ");
    }
    public void DisplayHand(List<Card> p, string n) // Might not be worthwhile to pass in the name
    {
      Console.WriteLine(n + "'s hand: ");
      string[] Lines = { "Clubs:    ", "Diamonds: ", "Hearts:   ", "Spades:   " }; ;
      foreach (Card card in p)
      {
        if (card.Suit == "Clubs") { Lines[0] += " " + card.Rank; }
        else if (card.Suit == "Diamonds") { Lines[1] += " " + card.Rank; }
        else if (card.Suit == "Hearts") { Lines[2] += " " + card.Rank; }
        else if (card.Suit == "Spades") { Lines[3] += " " + card.Rank; }
      }
      foreach (var Element in Lines)
      {
        Console.WriteLine(Element);
      }
      Console.WriteLine();
    }
    public void FilterHand(List<Card> p, Deck D)
    {
      int Index = 0;
      while ((p.Find(p => p.rank == 11 || p.rank == 12 || p.rank == 13) != null))
      {
        for (int i = Index; i < p.Count; i++)
        {
          while ( p[i].rank == 11 || p[i].rank == 12 || p[i].rank == 13)
          {
            //Console.WriteLine("Discarded: " + p[i].suit + " " + p[i].rank);
            p.RemoveAt(i);
            p.Add(D.TopCard());
          }
        }
      }
    }
    public void DisplayHandInOrder(List<Card> p)
    {
      //Console.WriteLine(n + "'s hand: ");
      for (int i = 0; i < p.Count; i++)
      {
        Console.WriteLine("Card " + (i+1) + ": " + p[i].suit + " "+ p[i].rank);
      }
    }
    public bool Lost(List<Card> p)
    {
      var isplayable = true;
      for (int i = 0; i < p.Count; i++)
      {
        for (int j = i + 1; j < p.Count; j++)
        {
          if (p[i].Rank + p[j].Rank == 10)
          {
            isplayable = false;
          }
        }
      }
      return isplayable;
    }
    public void GameSelectTwoCards(List<Card> p, Deck D)
    {
      //FilterHand(p, D); Thread.Sleep(1000);
      while (D.cards.Count > 0 && D.cards.Count != 0)
      {
        if (Lost(p) != true)
        {
          int index_1, index_2;
          //Console.WriteLine("Filtering hand for Jack, Queen, and Kings."); FilterHand(p, D); Thread.Sleep(1000);
          Console.WriteLine("Cards Left in deck: " + D.cards.Count); Thread.Sleep(1000);
          DisplayHandInOrder(p); Thread.Sleep(1000);
          Console.WriteLine("Select two cards from the list to discard. "); Thread.Sleep(1000);
          Console.Write("Card: "); index_1 = int.Parse(Console.ReadLine());
          Console.Write("Card: "); index_2 = int.Parse(Console.ReadLine());
          while ((p[index_1 - 1].Rank + p[index_2 - 1].Rank != 10))
          {
            Console.WriteLine("The value of those cards do not add up to 10, pick again!");
            Console.Write("Card: "); index_1 = int.Parse(Console.ReadLine());
            Console.Write("Card: "); index_2 = int.Parse(Console.ReadLine());
          }
          p.RemoveAt(index_1 - 1);
          p.Insert(index_1 - 1, D.TopCard());
          p.RemoveAt(index_2 - 1);
          p.Insert(index_2 - 1, D.TopCard());
        }
        else
        {
          DisplayHandInOrder(p);
          Console.WriteLine("Player Lost.");
          
          break;
        }
      }
      if ( D.cards.Count == 0)
      {
        Console.WriteLine("Player Wins!");
      }
    }
  }
}
