using System;

namespace Identifiable_Object;

public class Tests
{
    private Bag myBag;
    private Item shovel;
    private Item spade;

    [SetUp]
    public void Setup()
    {
        myBag = new Bag(new string[] { "bag" }, "big bag", "This is my bag.");
        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        spade = new Item(new string[] { "spade" }, "a spade", "This is a spade");
        myBag.Inventory.Put(shovel);
    }

    [Test]
    public void LocatesItems()
    {
        Assert.AreEqual(myBag.Locate(shovel.FirstId), shovel);
    }

    [Test]
    public void LocatesItself()
    { 
        Assert.AreEqual(myBag.Locate(myBag.FirstId), myBag);
    }

    [Test]
    public void LocatesNothing()
    {
        Assert.AreEqual(myBag.Locate(spade.FirstId), null);
    }

    [Test]
    public void FullDescription()
    {
        string _desc = $"In the big bag you can see:\n{myBag.Inventory.ItemList}";
        Assert.AreEqual(myBag.FullDescription, _desc);
    }

    [Test]
    public void inBag()
    {
        Bag anotherBag = new Bag(new string[] { "sub bag" }, "2nd bag", "This is my 2nd bag.");
        myBag.Inventory.Put(anotherBag);
        anotherBag.Inventory.Put(spade);
        Assert.AreEqual(myBag.Locate(anotherBag.FirstId), anotherBag);
        Assert.AreEqual(myBag.Locate(shovel.FirstId), shovel);
        Assert.AreEqual(myBag.Locate(spade.FirstId), null);
    }
}
