using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Events
{
    public class GameOverEventArgs : EventArgs
    {
        public GameOverEventArgs(GameOverStatus status)
        {
            s = status;
        }
        private GameOverStatus s;
        public GameOverStatus Status { get { return s; } }
    }
}
