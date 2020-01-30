using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    interface IClockValidator
    {
        bool isValid(string time);
    }
}
