using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGBC
{
    class Program
    {

        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void SeedContent()
        {
            Menu lasagna = new Menu(
                1,
                "Lasagna",
                "Italian pasta",
                "noodles, tomatoes, sauce, meat, cheese",
                9.23);

            _menuRepo.AddItemToDirecotry(lasagna);
        }

        public void RunMenu()
        {
            bool programisrunning = true;
            while (programisrunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1. Add to the menu\n" +
                    "2. Remove item from menu\n" +
                    "3. View menu\n" +
                    "4. Exit");

                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        AddToMenu();
                        break;
                    case "2":
                        RemoveFromMenu();
                        break;
                    case "3":
                        ShowMenu();
                        break;
                    case "4":
                        Console.WriteLine("GoodBye.");
                        Console.ReadKey();
                        programisrunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddToMenu()
        {
            Console.Clear();
            Console.WriteLine("Add new menu item name:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"What is the {name} menu number?");
            int itemNumber = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"What is the description for {name}?");
            string description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"What are the ingredents for {name}?");
            string ingredents = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"How much is {name}?");
            double price = Double.Parse(Console.ReadLine());

            Menu newitem = new Menu(itemNumber, name, description, ingredents, price);

            bool itemWasAdded = _menuRepo.AddItemToDirecotry(newitem);

            if (itemWasAdded)
            {
                Console.WriteLine($"{name} was added to the menu.");

            }
            else
            {
                Console.WriteLine("Please try again.");

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
                
        }

        public void ShowMenu()
        {
            Console.Clear();

            List<Menu> items = _menuRepo.MenuContent();
            foreach (Menu item in items)
            {
                Console.WriteLine($"{item.ItemNumber}. {item.Name} - ${item.Price}\n" +
                    $"{item.Description}.\n" +
                    $"{item.Ingredients}.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void RemoveFromMenu()
        {

            Console.Clear();
            Console.WriteLine("What is the name of the item you wish to remove?");
            string name = Console.ReadLine();
            _menuRepo.RemoveItemFromMenu(name);
        }

    }
}
