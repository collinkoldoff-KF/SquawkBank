﻿using System;

namespace SquawkBank.Core.Events
{
    public class PushToMuteStateChangedEventArgs : EventArgs
    {
        public bool Down { get; set; }
        public PushToMuteStateChangedEventArgs() { }
        public PushToMuteStateChangedEventArgs(bool down) : this()
        {
            Down = down;
        }
    }
}
