using System.Numerics;
using System.Xml.Linq;

namespace Identifiable_Object;

public class Tests
{
    private Player player;
    private Item shovel;
    private Location locationOfPlayer;


    [SetUp]
    public void Setup()
    {
        player = new Player("Anonymous", "a secretive, lowkey figure");
        locationOfPlayer = new Location("Hawthorn", "Player is at Hawthorn.");
        player.Location = locationOfPlayer;

        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        locationOfPlayer.Inventory.Put(shovel);

    }

    [Test]
    public void LocationsIdentifyThemselves()
    {
        Assert.IsTrue(player.Location.AreYou("location"));
    }

    [Test]
    public void LocationsLocateItems()
    {
        Assert.AreEqual(player.Location.Locate("shovel"), shovel);
    }

    [Test]
    public void PlayerLocatesItemsInLocation()
    {
        Assert.AreEqual(player.Locate("shovel"), shovel);
    }
}
