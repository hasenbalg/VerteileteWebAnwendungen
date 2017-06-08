using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VWW_Project.Models
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DayOfWeek WeekDay { get; set; }

        public Date[][] getAllDatesOfYear(int y)
        {
            Date[][] dates = new Date[12][];
            for (int c = 0; c < 12; c++)
            {
                dates[c] = new Date[DateTime.DaysInMonth(y, c +1)];
                for (int i = 0; i < dates[c].Length; i++)
                {
                    Date d = new Date();
                    d.Day = i + 1;
                    d.Month = c + 1;
                    d.Year = y;
                    d.WeekDay = new DateTime(y, c + 1, i + 1).DayOfWeek;
                    dates[c][i] = d;
                }
            }
            return dates;
        }
    }

   
}