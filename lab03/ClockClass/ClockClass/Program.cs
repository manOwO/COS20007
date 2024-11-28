// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using CounterTask;

namespace ClockClass
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();
            Console.WriteLine(myClock.Time);

            for (int m = 0; m < 60; m++)
            {
                for (int s = 0; s < 60; s++)
                {
                    myClock.Tick();
                }
            }
            Console.WriteLine(myClock.Time);

            Console.ReadLine();
        }
    }
}
