using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class ClockConverter
    {
        public ClockProvider _provider;
        public ClockConverter(ClockProvider clockProvider)
        {
            _provider = clockProvider;
        }
        public string ClockByLiterally(string time)
        {
            return _provider.ClockByLiterally(time);
        }
    }
}
