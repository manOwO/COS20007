namespace Identifiable_Object;

public class Tests
{
    private Player me;
    private Item shovel;
    private Item spade;

    [SetUp]
    public void Setup()
    {
        me = new Player("An", "a freshman");
        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        spade = new Item(new string[] { "spade" }, "a spade", "This is a spade");
        me.Inventory.Put(shovel);
    }

    [Test]
    public void Identifiable()
    {
        Assert.IsTrue(me.AreYou("me"));
        Assert.IsTrue(me.AreYou("inventory"));
        
    }

    [Test]
    public void LocatesItems()
    {
        Assert.AreEqual(me.Locate(shovel.FirstId), shovel);
    }

    [Test]
    public void LocatesItself()
    {
        Assert.AreEqual(me.Locate("me"), me);
        Assert.AreEqual(me.Locate("inventory"), me);
    }

    [Test]
    public void LocatesNothing()
    {
        Assert.IsNull(me.Locate(spade.FirstId));
    }

    [Test]
    public void FullDes()
    {
        Assert.AreEqual(me.FullDescription, $"You are An, a freshman. You are carrying:\n{me.Inventory.ItemList}");
    }
}
