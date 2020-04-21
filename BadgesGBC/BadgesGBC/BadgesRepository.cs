using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesGBC
{
    class BadgesRepository
    {
        Dictionary<int ,Badges> _BadgesDirectory = new Dictionary<int, Badges>();
        public bool BadgeAddedToDirectory(Badges badge)
        {
            int startingCount = _BadgesDirectory.Count;

            _BadgesDirectory.Add(_BadgesDirectory.Count + 1, badge);

            bool wasAdded = (_BadgesDirectory.Count > startingCount);
            return wasAdded;
        }

        public Badges GetBadgeForUpdate(int id)
        {
            foreach (Badges badges in _BadgesDirectory)
            {
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
                oldBadge.ID = newBadge.ID;
                oldBadge.Door = newBadge.Door;
            }
        }
    }
}
