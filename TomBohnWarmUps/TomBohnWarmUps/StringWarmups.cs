using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TomBohnWarmUps
{
    public class StringWarmups
    {
        //Strings

        public string SayHi(string name)
        {
            return $"Hello {name}!" ;
        }

        public string Abba(string a, string b)
        {
            return $"{a}{b}{b}{a}";
           
        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word)
        {
            string beginning = container.Substring(0, 2);
            string ending = container.Substring(2, 2);
            return $"{beginning}{word}{ending}";
        }

        //Fun with SubStrings!

        public string MultipleEndings(string str)
        {
            string end = str.Substring(str.Length - 2, 2);
            return $"{end}{end}{end}";
        }

        public string FirstHalf(string str)
        {
            string start = str.Substring(0, str.Length / 2);
            return start;
        }
        

        public string TrimOne(string str)
        {
            if (str.Length >= 2)
            {
                string mid = str.Substring(1, str.Length - 2);
                return mid;
                
            }
            else
            {
                return string.Empty; 
            }
            
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length >= b.Length)
            {
                return $"{b}{a}{b}";
            }
            return $"{a}{b}{a}";
        }

        public string Rotateleft2(string str)
        {
            string left = str.Substring(0, 2);
            return str.Substring(2, str.Length - 2) + left;
        }

        public string RotateRight2(string str)
        {
            string right = str.Substring(str.Length - 2, 2);
            return right + str.Substring(0, str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            return str.Substring(str.Length - 1, 1);
        }

        public string MiddleTwo(string str)
        {
            if (str.Length%2 == 0)
            {
                return str.Substring(str.Length/2 - 1, 2);
            }
            else
            {
                return "It's not even.";
            }
            
        }

        public bool EndsWithLy(string str)
        {
           if (str.Length < 2) 
            {
                 return false;
            }
        if (str.Substring((str.Length - 2), 2) == "ly")
        {
            return true;
        }
        else
        {
            return false;
        }
        }

        public string FrontAndBack(string str, int n)
        {
            if (str.Length >= n)
            {
                return str.Substring(0, n) + str.Substring(str.Length - n, n);
            }
            else
            {
                return str;
            }

        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n <= str.Length - 2)
            {
                return str.Substring(n, 2);
            }
            else
            {
                return str.Substring(0, 2);
            }
        }

        public bool HasBad(string str)
        {
            if (str.Substring(0, 2) == "ba" || str.Substring(1,2) == "ba")
            {
                return true;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length == 1)
            {
                return str + "@";
            }
            if (str.Length == 0)
            {
                return "@@";
            }
            return str.Substring(0, 2);
        }

        public string LastChars(string a, string b)
        {
            if (a.Length == 0)
            {
                return "@" + b.Substring(b.Length -1, 1);
            }
            if (b.Length == 0)
            {
                return a.Substring(0,1) + "@";
            }
            else
            {
                return a.Substring(0, 1) + b.Substring(b.Length - 1, 1);
            }
        }

        public string ConCat(string a, string b)
        {
            if (a == string.Empty || b == string.Empty)
            {
                return a + b;
            }
            if (a.Substring(a.Length -1, 1) == b.Substring(0, 1))
            {
                return a.Substring(0, a.Length - 1) + b.Substring(0, b.Length);
            }
            return a + b;
        }


    }
}

