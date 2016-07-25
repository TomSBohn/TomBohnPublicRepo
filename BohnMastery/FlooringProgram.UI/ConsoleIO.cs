using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    class ConsoleIO
    {
        /// <summary>
        /// Displays a message to the user
        /// </summary>
        /// <param name="message">Input a message to the user</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayMessage(string message, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            DisplayMessage(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Used to get a string form the user
        /// </summary>
        /// <param name="message">Input message to display to the user</param>
        /// <returns></returns>
        public static string PromptString(string message)
        {
            string result = "";
            do
            {
                DisplayMessage(message);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        public static string PromptString(string message, bool isRequired)
        {
            if (!isRequired)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }
            return PromptString(message);
        }

        public static string PromptOptions(string message, string[] options)
        {
            bool isValid = false;
            string input;
            do
            {
                input = PromptString(message, true);
                foreach (var option in options)
                {
                    if (option == input)
                    {
                        isValid = true;
                        break;
                    }
                }
                if (!isValid)
                {
                    DisplayMessage("Please try a valid input.");
                }
            } while (isValid == false);
            return input;
        }


        public static DateTime PromptDateTime(string message)
        {
            Console.Clear();
            DateTime orderDate = new DateTime(); // 01/01/0001

            
            while (!DateTime.TryParseExact(PromptString(message), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,out orderDate ))
            {
                DisplayMessage("This is not a valid date, please enter a valid date you wish to search in the MM/DD/YYYY format",ConsoleColor.DarkRed);
            }
            
            return orderDate;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        
    }
}
