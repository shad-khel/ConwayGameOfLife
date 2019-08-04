using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conways Game of life World!");

            var universe = new Grid(10, 10);
            universe.SeedUniverse();

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine($"------Tick {i}------");

                universe.GetUniverse().PrintUniverseInConsole();
                universe.Tick();
                Console.ReadLine();
            }
        }
    }
}
