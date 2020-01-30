using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockValidator : IClockValidator
    {
        public bool isValid(string time)
        {
            string berlinClockPattern = "^(?:[01]?[0-9]|2[0-4]):[0-5][0-9]:[0-5][0-9]$";
            Regex r = new Regex(berlinClockPattern);
            if (r.IsMatch(time))
                return true;
            else
                return false;
        }
    }
}
