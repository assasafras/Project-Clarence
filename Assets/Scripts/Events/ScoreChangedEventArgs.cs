using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Events
{
    public class ScoreChangedEventArgs : EventArgs
    {
        public ScoreChangedEventArgs(int score)
        {
            s = score;
        }
        private int s;
        public int Score { get { return s; } }
    }
}
