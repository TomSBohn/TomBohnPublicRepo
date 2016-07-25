using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomBohnWarmUps
{
    public class ConditionalWarmups
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            //Brendan's hand motions while saying instructions || "Or.... ORRRRR!" *chopping gesture*
            if (isWeekday == false || isVacation == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SumDouble(int a, int b)
        {
            if(a == b)
            {
                return ((a + b) * 2);
            }
            else
            {
                return (a + b);
            }
        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                /*using Math.Abs to always return a positive number
                 looked up on MSDN with James and Tom A*/
                return Math.Abs(n - 21) * 2;
            }
            else
            {
                return Math.Abs(n - 21);
            }
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            // was wrong because = and not ==
            if (isTalking == true && hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Makes10(int a, int b)
        {
            if (a + b == 10)
            {
                return true;
            }
            if (a == 10 || b == 10)
            {
                return true;
            }
            return false;
        }

        public string BackAround(string str)
        {
            if (str.Length < 1)
            {
                return "Please enter a longer word.";
            }
            return str.Substring(str.Length - 1, 1) + str + str.Substring(str.Length - 1, 1);
        }
    }
}
