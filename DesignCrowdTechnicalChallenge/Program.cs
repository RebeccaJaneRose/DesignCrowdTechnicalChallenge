using System;
using System.Collections.Generic;

namespace DesignCrowdTechnicalChallenge
{
    class Program {

        static void Main(string[] args) {
            var businessDayCounter = new BusinessDayCounter();

            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2014, 01, 01);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Console.WriteLine(result);
        }
    }
}
