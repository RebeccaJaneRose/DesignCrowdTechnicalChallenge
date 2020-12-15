using System;

namespace DesignCrowdTechnicalChallenge.Public_Holiday.Rules {
    public class FixedDayPublicHolidayRule : IPublicHolidayRule {

        private readonly int _month;
        private readonly DayOfWeek _dayOfWeek;
        private readonly int _weekOfMonth;


        public FixedDayPublicHolidayRule(int month, DayOfWeek dayOfWeek, int weekOfMonth ) {
            _month = month;
            _dayOfWeek = dayOfWeek;
            _weekOfMonth = weekOfMonth;
        }

        public bool IsDatePublicHoliday(DateTime date) {

            // Check if the date is for the right week day and month, so check if it's the right day number.
            if (date.DayOfWeek == _dayOfWeek && date.Month == _month) {

                return Math.Ceiling(date.Day / 7.0) == _weekOfMonth; // How many times has the day of the week been in the month. 
            }
            return false;
        }
    }
}
