using System;

namespace Identifiable_Object;

public class Tests
{
    private Player p;
    private Item gem;
    private Bag bag;

    [SetUp]
    public void Setup()
    {
        p = new Player("player", "amateur level player");
        gem = new Item(new string[] { "gem" }, "a gem", "This is a gem");
        bag = new Bag(new string[] { "bag" }, $"{p.Name}'s bag", $"This is {p.Name}'s bag");
    }

    [Test]
    public void LookAtMe()
    {
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "inventory" });
        Assert.AreEqual(lookatme, p.FullDescription);
    }

    [Test]
    public void LookAtGem()
    {
        p.Inventory.Put(gem);
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem" });
        Assert.AreEqual(lookatme, gem.FullDescription);
    }

    [Test]
    public void LookAtUnk()
    {
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem" });
        Assert.AreEqual(lookatme, $"I can't find the gem in the {p.Name}.");
    }

    [Test]
    public void LookAtGemInMe()
    {
        p.Inventory.Put(gem);
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });
        Assert.AreEqual(lookatme, gem.FullDescription);
    }

    [Test]
    public void LookAtGemInBag()
    {
        bag.Inventory.Put(gem);
        p.Inventory.Put(bag);
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(lookatme, gem.FullDescription);
    }

    [Test]
    public void LookAtGemInNoBag()
    {
        bag.Inventory.Put(gem);
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(lookatme, $"I can't find the bag");
    }

    [Test]
    public void LookAtNoGemInBag()
    {
        p.Inventory.Put(bag);
        string lookatme = new Look_Command().Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.AreEqual(lookatme, $"I can't find the gem in the {p.Name}'s bag.");
    }

    [Test]
    public void InvalidLook()
    {
        string lookatme1 = new Look_Command().Execute(p, new string[] { "hello" });
        string lookatme2 = new Look_Command().Execute(p, new string[] { "run", "around", "inventory"});
        string lookatme3 = new Look_Command().Execute(p, new string[] { "look", "around", "inventory" });
        Assert.AreEqual(lookatme1, "I don't know how to look like that");
        Assert.AreEqual(lookatme2, "Error in look input");
        Assert.AreEqual(lookatme3, "What do you want to look at?");
    }
}
