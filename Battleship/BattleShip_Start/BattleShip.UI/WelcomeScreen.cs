using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class WelcomeScreen
    {
        public static void printWelcomeScreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BBBBB     AAA   TTTTTTT TTTTTTT LL      EEEEEEE  SSSSS  HH   HH IIIII PPPPPP  \n" +
                              "BB   B   AAAAA    TTT     TTT   LL      EE      SS      HH   HH  III  PP   PP \n" +
                              "BBBBBB  AA   AA   TTT     TTT   LL      EEEEE    SSSSS  HHHHHHH  III  PPPPPP  \n" +
                              "BB   BB AAAAAAA   TTT     TTT   LL      EE           SS HH   HH  III  PP      \n" +
                              "BBBBBB  AA   AA   TTT     TTT   LLLLLLL EEEEEEE  SSSSS  HH   HH IIIII PP      \n");
            Console.WriteLine("");
            Console.WriteLine(@"                                        # #  ( )");
            Console.WriteLine(@"                                     ___#_#___|__");
            Console.WriteLine(@"                                 _  |____________|  _");
            Console.WriteLine(@"                          _=====| | |            | | |==== _");
            Console.WriteLine(@"                    =====| |.---------------------------. | |====");
            Console.WriteLine(@"       <--------------------'   .  .  .  .  .  .  .  .   '--------------/");
            Console.WriteLine(@"        \                                                             /");
            Console.WriteLine(@"         \___________________________________________________________/");
            Console.WriteLine(@"     wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");

            // Source is : http://chris.com/ascii/index.php?art=transportation/nautical

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to Battle Ship!");

           Console.Beep(220, 300);
           Console.Beep(294, 300);
           Console.Beep(294, 300);
           Console.Beep(370, 300);
           Console.Beep(494, 300);
           Console.Beep(370, 300);
           Console.Beep(440, 800);

            // Source is : https://www.daniweb.com/programming/software-development/code/216832/doraemon-s-song-this-song-will-be-out-in-internal-spekaers



        }
    }
}
