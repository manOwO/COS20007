using System.IO;

namespace SwinAdventure;

public class Tests
{
    private Player player;
    private Location city, lake, jungle;
    private Path path1, path2;
    
    [SetUp]
    public void Setup()
    {
        player = new Player("Anonymous player", "a novice player");
        city = new Location("city", "the CBD");
        lake = new Location("lake", "a gigantic lake");
        jungle = new Location("jungle", "mysterious jungle");
        path1 = new Path(new string[] { "move", "north" }, "north", "to a nearby lake", lake);
        path2 = new Path(new string[] { "move", "south" }, "south", "to a nearby jungle", jungle);

        player.Location = city;

    }

    [Test]
    public void InputError()
    {
        string move1 = new Move_Command().Execute(player, new string[] { "jump", "around" });
        string move2 = new Move_Command().Execute(player, new string[] { "move" });
        Assert.AreEqual(move1, "Error in move command input.");
        Assert.AreEqual(move2, "Where do you want to move to?");
    }

    [Test]
    public void NoPathInCity()
    {
        string move = new Move_Command().Execute(player, new string[] { "move", "north" });
        Assert.AreEqual(move, $"No path is found at {player.Location.Name}.");
    }

    [Test]
    public void PlayerMoveValid()
    {
        city.AddPath(path1);
        string move = new Move_Command().Execute(player, new string[] { "move", "north" });
        Assert.AreEqual(move, $"The {player.Name} just {path1.FullDescription}");
        Assert.AreEqual(lake, player.Location);
    }

    [Test]
    public void PlayerMoveInvalid()
    {
        city.AddPath(path1);
        string move = new Move_Command().Execute(player, new string[] { "move", "south" });
        Assert.AreEqual(move, $"Path towards south is not found at {player.Location.Name}.");
        Assert.AreEqual(city, player.Location);
    }
}
