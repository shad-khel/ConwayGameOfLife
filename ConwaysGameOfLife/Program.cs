using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conways Game of life World!");

            /// var universe = new Grid(100, 100);
            /// universe.SeedUniverse();
            var universe = new Grid(GetKnownPattern());

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"------Tick {i}------");

                universe.GetUniverse().PrintUniverseInConsole();
                universe.Tick();

                //Thread.Sleep(500);
                Console.ReadLine();
            }
        }

        public static UniverseSquare[,] GetKnownPattern()
        {
            //http://pi.math.cornell.edu/~lipa/mec/lesson6.html

            var example = new UniverseSquare[3, 3];
            example[0,0] = new UniverseSquare(false);  example[0,1] = new UniverseSquare(true); example[0, 2] = new UniverseSquare(false);
            example[1, 0] = new UniverseSquare(false); example[1,1] = new UniverseSquare(true); example[1, 2] = new UniverseSquare(false);
            example[2, 0] = new UniverseSquare(false); example[2,1] = new UniverseSquare(true); example[2, 2] = new UniverseSquare(false);

            return example;
        }
    }
}
