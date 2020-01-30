using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockConverter:ClockProvider
    {
        private IClockValidator _validator;
        public BerlinClockConverter()
        {
            _validator = new BerlinClockValidator();
            
        }
        public override string ClockByLiterally(string input)
        {
            if (!_validator.isValid(input))
                return "Wrong Berlin Clock Format";
            StringBuilder berlinClockLiterally = new StringBuilder();
            dynamic time = parseStringTime(input);
            int hourCount = 0;
            int minCount = 0;
            berlinClockLiterally.AppendLine(FindBlinkingLampValue(time));
            berlinClockLiterally.AppendLine(FindHoursFirstRow(time, out hourCount));
            berlinClockLiterally.AppendLine(FindHoursSecondRow(time, hourCount));
            berlinClockLiterally.AppendLine(FindMinutesFirstRow(time, out minCount));
            berlinClockLiterally.Append(FindMinutesSecondRow(time, minCount));
            return berlinClockLiterally.ToString();
        }
        private dynamic parseStringTime(string aTime)
        {
            dynamic time = new ExpandoObject();
            var list = aTime.Split(':').ToList();
            time.Hours = Convert.ToInt32(list[0]);
            time.Minutes = Convert.ToInt32(list[1]);
            time.Seconds = Convert.ToInt32(list[2]);

            return time;
        }
        private string FindBlinkingLampValue(dynamic ts)
        {
            return ts.Seconds % 2 == 0 ? "Y" : "O";
        }
        private string FindHoursFirstRow(dynamic ts, out int hourCount)
        {
            char[] firstRowHour = { 'O', 'O', 'O', 'O' };
            hourCount = ts.Hours / 5;
            for (int i = 0; i < hourCount; i++)
                firstRowHour[i] = 'R';

            return new string(firstRowHour);
        }
        private string FindHoursSecondRow(dynamic ts, int hourCount)
        {
            char[] secondRowHour = { 'O', 'O', 'O', 'O' };
            if (hourCount == 0)
                return new string(secondRowHour);
            int remaininghourCount = ts.Hours % (5 * hourCount);
            for (int i = 0; i < remaininghourCount; i++)
                secondRowHour[i] = 'R';

            return new string(secondRowHour);
        }
        private string FindMinutesFirstRow(dynamic ts, out int minCount)
        {
            char[] firstRowMin = { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O' };
            minCount = ts.Minutes / 5;
            if (minCount == 0)
                return new string(firstRowMin);
            for (int i = 0; i < minCount; i++)
            {
                if ((i + 1) % 3 == 0)
                    firstRowMin[i] = 'R';
                else
                    firstRowMin[i] = 'Y';
            }

            return new string(firstRowMin);
        }
        private string FindMinutesSecondRow(dynamic ts, int minCount)
        {
            char[] secondRowMin = { 'O', 'O', 'O', 'O' };
            if (minCount == 0)
                return new string(secondRowMin);
            int secCount = ts.Minutes % 5;
            for (int i = 0; i < secCount; i++)
                secondRowMin[i] = 'Y';

            return new string(secondRowMin);
        }
    }
}
