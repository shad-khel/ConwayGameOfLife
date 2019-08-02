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

            universe.GetUniverse().PrintUniverseInConsole();

            Console.Read();
        }
    }
}
