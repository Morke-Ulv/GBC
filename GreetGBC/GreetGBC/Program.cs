using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GreetGBC.User;

namespace GreetGBC
{
    class Program
    {
        private readonly UserRepository _repo = new UserRepository();
        static void Main(string[] args)
        {
            Program ui = new Program();
            ui.Seed();
            ui.RunMenu();
        }

        public void Seed()
        {
            User person = new User("Karin", "King", UserType.Potential);
            User person1 = new User("Bob", "King", UserType.Potential);
            User person2 = new User("Dakota", "Scott", UserType.Potential);
            User person3 = new User("Jibinwar", "Spaghetti", UserType.Potential);
        }

        public void RunMenu()
        {
            bool programRunning = true;
            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number you would like to select:\n" +
                    "1. Create New User\n" +
                    "2. Remove User\n" +
                    "3. Display all Users\n" +
                    "4. Edit User\n" +
                    "5. Exit.");

                string userinput = Console.ReadLine();
                switch(userinput)
                {

                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        RemoveUser();
                        break;
                    case "3":
                        DisplayUsers();
                        break;
                    case "4":
                        EditUser();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        Console.ReadKey();
                        programRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }

        public void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("What is the user's First Name?");
            string firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"What is {firstName} last name?");
            string lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Select user type:\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            int choice = Int32.Parse(Console.ReadLine());
            UserType type = (UserType)choice;
            User newUser = new User(firstName,lastName, type);

            bool contentWasAdded = _repo.AddContent(newUser);
            if (contentWasAdded)
            {
                Console.WriteLine($"User {firstName} {lastName} has been added.");
            }
            else
            {
                Console.WriteLine("User was not added.");
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();

        }


        public void RemoveUser()
        {
            Console.Clear();
            Console.WriteLine("What is the user's first name?");
            string firstName = Console.ReadLine();
            Console.WriteLine("What is the user's last name?");
            string lastName = Console.ReadLine();
            string fullName = (firstName + " " + lastName);
            _repo.RemoveUser(fullName);
        }

        
        public void DisplayUsers()
        {
            Console.Clear();
            int index = 1;
            List<User> contents = _repo.GetContent();
            foreach(User content in contents)
            {
                string email;
                if(content.TypeOfUser == UserType.Current)
                {
                    email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if(content.TypeOfUser == UserType.Past)
                {
                    email = "It's been a long time since we've heard from you, we want you back";
                }
                else if(content.TypeOfUser == UserType.Potential)
                {
                    email = "We currently have the lowest rates on Helicopter Insurance!";
                }
                    
                Console.WriteLine($"{index++}. {content.FirstName}   {content.LastName}   {content.TypeOfUser}   {email}");

            }
        }

        public void EditUser()
        {
            Console.Clear();
            Console.WriteLine("What is the user's first name that you would like to update?");
            string firstName = Console.ReadLine();
            Console.WriteLine($"What is {firstName} last name that you would like to update?");
            string lastName = Console.ReadLine();
            _repo.GetUserForUpdate(firstName, lastName);
            Console.WriteLine("What is the user's First Name?");
            string newFirstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"What is {newFirstName} last name?");
            string newLastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Select user type:\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            int choice = Int32.Parse(Console.ReadLine());
            UserType type = (UserType)choice;
            User newUser = new User();
            _repo.UdateUser(firstName, lastName, newUser);
            Console.WriteLine($"User {newFirstName} {newLastName} has been updated.");
        }
    }
}
