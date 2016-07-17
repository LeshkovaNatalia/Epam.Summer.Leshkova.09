using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogicClock
{
    public sealed class TimerEventArgs : EventArgs
    {
        #region Fields

        private string _spendTime;
        
        #endregion

        #region Properties

        public string SpendTime
        {
            get { return _spendTime; }
            set
            {
                if (value != null)
                    _spendTime = value;
                else
                {
                    throw new ArgumentException(nameof(_spendTime));
                }
            }
        }

        #endregion

        #region Ctor

        public TimerEventArgs(string spendTime)
        {
            _spendTime = spendTime;
        }

        #endregion
    }
}
