using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicClock
{
    public sealed class SecondListenerClock
    {
        public void Register(TimerClock clock)
        {
            clock.Timer += Listener2Msg;
        }

        public void Unregister(TimerClock clock)
        {
            clock.Timer -= Listener2Msg;
        }

        private void Listener2Msg(object sender, TimerEventArgs e)
        {
            Console.WriteLine("----- SecondListenerClock -----");
            Console.WriteLine($"----- Spend time {e.SpendTime} -----" + Environment.NewLine);
        }
    }
}
