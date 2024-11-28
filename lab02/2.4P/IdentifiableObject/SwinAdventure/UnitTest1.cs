namespace SwinAdventure;

public class Tests
{
    private IdentifableObject id;
    private IdentifableObject idEmpty;

    [SetUp]
    public void Setup()
    {
        id = new IdentifableObject(new string[] { "fred", "bob" });
        idEmpty = new IdentifableObject(new string[] {});
    }

    [Test]
    public void TestAreYou()
    {
        Assert.IsTrue(id.AreYou("fred"));
        Assert.IsTrue(id.AreYou("bob"));
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.IsFalse(id.AreYou("boby"));
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.IsTrue(id.AreYou("FRED"));
        Assert.IsTrue(id.AreYou("bOB"));
    }

    [Test]
    public void TestFirstID()
    {
        Assert.AreEqual("fred", id.FirstId);
    }

    [Test]
    public void TestFirstIDWithNoIDs()
    {
        Assert.AreEqual("", idEmpty.FirstId);
    }

    [Test]
    public void TestAddID()
    {
        id.AddIdentifier("wilma");
        Assert.IsTrue(id.AreYou("wilma"));
    }
}
