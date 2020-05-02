using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesGBC
{
    class Program
    {
        private readonly BadgesRepository _repo = new BadgesRepository();
        string door;
            List<Doors> doorsList = new List<Doors>();
        static void Main(string[] args)
        {
            Program ui = new Program();
            ui.SeedContent();
            ui.RunMenu();
        }
        public void SeedContent()
        {
            Badges firstbadge = new Badges();
            firstbadge.ID = 123;
            Doors firstDoor = new Doors();
            firstDoor.Door = "Door C";
            Doors secondDoor = new Doors();
            secondDoor.Door = "Door 121";
            List<Doors> doors = new List<Doors>() { firstDoor, secondDoor };
            firstbadge.Door = doors;
            

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
            Console.Clear();
            Console.WriteLine("What is the Employee's Badge ID?");
            int id = int.Parse(Console.ReadLine());
            DoorEase();
            Badges newbadge = new Badges(id, doorsList);
            bool badgeWasAdded = _repo.BadgeAddedToDirectory(newbadge);
            if (badgeWasAdded)
            {
                Console.WriteLine($"Badge {id} was added.");

            }
            else
            {
                Console.WriteLine("Badge was not added to the system.");

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What Badge ID would you like to update?");
            int id = int.Parse(Console.ReadLine());
            _repo.GetBadgeForUpdate(id);
            DoorEase();
            Badges newBadge = new Badges();
            _repo.UdateBadge(id, newBadge);
            Console.WriteLine($"Badge {id} has been updated.");


        }

        public void ListBadges()
        {
            Console.Clear();

            int index = 1;
            List<Badges> contents = _repo.GetContents();
            foreach (Badges content in contents)
            {
                Console.WriteLine($"{index++}. {content.ID} ({content.Door})");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }

        public void DoorEase()
        {
            Console.WriteLine($"What door can they activate?");
            door = Console.ReadLine();
            var door2 = new Doors() {Door = door };
            doorsList.Add(door2);
            Console.WriteLine("Add more? y/n");
            string answer = Console.ReadLine();
            bool loop = true;
            while (loop)
            {
                switch (answer)
                {
                    case "y":
                    case "Y":
                        Console.WriteLine($"What's another door to add to it?");
                         door = Console.ReadLine();
                        door2 = new Doors() { Door = door };
                        doorsList.Add(door2);
                        break;
                    case "n":
                    case "N":
                        Console.WriteLine($"This Badge has been updated");
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
