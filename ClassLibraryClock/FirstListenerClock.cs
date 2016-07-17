using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicClock
{
    public sealed class FirstListenerClock
    {
        public void Register(TimerClock clock)
        {
            clock.Timer += Listener1Msg;
        }

        public void Unregister(TimerClock clock)
        {
            clock.Timer -= Listener1Msg;
        }

        private void Listener1Msg(object sender, TimerEventArgs e)
        {
            Console.WriteLine("----- FirstListenerClock -----");
            Console.WriteLine($"----- Spend time {e.SpendTime} -----" + Environment.NewLine);
        }
    }
}
