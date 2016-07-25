using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TomBohnWarmUps;

namespace WarmUp.Tests
{
    [TestFixture]
    public class LogicTests
    {

        [TestCase(30, false, false)]
        [TestCase(50, false, true)]
        [TestCase(70, true, true)]
        public void TestGreatParty(int cigars, bool isWeekend, bool expected)
        {
            LogicWarmups obj = new LogicWarmups();
            bool testValue = obj.GreatParty(cigars, isWeekend);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(5, 10, 2)]
        [TestCase(5, 2, 0)]
        [TestCase(5, 5, 1)]
        public void TestCanHazTable(int yourStyle, int dateStyle, int expected)
        {
            LogicWarmups obj = new LogicWarmups();
            int testValue = obj.CanHazTable(yourStyle, dateStyle);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(70, false, true)]
        [TestCase(95, false, false)]
        [TestCase(95, true, true)]
        public void TestPlayOutside(int temp, bool isSummer, bool expected)
        {
            LogicWarmups obj = new LogicWarmups();
            bool testValue = obj.PlayOutside(temp, isSummer);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(60, false, 0)]
        [TestCase(65, false, 1)]
        [TestCase(65, true, 0)]
        public void TestCaughtSpeeding(int speed, bool isBirthday, int expected)
        {
            LogicWarmups obj = new LogicWarmups();
            int testValue = obj.CaughtSpeeding(speed, isBirthday);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(3, 4, 7)]
        [TestCase(9, 4, 20)]
        [TestCase(10, 11, 21)]
        public void TestSkipSum(int a, int b, int expected)
        {
            LogicWarmups obj = new LogicWarmups();
            int testValue = obj.SkipSum(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(1, false, "7:00")]
        [TestCase(5, false, "7:00")]
        [TestCase(0, false, "10:00")]
        [TestCase(0, true, "off")]
        public void TestAlarmClock(int day, bool vacation, string expected)
        {
            LogicWarmups obj = new LogicWarmups();
            string testValue = obj.AlarmClock(day, vacation);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(6, 4, true)]
        [TestCase(4, 5, false)]
        [TestCase(1, 5, true)]
        public void TestLoveSix(int a, int b, bool expected)
        {
            LogicWarmups obj = new LogicWarmups();
            bool testValue = obj.LoveSix(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(5, false, true)]
        [TestCase(11, false, false)]
        [TestCase(11, true, true)]
        public void TestInRange(int n, bool outsideMode, bool expected)
        {
            LogicWarmups obj = new LogicWarmups();
            bool testValue = obj.InRange(n, outsideMode);

            Assert.AreEqual(expected, testValue);
        }



    }
}
