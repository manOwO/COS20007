using System;
//using ClockClass;
using CounterTask;

namespace ClockClass
{
	public class Clock
	{
		private Counter _hours;
		private Counter _minutes;
		private Counter _seconds;

        public Clock()
		{
			_hours = new Counter("hours");
			_minutes = new Counter("minutes");
			_seconds = new Counter("seconds");
		}

		public void Tick()
		{
			if (_seconds.Ticks < 59)
			{
				_seconds.Increment();
			}
			else
			{
                if (_minutes.Ticks < 59)
                {
					_minutes.Increment();
					_seconds.Reset();
                }
				else
				{
                    if (_hours.Ticks < 23)
                    {
						_hours.Increment();
						_minutes.Reset();
						_seconds.Reset();
                    }
					else
					{
						Reset();
					}
                }
            }
		}

		public string DisplayTime()
		{
			//string _printHour;
			//string _printMinute;
			//string _printSecond;

			
			//if (_hours.Ticks < 10)
   //         {
   //             _printHour = new string("0" + _hours.Ticks.ToString());
   //         }
   //         else
   //         {
   //             _printHour = new string(_hours.Ticks.ToString());
   //         }

   //         if (_minutes.Ticks < 10)
   //         {
   //             _printMinute = new string("0" + _minutes.Ticks.ToString());
   //         }
   //         else
   //         {
   //             _printMinute = new string(_minutes.Ticks.ToString());
   //         }

   //         if (_seconds.Ticks < 10)
   //         {
   //             _printSecond = new string ("0" + _seconds.Ticks.ToString());
   //         }
   //         else
   //         {
   //             _printSecond = new string (_seconds.Ticks.ToString());
   //         }

			string _timedisplayed;
			_timedisplayed = _hours.Ticks.ToString("D2") + ":" + _minutes.Ticks.ToString("D2") + ":" + _seconds.Ticks.ToString("D2");

            return _timedisplayed;
        }

		public void Reset()
		{
			_hours.Reset();
			_minutes.Reset();
			_seconds.Reset();
		}

		public string Time
		{
			get
			{
				string _timeDisplayed = DisplayTime();
				return _timeDisplayed;
			}
		}
	}
}

