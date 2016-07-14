using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Events
{
    public class PausedEventArgs : EventArgs
    {
        public PausedEventArgs(bool isPaused)
        {
            p = isPaused;
        }
        private bool p;
        public bool IsPaused { get { return p; } }
    }
}
