namespace Identifiable_Object;

public class Tests
{
    private Inventory myInventory;
    private Item shovel;
    private Item spade;

    [SetUp]
    public void Setup()
    {
        myInventory = new Inventory();
        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        spade = new Item(new string[] { "spade" }, "a spade", "This is a spade");
        myInventory.Put(shovel);
    }

    [Test]
    public void FindItem()
    {
        Assert.IsTrue(myInventory.HasItem(shovel.FirstId));
    }

    [Test]
    public void NoItemFind()
    {
        Assert.IsFalse(myInventory.HasItem(spade.FirstId));
    }

    [Test]
    public void FetchItem()
    {
        Assert.IsTrue((myInventory.Fetch(shovel.FirstId) == shovel) && (myInventory.HasItem(shovel.FirstId)));
    }

    [Test]
    public void TakeItem()
    {
        Assert.AreEqual(myInventory.Take(shovel.FirstId), shovel);
        Assert.IsFalse(myInventory.HasItem(shovel.FirstId));
    }

    [Test]
    public void ItemList()
    {
        myInventory.Put(spade);
        Assert.AreEqual(myInventory.ItemList, "a shovel (shovel)\na spade (spade)\n");
    }
}
