using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace CodingTest
{
    public class StringCalc
    {
        private int sum = 0;

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            else
            {             // if input starts with // then the following char will be the new delimeter. It will replace the comma split.
                string possibleDelimeter = ",";
                if (input.StartsWith("//"))
                {
                    possibleDelimeter = input.Substring(2, 1);
                    input = input.Remove(0, 2);
                }

                string[] strings = input.Split( possibleDelimeter[0] , '\n' ) ;
                List<int> numbers = new List<int>();

                foreach (var s in strings)
                {
                    if (!string.IsNullOrEmpty(s)) numbers.Add(Convert.ToInt32(s));
                }

                return numbers.Sum();
            }
        }
    }
}