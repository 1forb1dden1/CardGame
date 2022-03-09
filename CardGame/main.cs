using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  class Program
  {
    public static void Main(string[] args)
    {
      Game game = new Game(); 
      Deck deck = new Deck();
      deck.Shuffle();
      Player Player1 = new Player("Player1");
      game.DealCards(deck, 10, Player1.hand);
      game.GameSelectTwoCards(Player1.hand, deck);
    }
  }
}
