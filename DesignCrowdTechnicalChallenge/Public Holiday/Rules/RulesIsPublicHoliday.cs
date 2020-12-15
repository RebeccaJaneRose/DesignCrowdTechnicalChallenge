using System;
using System.Collections.Generic;

namespace DesignCrowdTechnicalChallenge.Public_Holiday.Rules {
    public class RulesIsPublicHoliday : IIsPublicHoliday {
        List<IPublicHolidayRule> _rules = new List<IPublicHolidayRule>();

        public RulesIsPublicHoliday() {
            var christmas = new DateTime(2020, 12, 25);
            var boxingDay = new DateTime(2020, 12, 26);
            var newYearsDay2021 = new DateTime(2021, 01, 01);
            var newYearsDay2022 = new DateTime(2022, 01, 01);

            _rules.Add(new FixedDayPublicHolidayRule(6, DayOfWeek.Monday, 2)); //Queens Birthday
            _rules.Add(new IsObservedPublicHolidayRule(christmas, false));
            _rules.Add(new IsObservedPublicHolidayRule(boxingDay, true));
            _rules.Add(new IsObservedPublicHolidayRule(newYearsDay2021, false));
            _rules.Add(new IsObservedPublicHolidayRule(newYearsDay2022, true));
        }

        public bool IsPublicHoliday(DateTime date) {

            foreach (var rule in _rules) {
                if(rule.IsDatePublicHoliday(date)) return true;
            }
            return false;
        }
    }
}
