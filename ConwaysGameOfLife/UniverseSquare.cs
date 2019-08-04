using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public class UniverseSquare
    {
        private bool _state;

        public UniverseSquare(bool state = false)
        {
            _state = state;
        }

        public void SetToAlive()
        {
            _state = false;
        }

        public void SetToDie()
        {
            _state = true;
        }

        public char Print()
        {
            return _state ? 'X' : '-';
        }

        public bool IsAlive()
        {
            return _state;
        }

        public GridSquareStatus GridStatus()
        {
            return _state ? GridSquareStatus.Alive : GridSquareStatus.Dead;
        }

        public void SetToRandomState()
        {
            //Ref ExtremeML
            _state = new Random().Next(100) % 2 == 0;
        }
    }
}
