using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibraryLogicClock
{
    public sealed class TimerClock
    {
        #region Fields

        private static int _hours;
        private static int _minutes;
        private static int _seconds;

        #endregion

        #region Properties

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value >= 0)
                    _hours = value;
                else throw new ArgumentException(nameof(Hours));
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value >= 0 || value < 60)
                    _minutes = value;
                else throw new ArgumentException(nameof(Minutes));
            }
        }

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value >= 0 || value < 60)
                    _seconds = value;
                else throw new ArgumentException(nameof(Seconds));
            }
        }

        #endregion

        #region Ctor

        public TimerClock() {}

        public TimerClock(int hours, int minutes, int seconds)
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Member of certain events.
        /// </summary>
        public event EventHandler<TimerEventArgs> Timer = delegate { };

        /// <summary>
        /// Method OnTimer is responsible for notifying the registered objects 
        /// about the event
        /// </summary>
        /// <param name="e">Stores information that is sent receivers of event notice.</param>
        private void OnTimer(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> temp = Timer;

            if (temp != null)
                temp(this, e);
        }

        /// <summary>
        /// Method StartClock broadcasting the input information to the desired event.
        /// </summary>
        public void StartClock()
        {
            int timeInMilliSeconds = GetTotalMilliSeconds(this.Hours, this.Minutes, this.Seconds);
            string formatTime = $"{this.Hours}:{this.Minutes}:{this.Seconds}";

            Thread.Sleep(timeInMilliSeconds);

            OnTimer(new TimerEventArgs(formatTime));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method GetTotalMilliSeconds get time in MilliSeconds.
        /// </summary>
        /// <param name="hour">Count of hours.</param>
        /// <param name="minutes">Count of minutes.</param>
        /// <param name="seconds">Count of seconds.</param>
        /// <returns>Return time in MilliSeconds.</returns>
        private static int GetTotalMilliSeconds(int hour, int minutes, int seconds)
        {
            TimeSpan timeSpan = new TimeSpan(hour, minutes, seconds);
            int result = (int)timeSpan.TotalMilliseconds;
            return result;
        }

        #endregion
    }
}
