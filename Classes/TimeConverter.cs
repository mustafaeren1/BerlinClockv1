using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var berlinClockConverter = new BerlinClockConverter();
            ClockConverter clockConverter = new ClockConverter(berlinClockConverter);
            return clockConverter.ClockByLiterally(aTime);            
        }
       
    }
}
