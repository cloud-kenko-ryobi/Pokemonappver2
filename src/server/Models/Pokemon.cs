
namespace PokeApi.Models
{
  public class Pokemon {
        public int id {get ;set; }
        public name name {get ;set; }
        public string[] type {get ;set; }
        public baseAttr @base {get ;set; }
  }

    public class name
    {
        public string english {get ;set; }
        public string japanese {get ;set; }
        public string chinese {get ;set; }
    }

    public class baseAttr
    {
        public int HP {get ;set; }
        public int Attack {get ;set; }
        public int Defence {get ;set; }
        public int Sp_Attack {get ;set; }
        public int Sp_Defence {get ;set; }
        public int Speed {get ;set; }
    }

}
