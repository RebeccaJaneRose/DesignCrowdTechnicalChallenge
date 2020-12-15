using System;

namespace DesignCrowdTechnicalChallenge.Public_Holiday.Rules {
    public class IsObservedPublicHolidayRule : IPublicHolidayRule
    {
        private readonly DateTime _publicHoliday;
        private readonly bool _observed;

        public IsObservedPublicHolidayRule(DateTime publicHoliday, bool observed) {
            _publicHoliday = publicHoliday;
            _observed = observed;
        }

        public bool IsDatePublicHoliday(DateTime date) {
            
            if (date == _publicHoliday && !_observed) return true;

            var daysUntilMonday = ((int)DayOfWeek.Monday - (int)_publicHoliday.DayOfWeek + 7) % 7;
            return (_publicHoliday.AddDays(daysUntilMonday) == date);
        }
    }
}
