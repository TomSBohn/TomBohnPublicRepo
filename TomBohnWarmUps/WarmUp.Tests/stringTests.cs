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
    public class StringTests
#region
    {
        [TestCase("Jeff", "Hello Jeff!")]
        public void TestSayHello(string name, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.SayHi(name);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hi" ,"Bye", "HiByeByeHi")]
        [TestCase("Hey" , "You", "HeyYouYouHey")]
        public void TestABBA(string a, string b, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.Abba(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        public void TestMakeTags(string tag, string content, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.MakeTags(tag, content);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("<<>>", "Yay", "<<Yay>>")]
        [TestCase("[[]]", "word", "[[word]]")]
        [TestCase("//88", "Yep", "//Yep88")]
        public void TestInsertWord(string container, string word, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.InsertWord(container, word);

            Assert.AreEqual(expected, testValue);
        }


        [TestCase("Hello", "lololo")]
        [TestCase("Hi", "HiHiHi")]
        [TestCase("pizza", "zazaza")]
        public void TestMultipleEndings(string str, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.MultipleEndings(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("HipHop", "Hip")]
        public void TestFirstHalf(string str, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.FirstHalf(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        [TestCase("av", "")]
        public void TestTrimOne(string mid, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.TrimOne(mid);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        [TestCase("", "pappies", "pappies")]
        public void TestLongInMiddle(string a, string b, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.LongInMiddle(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void TestRotateleft2(string str, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.Rotateleft2(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void TestRotateRight2(string str, string expected)
        {
            StringWarmups obj =  new StringWarmups();
            string testValue = obj.RotateRight2(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TestTakeOne(string str, bool fromFront, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.TakeOne(str, fromFront);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void TestMiddleTwo(string str, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.MiddleTwo(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void TestEndsWithLy(string str, bool expected)
        {
            StringWarmups obj = new StringWarmups();
            bool testValue = obj.EndsWithLy(str);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void TestFrontAndBack(string str, int n, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string testValue = obj.FrontAndBack(str, n);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TestTakeTwoFromPosition(string str, int n, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string TestValue = obj.TakeTwoFromPosition(str, n);

            Assert.AreEqual(expected, TestValue);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void TestHasBad(string str, bool expected)
        {
            StringWarmups obj = new StringWarmups();
            bool TestValue = obj.HasBad(str);

            Assert.AreEqual(expected, TestValue);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        [TestCase("", "@@")]
        public void TestAtFirst(string str, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string TestValue = obj.AtFirst(str);

            Assert.AreEqual(expected, TestValue);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void TestLastChars(string a, string b, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string TestValue = obj.LastChars(a, b);

            Assert.AreEqual(expected, TestValue);
            
        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        public void TestConCat(string a, string b, string expected)
        {
            StringWarmups obj = new StringWarmups();
            string TestValue = obj.ConCat(a, b);

            Assert.AreEqual(expected, TestValue);
        }








    }
    #endregion
    #region

    #endregion
}
