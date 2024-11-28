using ClockClass;
namespace ClockTest;

public class Tests
{
    private Clock myClock;

    [SetUp]
    public void Setup()
    {
        myClock = new Clock();
    }

    [Test]
    public void Initialising()
    {
        Assert.IsTrue(myClock.Time == "00:00:00");
    }

    [Test]
    public void Ticking()
    {
        myClock.Tick();
        Assert.IsTrue(myClock.Time == "00:00:01");
    }

    [Test]
    public void TickingNextMinute()
    {
        for (int i = 0; i < 60; i ++)
        {
            myClock.Tick();
        }
        Assert.IsTrue(myClock.Time == "00:01:00");
    }

    [Test]
    public void TickingNextHour()
    {
        for (int m = 0; m < 60; m++)
        {
            for (int s = 0; s < 60; s++)
            {
                myClock.Tick();
            }
        }
        
        Assert.IsTrue(myClock.Time == "01:00:00");
    }

    [Test]
    public void TickingNextDay()
    {
        for (int h = 0; h < 24; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                for (int s = 0; s < 60; s++)
                {
                    myClock.Tick();
                }
            }
        }
        
        Assert.IsTrue(myClock.Time == "00:00:00");
    }

    [Test]
    public void Reset()
    {
        myClock.Tick();
        myClock.Reset();
        Assert.IsTrue(myClock.Time == "00:00:00");
    }
}
