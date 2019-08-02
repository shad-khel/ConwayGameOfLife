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

        public string Print()
        {
            return _state ? "X" : "-";
        }

        public bool IsAlive()
        {
            return _state;
        }

        public void SetToRandomState()
        {
            //Ref ExtremeML
            _state = new Random().Next(100) % 2 == 0;
        }
    }
}
