using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetGBC
{
    class UserRepository
    {
        Dictionary<int, User> _contentOops = new Dictionary<int, User>();
        protected List<User> _contentDirectory = new List<User>();
        
        public bool AddContent(User content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount);
            return wasAdded;
        }

        public bool RemoveUser(string fullName)
        {
            int startingCount = _contentDirectory.Count;

            int index = -1;
            foreach (User content in _contentDirectory)
            {
                if (content.FirstName + " " + content.LastName == fullName)
                {
                    index = _contentDirectory.IndexOf(content);
                }
            }
            if (index!=1)
            {
                _contentDirectory.RemoveAt(index);
            }
            bool wasRemoved = (_contentDirectory.Count < startingCount);
            return wasRemoved;
        }

        public List<User> GetContent()
        {
            _contentDirectory.Sort();
            return _contentDirectory;
        }

        public User GetUserForUpdate(string firstName, string lastName)
        {
            foreach (int key in _contentOops.Keys)
            {
                User users = _contentOops[key];
                if (users.FirstName + users.LastName == firstName + lastName)
                {
                    return users;
                }
            }
            return null;
        }

        public void UdateUser(string firstName, string lastName, User newUser)
        {
            User oldUser = GetUserForUpdate(firstName , lastName);
            if (oldUser != null)
            {
                oldUser.FirstName = newUser.FirstName;
                oldUser.LastName = newUser.LastName;
                oldUser.TypeOfUser = newUser.TypeOfUser;
            }
        }
    }
}
