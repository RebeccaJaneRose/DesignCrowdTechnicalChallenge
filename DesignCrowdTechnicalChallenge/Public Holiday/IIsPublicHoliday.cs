using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdTechnicalChallenge.Public_Holiday
{
    public interface IIsPublicHoliday {      
        bool IsPublicHoliday(DateTime date);
    }
}
