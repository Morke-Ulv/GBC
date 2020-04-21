using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGBC
{
    public class MenuRepository
    {
        protected List<Menu> _menuDirectory = new List<Menu>();
        
        public bool AddItemToDirecotry(Menu item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(item);

            bool wasAdded = (_menuDirectory.Count > startingCount);
                return wasAdded;
        }

        public List<Menu> MenuContent()
        {
            return _menuDirectory;
        }

        public bool RemoveItemFromMenu(string name)
        {
            int startingCount = _menuDirectory.Count;

            int index = -1;
            foreach (Menu item in _menuDirectory)
            {
                if (item.Name == name)
                {
                    index = _menuDirectory.IndexOf(item);
                }
            }
            if (index != -1)
            {

                _menuDirectory.RemoveAt(index);
            }

            bool wasRemoved = (_menuDirectory.Count < startingCount);
            return wasRemoved;
        }
    }
}
