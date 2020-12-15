using System;
using System.Collections.Generic;
using DesignCrowdTechnicalChallenge.Public_Holiday.Rules;

namespace DesignCrowdTechnicalChallenge {

    /// <summary>
    ///  The methods in this class are used to give to calculate the number of days between two dates. One gives the number of weekdays between two dates and the other the number of business days.   
    /// </summary>
    public class BusinessDayCounter {

        /// <summary>
        /// The method is used to return the number of weekdays between two dates.
        /// </summary>
        /// <param name="firstDate">The date to start checking from.</param>
        /// <param name="secondDate">The date to finish checking.</param>
        /// <returns>Number of weekdays between two dates.</returns>
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate) {
            var businessDays = 0;

            if (secondDate < firstDate) return businessDays;
            
            //Don't count the start or end dates.
            firstDate = firstDate.AddDays(1);
            secondDate = secondDate.AddDays(-1);

            for (var date = firstDate; date <= secondDate; date = date.AddDays(1)) {
                //Only count weekdays.
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    businessDays++;
            }             
            return businessDays;
        }

        /// <summary>
        /// The method is used to return the number of business days between two dates, this take into account not counting weekends or public holidays.
        /// </summary>
        /// <param name="firstDate">The date to start checking from.</param>
        /// <param name="secondDate">The date to finish checking.</param>
        /// <param name="publicHolidays">List of public holidays as DateTime</param>
        /// <returns>Number of Business days bewteen two dates.</returns>
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays) {
            
            var businessDays = WeekdaysBetweenTwoDates(firstDate, secondDate);

            var rulesIsPublicHoliday = new RulesIsPublicHoliday();

            var publicHols = 0;

            //Don't count the start or end dates.
            firstDate = firstDate.AddDays(1);
            secondDate = secondDate.AddDays(-1);

            for (var date = firstDate; date <= secondDate; date = date.AddDays(1)) {
                //If the date exists in the list of public holidays increment counter.
                if (publicHolidays.Contains(date) || rulesIsPublicHoliday.IsPublicHoliday(date))
                    publicHols++;
            }
            return businessDays - publicHols;
        }
    }
}