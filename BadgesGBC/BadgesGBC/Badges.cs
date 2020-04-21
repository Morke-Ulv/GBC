using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesGBC
{
    class Badges
    {
        public int ID { get; set; }
        public List<Doors> Door { get; set; }


        public Badges() { }
        public Badges(
            int id,
            string doors)
        {
            ID = id;
            Door = doors;
        }
    }

    public class Doors
    {
        public string Door { get; set; }
    }
}
