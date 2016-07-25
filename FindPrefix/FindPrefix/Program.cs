using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindPrefix
{
    class Solution
    {
        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            int q = 0; // total number of queries
            int n = 0; //number of strings in the query list, will be a console.readline
            int prefix = 0; // length of prefix char matches
            int position = 0; // location in string
            int nextQuery = 1; // query in list


            q = int.Parse(Console.ReadLine());
            if (q >= 1 && q <= 10)
            {
                List<List<string>> allQueries = new List<List<string>>();

                while (allQueries.Count < q)
                {
                    n = int.Parse(Console.ReadLine());
                    if (n >= 1 && n <= Math.Pow(10, 5))
                    {
                        List<string> queries = new List<string>();
                        for (int i = 0; i < n; i++)
                        {
                            string data = Console.ReadLine();
                            if (data.Length >= 1 && data.Length <= 15)
                            {
                                queries.Add(data);
                            }
                        }
                        allQueries.Add(queries);
                    }
                    else
                    {
                        break;
                    }
                }


                List<int> prefixes = new List<int>();
                List<int> maxPrefixes = new List<int>();

                // search list of queries looking for common starting chars

                foreach (var list in allQueries)
                {
                    foreach (var query in list)
                    {
                        for (int j = 0; j < list.Count;)
                        {
                            if (nextQuery != j)
                            {
                                if (nextQuery < n &&
                                    (position < list[j].Length && position < list[nextQuery].Length))
                                {
                                    if ((list[j].Substring(position, 1) == list[nextQuery].Substring(position, 1)))
                                    {
                                        prefix++;
                                        position++;
                                    }
                                    else
                                    {
                                        nextQuery++;
                                        position = 0;
                                        prefixes.Add(prefix);
                                        prefix = 0;
                                    }
                                }
                                else
                                {
                                    j++;
                                    nextQuery = 0;
                                }
                            }
                            else
                            {
                                nextQuery++;
                            }
                        }
                    }

                    maxPrefixes.Add(prefixes.Max());
                    prefixes.Clear();
                }

                for (int i = 0; i < maxPrefixes.Count; i++)
                {
                    Console.WriteLine(maxPrefixes[i]);

                }

            }
        
        }
    }
}
