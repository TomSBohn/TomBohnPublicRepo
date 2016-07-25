using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomBohnWarmUps
{
    public class ArrayWarmups
    {
        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            return false;
        }


        public bool SameFirstLast(int[] numbers)
        {
            if (numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            return false;
        }

        //public int[] MakePi(int n)


        public bool commonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            return false;
        }

        public int Sum(int[] numbers)
        {
            //This was close, but I was doubling up.
            int total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return total;

            //return numbers.Sum();
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] lefty = new int[3];
            /*for (int i = 0; i < numbers.Length-1; i++)
            {
                lefty.SetValue(numbers[i+1], i);
            }*/
            lefty.SetValue(numbers[1], 0);
            lefty.SetValue(numbers[2], 1);
            lefty.SetValue(numbers[0], 2);
            return lefty;
        }


        //Sometimes an entire exercise is just one function.
        // hit the "." and see what happens.
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;
        }

        public int[] HigherWins(int[] numbers)
        {
            int[] Highest = new int[numbers.Length];
            if (numbers[0] > numbers[numbers.Length-1])
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Highest.SetValue(numbers[0], i);
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    Highest.SetValue(numbers[numbers.Length-1], i);
                }
            }
            return Highest;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int [] middle = new int[2];
            middle.SetValue(a[1], 0);
            middle.SetValue(b[1], 1);
            return middle;
        }

        public bool HasEven(int[] numbers)
        {
            if (numbers[0] % 2 == 0 || numbers[1] % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public int[] KeepLast(int[] numbers)
        {
            int [] last = new int[numbers.Length * 2];
            last.SetValue(numbers[numbers.Length-1], last.Length-1);
            return last;
        }

        public bool Double23(int[] numbers)
        {
            int twoTimes = 0;
            int threeTimes = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    twoTimes ++;
                }
                else if (numbers[i] == 3)
                {
                    threeTimes ++;
                }
            }
            if (twoTimes == 2 || threeTimes == 2)
            {
                return true;
            }
            return false;
        }

        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    numbers.SetValue(0, i + 1);
                    return numbers;
                }
                i++;
            }
            return numbers;

        }

        public bool Unlucky1(int[] numbers)
        {
            if ((numbers[0] == 1 && numbers[1] == 3) ||
                (numbers[1] ==1 && numbers[2] == 3))
            {
                return true;
            }
            else if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length - 1] == 3)
            {
                return true;
            }
            return false;
        }

        public int[] make2(int[] a, int[] b)
        {
            int[] makeTwo = new int[2];
            if (a.Length == 0)
            {
                makeTwo[0] = b[0];
                makeTwo[1] = b[1];
                return makeTwo;
            }
            if (a.Length >= 2)
            {
                makeTwo[0] = a[0];
                makeTwo[1] = a[1];
                return makeTwo;
            }
            if (a.Length < 2)
            {
                makeTwo[0] = a[0];
                makeTwo[1] = b[0];
                return makeTwo;
            }
            return makeTwo;
            

        }
    }
}

