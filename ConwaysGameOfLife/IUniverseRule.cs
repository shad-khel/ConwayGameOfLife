using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public interface IUniverseRule
    {
        
    }
     
    //Run though each rule
    //Each Rule is testable


    //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
    //Any live cell with two or three live neighbours lives on to the next generation.
    //Any live cell with more than three live neighbours dies, as if by overpopulation.
    //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
}
