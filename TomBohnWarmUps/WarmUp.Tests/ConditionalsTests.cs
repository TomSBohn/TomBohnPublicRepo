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
    public class ConditionalsTests
    {
            [TestCase(true, true, true)]
            [TestCase(false, false, true)]
            [TestCase(true, false, false)]
            public void TestAreWeInTrouble(bool aSmile, bool bSmile, bool expected)
            {
                ConditionalWarmups obj = new ConditionalWarmups();
                bool testValue = obj.AreWeInTrouble(aSmile, bSmile);

                Assert.AreEqual(expected, testValue);
            }

        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        [TestCase(false, true, true)]
        public void TestCanSleepIn(bool isWeekday, bool isVacation, bool expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            bool testValue = obj.CanSleepIn(isWeekday, isVacation);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(1, 2, 3)]
        [TestCase(3, 2, 5)]
        [TestCase(2, 2, 8)]
        public void TestSumDouble(int a, int b, int expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            int testValue = obj.SumDouble(a, b);
            
            Assert.AreEqual(expected, testValue);
        }

        [TestCase(23, 4)]
        [TestCase(10, 11)]
        [TestCase(21, 0)]
        public void TestDiff21(int n, int expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            int testValue = obj.Diff21(n);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]
        public void TestParrotTrouble(bool isTalking, int hour, bool expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            bool testValue = obj.ParrotTrouble(isTalking, hour);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(9, 10, true)]
        [TestCase(9, 9, false)]
        [TestCase(1, 9, true)]
        [TestCase(2, 3, false)]
        public void TestMakes10(int a, int b, bool expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            bool testValue = obj.Makes10(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("cat", "tcatt")]
        [TestCase("Hello", "oHelloo")]
        [TestCase("a", "aaa")]
        public void TestBackAround(string str, string expected)
        {
            ConditionalWarmups obj = new ConditionalWarmups();
            string testValue = obj.BackAround(str);

            Assert.AreEqual(expected, testValue);
        }

       
    }
}

