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
    public class LoopsTests
    {

        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        public void TestStringTimes(string str, int n, string expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            string testValue = obj.StringTimes(str, n);

            Assert.AreEqual(expected, testValue);

        }

        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("abc", 3, "abcabcabc")]
        public void TestFrontTimes(string str, int n, string expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            string testValue = obj.FrontTimes(str, n);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("xxxx", 3)]
        public void TestCountXX(string str, int expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            int testValue = obj.CountXX(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        public void TestDoubleX(string str, bool expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            bool testValue = obj.DoubleX(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void TestEveryOther(string str, string expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            string testValue = obj.EveryOther(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void TestStringSplosion(string str, string expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            string testValue = obj.StringSplosion(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx", 1)]
        [TestCase("axxxaaxx", 2)]
        public void TestCountLast2(string str, int expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            int testValue = obj.CountLast2(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new [] {1,2,9}, 1)]
        [TestCase(new [] {1,9,9}, 2)]
        [TestCase(new [] {1,9,9,3,9}, 3)]
        public void TestCount9(int[] numbers, int expected)
        {
          LoopsWarmups obj = new LoopsWarmups();
          int testValue = obj.Count9(numbers);
          
        Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 2, 9, 3, 4}, true)]
        [TestCase(new[] {1, 2, 3, 4, 9}, false)]
        [TestCase(new[] {1, 2, 3, 4, 5}, false)]
        public void TestArrayFront9(int[] numbers, bool expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            bool testValue = obj.ArrayFront9(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 1, 2, 4, 1}, false)]
        [TestCase(new[] {1, 1, 2, 1, 2, 3}, true)]
        public void TestArray123(int[] numbers, bool expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            bool testValue = obj.Array123(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("xxcaazz", "xxbaaz", 3)]
        [TestCase("abc", "abc", 2)]
        [TestCase("abc", "axc", 0)]
        public void TestSubStringMatch(string a, string b, int expected)
        {
            LoopsWarmups obj = new LoopsWarmups();
            int testValue = obj.SubStringMatch(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("xxHxix", "xHix")]
        [TestCase("abxxxcd", "abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void TestStringX(string str, string expected)
        {
            
        }

    }
}
