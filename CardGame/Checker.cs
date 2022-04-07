using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Checker
  {
    public bool isJQK(Card C)
    {
      if (C.Rank == 11 || C.Rank == 12 || C.Rank == 13)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public bool removeEleven(Player P)
    {
      if (P.Select[0].Rank + P.Select[1].Rank == 11)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public bool removeJQK(Player P)
    {
      if ( isJQK(P.Select[0]) && isJQK(P.Select[1]) && isJQK(P.Select[2]) )
      {
        if ( (P.Select[0].Rank != P.Select[1].Rank && P.Select[0].Rank != P.Select[2].Rank) && (P.Select[1] != P.Select[2]) )
        {
          return true;
        }
      }
      return false;
      // if C0 is JQK C1 is JQK C2 is JQK
      // C0 != C1 && C0 != C2
      // C1 != C2
      // removable = true; 
    }
    public bool validCard(int r)
    {
      if (r >= 1 && r <= 13)
      {
        return true;
      }
      return false;
    }
    public bool isLost(List<Card> p)
    {
      List<int> temp = new List<int>();
      for (int i = 0; i < p.Count; i++)
      {
        for (int j = i + 1; j < p.Count; j++)
        {
          if (isJQK(p[j]) && !temp.Contains(p[j].Rank))
          {
            temp.Add(p[j].Rank);
          }
          if (temp.Count == 3)
          {
            return false;
          }
          // check if the card is in temp, if not then put it in.
          // put into the Temp
          // if Temp has three cards then lost is false and break.
          if (p[i].Rank + p[j].Rank == 11)
          {
            return false;
          }
        }
      }
      return true;
    }
    public bool isWon(GameBoard G, Deck D)
    {
      if (G.Cards.Count() == 0 && D.Cards.Count() == 0)
      {
        return true;
      }
      return false;
    }
  }
}
