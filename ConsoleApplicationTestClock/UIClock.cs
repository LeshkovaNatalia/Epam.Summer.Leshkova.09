using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLogicClock;

namespace ConsoleApplicationUIClock
{
    class UIClock
    {
        static void Main(string[] args)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            EnterData(out hours, out minutes, out seconds);
            
            TimerClock clock = new TimerClock(hours, minutes, seconds);

            FirstListenerClock firstListener = new FirstListenerClock();
            firstListener.Register(clock);

            SecondListenerClock secondListener = new SecondListenerClock();
            secondListener.Register(clock);

            Console.WriteLine(Environment.NewLine + "***** Timer Start for two listeners. *****" + Environment.NewLine);
            
            clock.StartClock();

            EnterData(out hours, out minutes, out seconds);

            clock.Hours = hours;
            clock.Minutes = minutes;
            clock.Seconds = seconds;

            firstListener.Unregister(clock);

            Console.WriteLine(Environment.NewLine + "***** Timer Start for one listener. *****" + Environment.NewLine);
            clock.StartClock();

            Console.ReadLine();
        }

        #region Private Method

        /// <summary>
        /// Method EnterData used for input user's values
        /// </summary>
        private static void EnterData(out int hours, out int minutes, out int seconds)
        {
            Console.Write("***  Enter hours > 0 & < 60: ");
            CheckInputData(out hours);

            Console.Write("***  Enter minutes > 0 & < 60: ");
            CheckInputData(out minutes);

            Console.Write("***  Enter seconds: > 0 & < 60: ");
            CheckInputData(out seconds);
        }

        /// <summary>
        /// Method CheckInputData used to validate user input
        /// </summary>
        private static void CheckInputData(out int data)
        {
            bool isParsed = Int32.TryParse(Console.ReadLine(), out data);
            if (!isParsed)
                Console.WriteLine("--- You enter not a number! ---");
            if (data < 0 || data > 60)
            {
                Console.WriteLine("--- You enter not correct data! ---");
                data = 0;
            }
        }

        #endregion
    }
}
