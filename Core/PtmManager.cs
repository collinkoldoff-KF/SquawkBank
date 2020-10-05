using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Appccelerate.EventBroker;
using SquawkBank.Core.Events;

namespace SquawkBank.Core
{
    class PtmManager : EventBus, IPtmManager
    {
        public event EventHandler<PushToMuteStateChangedEventArgs> PushToMuteStateChanged;

        public static System.Windows.Forms.Timer mPtmTimer;
        private bool mPtmStatus;

        [DllImport("user32.dll")]
        private static extern ushort GetAsyncKeyState(int state);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public PtmManager(IEventBroker broker) : base(broker)
        {
            mPtmTimer = new System.Windows.Forms.Timer
            {
                Interval = 10
            };
            mPtmTimer.Tick += PtmTimer_Tick;
            OnSessionStarted(null, null);
        }

        private void PtmTimer_Tick(object sender, EventArgs e)
        {
            CheckPtmDevice();
        }

        private void CheckPtmDevice()
        {
            bool isPressed = false;
            isPressed = (GetAsyncKeyState(Keys.A) & 32768) > 0 && (GetAsyncKeyState(Keys.F9) & 32768) > 0;

            if (isPressed != mPtmStatus)
            {
                mPtmStatus = isPressed;
                if (mPtmStatus)
                {
                    Form1.IncrementSquawk();
                    Form1.updateLabel2();
                    Form1.sendNewSquawk();
                }
                else
                {
                    
                }

            }
        }

        public void OnSessionStarted(object sender, EventArgs e)
        {
            mPtmTimer.Start();
        }

        public void OnSessionEnded(object sender, EventArgs e)
        {
            mPtmTimer.Stop();
        }

        public void OnClientConfigChanged(object sender, EventArgs e)
        {
        }
    }
}
