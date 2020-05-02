using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesGBC
{
    public class BadgesRepository
    {
        Dictionary<int ,Badges> _BadgesDirectory = new Dictionary<int, Badges>();
        protected List<Badges> _BadgesList = new List<Badges>();
        public bool BadgeAddedToDirectory(Badges badge)
        {
            int startingCount = _BadgesDirectory.Count;

            _BadgesDirectory.Add(_BadgesDirectory.Count + 1, badge);

            bool wasAdded = (_BadgesDirectory.Count > startingCount);
            return wasAdded;
        }

        public Badges GetBadgeForUpdate(int id)
        {
            foreach (int key in _BadgesDirectory.Keys)
            {
                Badges badges = _BadgesDirectory[key];
                if (badges.ID == id)
                {
                    return badges;
                }
            }
            return null;
        }

        public void UdateBadge(int id, Badges newBadge)
        {
            Badges oldBadge = GetBadgeForUpdate(id);
            if (oldBadge != null)
            {
                oldBadge.Door = newBadge.Door;
            }
        }

        public List<Badges> GetContents()
        {
            return _BadgesList;
        }
    }
}
