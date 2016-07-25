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
    class ArrayTests
    {
        [TestCase(new [] {1,2,6}, true)]
        [TestCase(new [] {6,1,2,3}, true)]
        [TestCase(new [] {13,6,1,2,3}, false)]

        public void TestFirstLast6(int[] numbers, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testValue = obj.FirstLast6(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 2, 3}, false)]
        [TestCase(new[] {1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 2, 1}, true)]
        public void TestSameFirstLast(int[] numbers, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testValue = obj.SameFirstLast(numbers);

            Assert.AreEqual(expected, testValue);
        }

        /*[TestCase(3, new[] {3, 1, 4})]
        public void TestMakePi(int n, Array expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            Array testValueArray = obj.MakePi (n);

            Assert.AreEqual(expected, testValueArray);
        }*/

        [TestCase(new[] {1,2,3}, new[] {7,3}, true)]
        [TestCase(new[] {1,2,3}, new[] {7,3,2}, false)]
        [TestCase(new[] {1,2,3}, new[] {1,3}, true)]
        public void TestcommonEnd(int [] a, int [] b, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testcommonEnd = obj.commonEnd(a, b);

            Assert.AreEqual(expected, testcommonEnd);
        }

        [TestCase(new[] {1, 2, 3}, 6)]
        [TestCase(new[] {5, 11, 2}, 18)]
        [TestCase(new[] {7, 0, 0}, 7)]
        public void TestSum(int[] numbers, int expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int testSum = obj.Sum(numbers);
            
            Assert.AreEqual(expected, testSum);
        }

        [TestCase(new[] {1, 2, 3}, new[] {2, 3, 1})]
        [TestCase(new[] {5, 11, 9}, new[] {11, 9, 5})]
        [TestCase(new[] {7, 0, 0}, new[] {0, 0, 7})]
        public void TestRotateLeft(int[] numbers, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testRotateLeft = obj.RotateLeft(numbers);

            Assert.AreEqual(expected, testRotateLeft);
        }

        [TestCase(new[] {1, 2, 3}, new[] {3, 2, 1})]
        [TestCase(new[] { 5, 6, 7 }, new[] { 7, 6, 5 })]
        public void TestReverse(int[] numbers, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testReverse = obj.Reverse(numbers);

            Assert.AreEqual(expected, testReverse);
        }

        [TestCase(new[] {1, 2, 3}, new[] {3, 3, 3})]
        [TestCase(new[] {11, 5, 9}, new[] {11, 11, 11})]
        [TestCase(new[] {2, 11, 3}, new[] {3, 3, 3})]
        public void TestHigherWins(int[] numbers, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testHigherWins = obj.HigherWins(numbers);

            Assert.AreEqual(expected, testHigherWins);
        }

        [TestCase(new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {2, 5})]
        [TestCase(new[] {7, 7, 7}, new[] {3, 8, 0}, new[] {7, 8})]
        [TestCase(new[] {5, 2, 9}, new[] {1, 4, 5}, new[] {2, 4})]
        public void TestGetMiddle(int[] a, int[] b, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testGetMiddle = obj.GetMiddle(a, b);

            Assert.AreEqual(expected, testGetMiddle);
        }

        [TestCase(new[] {2, 5}, true)]
        [TestCase(new[] {4, 3}, true)]
        [TestCase(new[] {7, 5}, false)]
        public void TestHasEven(int[] numbers, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testHasEven = obj.HasEven(numbers);

            Assert.AreEqual(expected, testHasEven);
        }

        [TestCase(new[] {4, 5, 6}, new[] {0, 0, 0, 0, 0, 6})]
        [TestCase(new[] {1, 2}, new[] {0, 0, 0, 2})]
        [TestCase(new[] {3}, new[] {0, 3})]
        public void TestKeepLast(int[] numbers, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testKeepLast = obj.KeepLast(numbers);

            Assert.AreEqual(expected, testKeepLast);
        }

        [TestCase(new [] {2,2,3}, true)]
        [TestCase(new[] {3,4,5,3}, true)]
        [TestCase(new[] {2,3,2,2}, false)]
        public void TestDouble23(int[] numbers, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testDouble23 = obj.Double23(numbers);

            Assert.AreEqual(expected, testDouble23);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 0})]
        [TestCase(new[] {2, 3, 5}, new[] {2, 0, 5})]
        [TestCase(new[] {1, 2, 1}, new[] {1, 2, 1})]
        public void TestFix23(int[] numbers, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testFix23 = obj.Fix23(numbers);

            Assert.AreEqual(expected, testFix23);
        }

        [TestCase(new[] {1, 3, 4, 5}, true)]
        [TestCase(new[] {2, 1, 3, 4, 5}, true)]
        [TestCase(new[] {1, 1, 1}, false)]
        public void TestUnlucky1(int[] numbers, bool expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            bool testUnlucky1 = obj.Unlucky1(numbers);

            Assert.AreEqual(expected, testUnlucky1);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {4, 5})]
        [TestCase(new[] {4}, new[] {1, 2, 3}, new[] {4, 1})]
        [TestCase(new int[] {}, new[] {1, 2}, new[] {1, 2})]
        public void Testmake2(int[] a, int[] b, int[] expected)
        {
            ArrayWarmups obj = new ArrayWarmups();
            int[] testmake2 = obj.make2(a, b);

            Assert.AreEqual(expected, testmake2);
        }

    }
}
