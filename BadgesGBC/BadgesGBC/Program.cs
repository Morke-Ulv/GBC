using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesGBC
{
    class Program
    {
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void SeedContent()
        {

        }


        public void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Menu\n" +
                "Hello Security Admin, What would you like to do?\n" +
                "1.Add a badge\n" +
                "2.Edit a badge.\n" +
                "3.List all Badges\n" +
                "4.Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        Console.WriteLine("GoodBye.");
                        Console.ReadKey();
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }
            }

        }
            public void AddBadge()
            {

            }

            public void EditBadge()
            {

            }

            public void ListBadges()
            {

            }
    }
}
