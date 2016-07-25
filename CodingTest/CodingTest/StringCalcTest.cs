using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingTest
{
    [TestFixture]
    public class StringCalcTest
    {
        [TestCase("",0)]
        public void ShouldReturnZeroWHenInputIsEmpty(string input, int expected)
        {
            StringCalc target = new StringCalc();
            int actual = target.Add(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("10,10,5", 25)]
        [TestCase("20,20,10,9000", 9050)]
        [TestCase("10,10", 20)]
        [TestCase("10", 10)]
        public void ShouldReturnSumWhenInputIsNumbersDelimited(string input, int expected)
        {
            StringCalc target = new StringCalc();
            int actual = target.Add(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("10\n10,5", 25)]
        [TestCase("20\n20,10,9000", 9050)]
        [TestCase("10\n10,10", 30)]
        [TestCase("1\n10", 11)]
        public void ShouldAllowANewLine(string input, int expected)
        {
            StringCalc target = new StringCalc();
            int actual = target.Add(input);
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;\n10\n10;5", 25)]
        [TestCase("//!\n20\n20!10!9000", 9050)]
        [TestCase("//#\n10\n10#10", 30)]
        [TestCase("//@\n1\n10", 11)]
        public void ShouldAllowNewDelimtersKeepNewLinesReturnSum(string input, int expected)
        {
            StringCalc target = new StringCalc();
            int actual = target.Add(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
