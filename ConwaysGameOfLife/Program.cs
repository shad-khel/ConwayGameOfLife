using System;
using System.Collections;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conways Game of life World!");

            var universe = new Grid(20, 20);
            universe.SeedUniverse();
            //var universe = new Grid(GetKnownPattern3());

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

        public static UniverseSquare[,] GetKnownPattern1()
        {
            //http://pi.math.cornell.edu/~lipa/mec/lesson6.html

            var n = new UniverseSquare[3, 3];
            var v = new[]
            {
                false,true,false,
                false,true,false,
                false,true,false
            };

            return TranslateBoolArrayTo2DUniverseArray(v, n);
        }

        public static UniverseSquare[,] GetKnownPattern2()
        {

            var n = new UniverseSquare[5, 5];
            var v = new[]
            {
                false,false,false,false,false,
                false,true,true,true,false,
                false,true,false,false,false,
                false,false,false,false,false,
                false,false,false,false,false
            };

            return TranslateBoolArrayTo2DUniverseArray(v, n);
        }

        public static UniverseSquare[,] GetKnownPattern3()
        {

            var n = new UniverseSquare[10, 10];
            var v = new[]
            {
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,true,true,true,true,true,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
            };

            return TranslateBoolArrayTo2DUniverseArray(v, n);
        }

        public static UniverseSquare[,] GetKnownPattern4()
        {

            var n = new UniverseSquare[10, 10];
            var v = new[]
            {
                false,true,false,false,false,false,false,false,false,false,
                false,false,true,false,false,false,false,false,false,false,
                true,true,true,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
                false,false,false,false,false,false,false,false,false,false,
            };

            return TranslateBoolArrayTo2DUniverseArray(v, n);
        }



        public static UniverseSquare[,] TranslateBoolArrayTo2DUniverseArray(bool[] v, UniverseSquare[,] n)
        {
          
            var count = 0;
            for (int i = 0; i < n.GetLength(0); i++)
            {
                for (int j = 0; j < n.GetLength(1); j++)
                {
                    n[i, j] = new UniverseSquare(v[count]);
                    count++;
                }
            }

            return n;
        }

    }
}
