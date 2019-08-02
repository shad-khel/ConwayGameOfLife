using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public static class DisplayUniverseConsole
    {
        public static string PrintHorizontalLine(this UniverseSquare[,] universe, int line)
        {
            var result = "";

            for (int i = 0; i < universe.GetLength(0); i++)
            {
                result = result + universe[line, i].Print();
            }

            return result;
        }
    }
}
