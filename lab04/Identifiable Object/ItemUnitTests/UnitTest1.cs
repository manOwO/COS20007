namespace Identifiable_Object;

public class Tests
{
    private Item shovel;

    [SetUp]
    public void Setup()
    {
        shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
    }

    [Test]
    public void Identifiable()
    {
        Assert.IsTrue(shovel.AreYou("shovel"));
        Assert.IsFalse(shovel.AreYou("spade"));
    }

    [Test]
    public void ShortDes()
    {
        Assert.AreEqual(shovel.ShortDescription, "a shovel (shovel)");
    }

    [Test]
    public void FullDes()
    {
        Assert.AreEqual(shovel.FullDescription, "This is a shovel");
    }
}
