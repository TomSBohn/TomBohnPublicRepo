using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomBohnWarmUps
{
    public class LogicWarmups
    {
        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars >= 40 && cigars <= 60 || isWeekend == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2; //yes
            }
            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0; //nope
            }
            else
            {
                return 1; //maybe
            }

        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer && temp - 10 >= 60 && temp - 10 <= 90)
            {
                return true;
            }
            if (temp >= 60 && temp <= 90)
            {
                return true;
            }
            return false;
        }


        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            //Use a switch() statement?
            if (isBirthday == true)
            {
                speed = speed - 5;
            }
            
                if (speed <= 60)
                {
                    return 0;
                }
                else if (speed >= 61 && speed <= 80)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            
        }


        public int SkipSum(int a, int b)
        {
            if (a + b >= 10 && a + b <= 19)
            {
                return 20;
            }
            else
            {
                return a + b;
            }
        }

        //This would be a good one for code review
        //It works, but it's really long.
        public string AlarmClock(int day, bool vacation)
        {
            if (vacation && ( day == 0 || day == 6))
            {
                return "off";
            }
            if (vacation)
            {
                return "10:00";
            }
            if (!vacation && (day == 1 || day == 2 || day == 3 || day == 4 || day == 5))
                //could just if(day != 0 && day != 6)
            {
                return "7:00";
            }
            return "10:00";
        }

        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            if (a + b == 6)
            {
                return true;
            }
            return false;
        }

        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode && (n <= 1 || n >= 10))
            {
                return true;
            }
            if (!outsideMode && (n >= 1 && n <= 10))
            {
                return true;
            }
            return false;
        }




    }
}

