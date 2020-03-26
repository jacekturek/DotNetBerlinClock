using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            DateTime hoursAndMins = Convert.ToDateTime(aTime);

            int hours = hoursAndMins.Hour;
            int mins = hoursAndMins.Minute;
            int secs = hoursAndMins.Second;

            string hours_rows = tell_hours_2_rows(hours);
            string minutes_rows = tell_minutes_2_rows(mins);
            // every 2 secs = Y
            string second_indicator = ((secs % 2 == 0) ? "Y" : "O");

            return
                second_indicator + "\n" +
                hours_rows + "\n" + minutes_rows;
        }

        // functions producing rows:
        static string tell_hours_2_rows(int hour)
        {
            string first_row = string.Empty;
            string second_row = string.Empty;

            // e.g. 15 = 3 * 5 = RRRO
            for (int i = 0; i < hour / 5; i++)
                first_row += 'R';
            for (int i = hour / 5; i < 4; i++)
                first_row += 'O';

            // e.g. 2 = 2 * 1 = RROO
            for (int i = 0; i < hour % 5; i++)
                second_row += 'R';
            for (int i = hour % 5; i < 4; i++)
                second_row += 'O';

            return first_row + "\n" + second_row;
        }
        static string tell_minutes_2_rows(int minute)
        {
            string first_row = string.Empty;
            string second_row = string.Empty;

            // e.g. 25 = 5 * 5 = RRYRROOOOOO
            for (int i = 0; i < minute / 5; i++)
            {
                if (i % 3 == 2) { first_row += 'R'; }
                else { first_row += 'Y'; }
            }
            for (int i = minute / 5; i < 11; i++)
                first_row += 'O';

            //e.g 3 = 3 * 1 = YYYO
            for (int i = 0; i < minute % 5; i++)
                second_row += 'Y';
            for (int i = minute % 5; i < 4; i++)
                second_row += 'O';

            return first_row + "\n" + second_row;
        }
    }
}
