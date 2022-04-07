using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
  internal class Player
  {
    private List<Card> select = new List<Card>();
    //private int selectRank = 0;
    private string name;
    public Player(string name) { this.name = name; }
    public List<Card> Select { get { return select; } set { select= value; } }
    //public int SelectRank { get { return SelectRank; } set { SelectRank = value; } } // property
    public string Name { get { return name; } set { name = value; } }

  }
}
