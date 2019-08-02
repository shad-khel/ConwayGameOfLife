using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public class UniverseSquare
    {
        private bool _state;

        public UniverseSquare(bool state)
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

        public string Print()
        {
            return _state ? "X" : "-";
        }
    }
}
