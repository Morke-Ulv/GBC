using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGBC
{
    public class Menu
    {
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public Menu() { }
        public Menu(
            int itemNumber,
            string name,
            string desctription,
            string ingredients,
            double price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = desctription;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
