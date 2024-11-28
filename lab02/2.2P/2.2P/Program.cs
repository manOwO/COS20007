// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace CounterTask
{
    class MainClass
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        public static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[3];

            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int index = 0; index < 10; index++)
            {
                myCounters[0].Increment();
            }

            for (int index = 0; index < 15; index++)
            {
                myCounters[1].Increment();
            }
            
            PrintCounters(myCounters);
            
            myCounters[2].Reset();

            PrintCounters(myCounters);

            Console.ReadLine();
        }
    }
}