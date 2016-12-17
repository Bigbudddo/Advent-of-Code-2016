using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using AoC2016;

namespace DebuggingConsole {
    class Program {
        
        static void Main(string[] args) {
            
            //string day1File = DebuggingConsole.Properties.Resources.Day1_Input;
            //Day1.Run(day1File);
            //Day1.RunPart2(day1File);

            //string[] day2Test = new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" };
            //string day2Resource = DebuggingConsole.Properties.Resources.Day2_Input;
            //day2Resource = day2Resource.Replace("\r", "");
            //string[] _day2Resource = day2Resource.Split('\n');
            //Day2.RunPart1(_day2Resource);
            //Day2.RunPart2(_day2Resource);

            //string[] day3Test = new string[] { "5 10 25" };
            //string day3Resource = DebuggingConsole.Properties.Resources.Day3_Input;
            //day3Resource = day3Resource.Replace("\r", "");
            //string[] _day3Resource = day3Resource.Split('\n');
            //Day3.RunPart1(_day3Resource);
            //Day3.RunPart2(_day3Resource);

            //string[] day4Test = new string[] { "aaaaa-bbb-z-y-x-123[abxyz]", "a-b-c-d-e-f-g-h-987[abcde]", "not-a-real-room-404[oarel]", "totally-real-room-200[decoy]", "qzmt-zixmtkozy-ivhz-343[]" };
            //string day4Resource = DebuggingConsole.Properties.Resources.Day4_Input;
            //day4Resource = day4Resource.Replace("\r", "");
            //string[] _day4Resource = day4Resource.Split('\n');
            //Day4.RunPart1(_day4Resource);
            //Day4.RunPart2(_day4Resource);

            //Day5.RunPart1("uqwqemis");

            //string day6Resource = DebuggingConsole.Properties.Resources.Day6_Input;
            //day6Resource = day6Resource.Replace("\r", "");
            //string[] _day6Resource = day6Resource.Split('\n');
            //Day6.RunPart1(_day6Resource);

            //string[] day7Test = new string[] { "abba[mnop]qrst", "abcd[bddb]xyyx", "aaaa[qwer]tyui", "ioxxoj[asdfgh]zxcvbn" };
            //string[] day7Test2 = new string[] { "aba[bab]xyz", "xyx[xyx]xyx", "aaa[kek]eke", "zazbz[bzb]cdb" };
            //string day7Resource = DebuggingConsole.Properties.Resources.Day7_Input;
            //day7Resource = day7Resource.Replace("\r", "");
            //string[] _day7Resource = day7Resource.Split('\n');
            //Day7.RunPart1(_day7Resource);
            //Day7.RunPart2(_day7Resource);

            //Day8_2.SetupBaseGrid();
            //Day8_2.OutputGridToScreen();
            //foreach (string command in a_dResource) {
            //    Day8_2.InputCommand(command);
            //}

            //string _dResource = DebuggingConsole.Properties.Resources.Day9_Input;
            //string day9TestString = "ADVENTA(1x5)BC(3x3)XYZA(2x2)BCD(2x2)EFG(6x1)(1x3)AX(8x2)(3x3)ABCY";
            //string day9TestString = "(27x12)(20x12)(13x14)(7x10)(1x12)A";
            //long result = Day9.Part1(_dResource.ToCharArray(), 1);
            //Console.WriteLine(String.Format("Part 1 Solution is... {0}", result));

            string[] day8Test = new string[] { "value 5 goes to bot 2", "bot 2 gives low to bot 1 and high to bot 0", "value 3 goes to bot 1", 
                "bot 1 gives low to output 1 and high to bot 0", "bot 0 gives low to output 2 and high to output 0", "value 2 goes to bot 2"
            };
            Day10.RunPart1(day8Test);

            /// The End is here...
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Application has hit the end. Press enter to terminate...");
            Console.ReadLine();
        }
    }
}
