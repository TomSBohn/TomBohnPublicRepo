using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TomBohnWarmUps;

namespace WarmUpTests.Tests
{
    //String tests
    #region
    [TestFixture]
    public class StringTests
    {
        [TestCase("Jeff", "Hello Jeff!")]
        [TestCase("Annie", "Hello Annie!")]
        [TestCase("123!@#", "Hello 123!@#!")]
        public void TestSayHello(string name, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.SayHi(name);

            Assert.AreEqual(expected, testValue);

        }
    }
    #endregion
}
