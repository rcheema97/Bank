using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entities
{
    class CountDown
    {
        //Contract for subscribers
        public delegate void CountDownCompletedHandler(object source, EventArgs args);

        //event
        public event CountDownCompletedHandler CountDownCompleted;

        public void StartCountDown()
        {
            try
            {
                //sleep this process for 1 mins
                Thread.Sleep(60000);

                onCountDownCompleted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        protected virtual void onCountDownCompleted()
        {
            try
            {

                if (CountDownCompleted != null)
                {
                    CountDownCompleted(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

    }
}
