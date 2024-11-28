using CounterTask;

namespace CounterTest;

public class Tests
{
    private Counter myCounter;

    [SetUp]
    public void Setup()
    {
        myCounter = new Counter("test");

    }

    [Test]
    public void Initialising()
    {
        Assert.IsTrue(myCounter.Ticks == 0);
    }

    [Test]
    public void IncrementingSingle()
    {
        myCounter.Increment();
        Assert.IsTrue(myCounter.Ticks == 1);
    }

    [Test]
    public void IncrementingMultiple()
    {
        myCounter.Reset();
        for (int i = 0; i < 10; i ++)
        {
            myCounter.Increment();
        }

        Assert.IsTrue(myCounter.Ticks == 10);
    }

    [Test]
    public void Resetting()
    {
        myCounter.Increment();
        myCounter.Reset();
        Assert.IsTrue(myCounter.Ticks == 0);
    }
}
