using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class System
  {
    public void DealCards(Deck D, int total_cards, params List<Card>[] list)
    {
      if (list.Length * total_cards < D.Cards.Count)
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
    public void ReplaceCard(List<Card> p, Deck D, int index)
    {
      p.RemoveAt(index - 1);
      p.Insert(index - 1, D.TopCard());
    }
    public void Prompt(string s)
    {
      Console.Write(s);
    }
    public int SelectCard()
    {
      Console.Write("\nSelect a card: ");
      if (int.TryParse(Console.ReadLine(), out var result ) )
      {
        if ( result >= 1 && result <= 11)
        {
          return result;
        }
      }
      Console.WriteLine("The card is invalid Card.");
      return SelectCard();
    }
    public void replaceTwo(GameBoard G, int idx1, int idx2, Deck D)
    {
      G.Cards.RemoveAt(idx1 - 1);
      G.Cards.Insert(idx1 - 1, D.TopCard());
      G.Cards.RemoveAt(idx2 - 1);
      G.Cards.Insert(idx2 - 1, D.TopCard());
    }
    public void replaceThree(GameBoard G, int idx1, int idx2, int idx3, Deck D)
    {
      G.Cards.RemoveAt(idx1 - 1);
      G.Cards.Insert(idx1 - 1, D.TopCard());
      G.Cards.RemoveAt(idx2 - 1);
      G.Cards.Insert(idx2 - 1, D.TopCard());
      G.Cards.RemoveAt(idx3 - 1);
      G.Cards.Insert(idx3 -1, D.TopCard());
    }
    public void DisplayResults(GameBoard G, Checker C, Deck D)
    {
      if (C.isWon(G, D) == true)
      {
        Console.WriteLine("\n You Have Won the game!");
      }
      else
      {
        Console.WriteLine("\n You Lose.");
      }
    }
    public void PlayEleven()
    {
      Deck Deck = new Deck(); Deck.Shuffle();
      Checker Checker = new Checker();
      Player Player = new Player("Default Player");
      GameBoard GameBoard = new GameBoard(11, Deck);
      int index1 = 0; int index2 = 0; int index3 = 0;
      while (Checker.isLost(GameBoard.Cards) != true && Checker.isWon(GameBoard, Deck) != true)
      {
        GameBoard.DisplayDeckCount(Deck);
        GameBoard.DisplayCards(GameBoard);
        index1 = SelectCard();
        index2 = SelectCard();
        Player.Select.Add(GameBoard.Cards[index1-1]);
        Player.Select.Add(GameBoard.Cards[index2-1]);
        if ( Checker.removeEleven(Player) == true)
        {
          if (Deck.Cards.Count >= 2)
          {
            replaceTwo(GameBoard, index1, index2, Deck);
          }
          else if (Deck.Cards.Count == 1)
          {
            GameBoard.Cards.RemoveAt(index1 - 1);
            GameBoard.Cards.Insert(index1 - 1, Deck.TopCard());
            GameBoard.Cards.RemoveAt(index2 - 1);
          }
          else
          {
            GameBoard.Cards.RemoveAt(index1 - 1);
            GameBoard.Cards.RemoveAt(index2 - 2);
          }
          Player.Select.Clear();
        }
        else if ( Checker.isJQK(Player.Select[0]) && Checker.isJQK(Player.Select[1]) && Player.Select[0].Rank != Player.Select[1].Rank ) // check if JQK 
        {
          index3 = SelectCard();
          Player.Select.Add(GameBoard.Cards[index3 - 1]);
          if(Checker.removeJQK(Player) == true)
          {
            if ( Deck.Cards.Count >= 3)
            {
              replaceThree(GameBoard, index1, index2, index3, Deck);
            }
            else if (Deck.Cards.Count < 3 && Deck.Cards.Count > 0)
            {
              for ( int i = 1; i < Deck.Cards.Count+1; i++)
              {
                var curr = ("index" + i);
                GameBoard.Cards.RemoveAt(index1 - 1); // index1, index2, index3...
                GameBoard.Cards.Insert(index1 - 1, Deck.TopCard()); // index1, index2, index3...
              }
            }
            else
            {
              GameBoard.Cards.RemoveAt(index1 - 1);
              GameBoard.DisplayCards(GameBoard);
              GameBoard.Cards.RemoveAt(index2 - 1 );
              GameBoard.DisplayCards(GameBoard);
              GameBoard.Cards.RemoveAt(index2 - 2);
              GameBoard.DisplayCards(GameBoard);
            }
          }
          else
          {
            Prompt("Invalid Cards, Select again.\n");
          }
          Player.Select.Clear();
        }
        else
        {
          Prompt("Invalid Cards, Select again.\n");
          Player.Select.Clear();
        }
      }
      DisplayResults(GameBoard, Checker, Deck);
    }
  }
}
