using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetGBC
{
    class User
    {
        public enum UserType
        {
            Potential = 1, Current, Past
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType TypeOfUser { get; set; }

        public User() { }
        public User(string firstName, string lastName, UserType type)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfUser = type;
            
        }


    }
}
