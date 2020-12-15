using System;
using DesignCrowdTechnicalChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignCrowdTechnicalChallengeTests {

    [TestClass]
    public class BusinessDayCounterTests {
        #region 'WeekdaysBewteenTwoDates Tests'

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenDatesAreTheSame_ThenReturnZero() {
            var businessDayCounter = new BusinessDayCounter();
            var date = new DateTime(2020, 12, 11);
            var expectedResult = 0;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(date, date);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenSecondDateIsSmallerThenFirstDate_ThenReturnZero() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2013, 10, 05);
            var expectedResult = 0;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenSecondDateIsOneDayMoreThenFirstDate_ThenReturnZero() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2020, 12, 10);
            var secondDate = new DateTime(2020, 12, 11);
            var expectedResult = 0;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenSecondDateIsTwoDaysMoreThenFirstDate_ThenReturnOne() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2013, 10, 09);
            var expectedResult = 1;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenDatesAreAWeekApart_ThenReturnFive() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 05);
            var secondDate = new DateTime(2013, 10, 14);
            var expectedResult = 5;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenDatesAreThreeMonthsApart_ThenReturn61() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2014, 01, 01);
            var expectedResult = 61;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhereDatesHaveTime_ThenReturnFive() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 05, 12,59,30);
            var secondDate = new DateTime(2013, 10, 14, 10, 30, 30);
            var expectedResult = 5;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenTheYearIsALeapYear_ThenReturn262() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2019, 12, 31);
            var secondDate = new DateTime(2021, 01, 01);
            var expectedResult = 262;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeekdaysBetweenTwoDates_WhenTheYearIsNotALeapYear_ThenReturn261() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2018, 12, 31);
            var secondDate = new DateTime(2020, 01, 01);
            var expectedResult = 261;

            var result = businessDayCounter.WeekdaysBetweenTwoDates(firstDate, secondDate);

            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region 'BusinessDaysBetweenTwoDates Test'

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenSecondDateIsTwoDaysMoreThenFirstDate_ThenReturnOne() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2013, 10, 09);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 1;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenDatesIncludeChristmas_ThenReturnZero() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 12, 24);
            var secondDate = new DateTime(2013, 12, 27);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 0;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenDatesIncludeChristmas_ThenReturn59() {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2013, 10, 07);
            var secondDate = new DateTime(2014, 01, 01);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 59;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenUsingRuleForNewYear_ThenReturnOne()
        {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2022, 01, 01);
            var secondDate = new DateTime(2022, 01, 05);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 1;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenRuleForChristmasBoxingDayAndNewYears_ThenReturnFour()
        {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2020, 12, 23);
            var secondDate = new DateTime(2021, 01, 02);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 4;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void BusinessDaysBetweenTwoDates_WhenRuleQueensBirthday_ThenReturnOne()
        {
            var businessDayCounter = new BusinessDayCounter();
            var firstDate = new DateTime(2020, 06, 07);
            var secondDate = new DateTime(2020, 06, 10);

            IList<DateTime> publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2013, 12, 25));
            publicHolidays.Add(new DateTime(2013, 12, 26));
            publicHolidays.Add(new DateTime(2014, 01, 01));

            var expectedResult = 1;

            var result = businessDayCounter.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            Assert.AreEqual(expectedResult, result);
        }
        #endregion
    }
}
