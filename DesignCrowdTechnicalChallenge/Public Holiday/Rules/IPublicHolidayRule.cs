using System;

namespace DesignCrowdTechnicalChallenge.Public_Holiday.Rules
{
    public interface IPublicHolidayRule {
        bool IsDatePublicHoliday(DateTime dateTime);
    }
}
