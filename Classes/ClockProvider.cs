﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public abstract class ClockProvider
    {
        public abstract string ClockByLiterally(string input);
    }
}
