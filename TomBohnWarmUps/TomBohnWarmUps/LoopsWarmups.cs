using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TomBohnWarmUps
{
    public class LoopsWarmups
    {

        public string StringTimes(string str, int n)
        {
            string newS = str;
            for (int i = 1; i<n; i++)
            {
                newS += str;
            }
            return newS;
        }

        public string FrontTimes(string str, int n)
        {
            string timesS = "";
            for (int i = 0; i < n; i++)
            {
                if (str.Length < 3)
                {
                    return "S";
                }
                timesS += str.Substring(0,3);
            }
            return timesS;
        }

        public int CountXX(string str)
        {
            int xHowMany = 0;
            for (int i = 0; i < str.Length -1; i++)
            {
                if (str.Substring(i, 2) == "xx")
                  xHowMany += 1;
            }
            return xHowMany;
        }

        public bool DoubleX(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) != "x")
                {
                    return false;
                }
                if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) == "x")
                {
                    return true;
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string response = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i <= str.Length)
                {
                    response += str.Substring(i++, 1);
                }
            }
            return response;
        }
        //Worked but had 4 if statements counting up from returning 1 char
        public string StringSplosion(string str)
        {
            string sploded = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i < str.Length)
                {
                    sploded += str.Substring(0, i+1);
                }
            }
            return sploded;
        }

        public int CountLast2(string str)
        {
            int last2 = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(str.Length - 2, 2) == str.Substring(i, 2))
                {
                    last2 ++;
                }
                if (i == str.Length -3)
                {
                    return last2;
                }
            }
            return last2;
        }

        public int Count9(int[] numbers)
        {
            int found9 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    found9 ++;
                }               
            }
            return found9;
        }

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length -1; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int ssMatches = 0;
            for (int i = 0; i < a.Length -1 && i < b.Length -1; i++)
            {
                if (a[i] == b[i] && a[i + 1] == b[i + 1])
                {
                    ssMatches++;
                }

            }
            return ssMatches;
        }

        public string StringX(string str)
        {
            string minusX = "";
            for (int i = 0; i < str.Length; i++)
            {
                if 
                {
                    str.Replace("x", "");
                }
                return minusX;
            }
            return minusX;
        }
    }
}
