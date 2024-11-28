namespace SwinAdventure;

public class Tests
{
    Path path;
    Location city, lake;

    [SetUp]
    public void Setup()
    {
        city = new Location("city", "the CBD");
        lake = new Location("lake", "a nearby lake");
        path = new Path(new string[] { "move", "north" }, "north", "to a nearby lake", lake);
        
    }

    [Test]
    public void NoPathIsFoundInCity()
    {
        Assert.AreEqual(city.Paths.Count, 0);
    }

    [Test]
    public void PathToLakeIsFound()
    {
        city.AddPath(path);
        Assert.AreEqual(city.Paths[0].Destination, lake);
    }

    [Test]
    public void PathsDescription()
    {
        city.AddPath(path);
        Assert.AreEqual(city.PathsList, $"Paths you can go via this location:\nmove north to {lake.Name}");
    }
}
