// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Numerics;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Anonymous player", "a novice player");

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
            Item spade = new Item(new string[] { "spade" }, "a spade", "This is a spade");
            player.Inventory.Put(shovel);
            player.Inventory.Put(spade);
            Bag bag = new Bag(new string[] { "bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
            Item gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);

            Location city = new Location("city", "the CBD");
            Location lake = new Location("lake", "a gigantic lake");
            Location jungle = new Location("jungle", "mysterious jungle");
            Path path1 = new Path(new string[] { "move", "north" }, "north", "to a nearby lake", lake);
            Path path2 = new Path(new string[] { "move", "east" }, "east", "to a nearby jungle", jungle);
            Path path3 = new Path(new string[] { "move", "southwest" }, "southwest", "to the city", city);
            city.AddPath(path1);
            lake.AddPath(path2);
            jungle.AddPath(path3);
            player.Location = city;


            while (true)
            {
                Console.WriteLine(player.FullDescription);
                Console.WriteLine(player.Location.PathsList);
                Console.WriteLine("Command:");
                string readingCommands = new string(Console.ReadLine());
                Console.WriteLine(new CommandProcessor().CommandExecute(player, readingCommands.Split()));

                if (new string(Console.ReadLine()) == "break" || new string(Console.ReadLine()) == "stop")
                {
                    break;
                }


            }



        }
    }
}