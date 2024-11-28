using System;
using System.Diagnostics;

namespace Identifiable_Object
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Player's name:");
            string _name = new string(Console.ReadLine());
            Console.WriteLine("Player's description:");
            string _desc = new string(Console.ReadLine());

            Player player = new Player(_name, _desc);

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item spade = new Item(new string[] { "spade" }, "a spade", "This is a spade");
            player.Inventory.Put(shovel);
            player.Inventory.Put(spade);

            Bag bag = new Bag(new string[] { "bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);

            while (true)
            {
                Console.WriteLine("Look at what (in where):");
                string readingCommands = new string(Console.ReadLine());
                Console.WriteLine(new Look_Command().Execute(player, readingCommands.Split()));
                if (new string(Console.ReadLine()) == "break" || new string(Console.ReadLine()) == "stop")
                {
                    break;
                }
            }
            
            

        }
    }
}
