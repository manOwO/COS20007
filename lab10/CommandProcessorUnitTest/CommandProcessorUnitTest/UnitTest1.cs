using System;

namespace SwinAdventure;

public class Tests
{
    private Player player;
    private Item gem;
    private Bag bag;
    private Location city, lake;
    private Path path1;

    [SetUp]
    public void Setup()
    {
        player = new Player("Anonymous player", "a novice player");

        bag = new Bag(new string[] { "bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag");
        gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        

        city = new Location("city", "the CBD");
        lake = new Location("lake", "a gigantic lake");
        
        path1 = new Path(new string[] { "move", "north" }, "north", "to a nearby lake", lake);
        
        
        player.Location = city;
    }

    [Test]
    public void InvalidInput()
    {
        string command = new CommandProcessor().CommandExecute(player, new string[] { "jump" });
        Assert.AreEqual(command, "Invalid command input.");
    }

    [Test]
    public void LookAtMe()
    {
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "inventory" });
        Assert.AreEqual(command, player.FullDescription);
    }

    [Test]
    public void LookAtGem()
    {
        player.Inventory.Put(gem);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem" });
        Assert.AreEqual(command, gem.FullDescription);
    }

    [Test]
    public void LookAtUnk()
    {
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem" });
        Assert.AreEqual(command, $"I can't find the gem in the {player.Name}.");
    }

    [Test]
    public void LookAtGemInMe()
    {
        player.Inventory.Put(gem);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem", "in", "inventory" });
        Assert.AreEqual(command, gem.FullDescription);
    }

    [Test]
    public void LookAtGemInBag()
    {
        bag.Inventory.Put(gem);
        player.Inventory.Put(bag);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(command, gem.FullDescription);
    }

    [Test]
    public void LookAtGemInNoBag()
    {
        bag.Inventory.Put(gem);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(command, $"I can't find the bag");
    }

    [Test]
    public void LookAtNoGemInBag()
    {
        player.Inventory.Put(bag);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(command, $"I can't find the gem in the {player.Name}'s bag.");
    }

    [Test]
    public void NoPathInCity()
    {
        string command = new CommandProcessor().CommandExecute(player, new string[] { "move", "north" });
        Assert.AreEqual(command, $"No path is found at {player.Location.Name}.");
    }

    [Test]
    public void PlayerMoveValid()
    {
        city.AddPath(path1);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "move", "north" });
        Assert.AreEqual(command, $"The {player.Name} just {path1.FullDescription}");
        Assert.AreEqual(lake, player.Location);
    }

    [Test]
    public void PlayerMoveInvalid()
    {
        city.AddPath(path1);
        string command = new CommandProcessor().CommandExecute(player, new string[] { "move", "south" });
        Assert.AreEqual(command, $"Path towards south is not found at {player.Location.Name}.");
        Assert.AreEqual(city, player.Location);
    }

}
