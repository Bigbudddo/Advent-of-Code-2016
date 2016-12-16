﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using AoC2016;

namespace DebuggingConsole {
    class Program {
        
        static void Main(string[] args) {
            
            string day1File = DebuggingConsole.Properties.Resources.Day1_Input;
            //Day1.Run(day1File);
            Day1.RunPart2(day1File);

            //string _dResource = DebuggingConsole.Properties.Resources.Day7_Input;
            //_dResource = _dResource.Replace("\r", "");
            //string[] a_dResource = _dResource.Split('\n');

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

            //string[] day7test = new string[] { "abba[mnop]qrst", "abcd[bddb]xyyx", "aaaa[qwer]tyui", "ioxxoj[asdfgh]zxcvbn" };
            //int count = Day7.Run(day7test);
            //int count = Day7.Run(a_dResource);
            //Console.WriteLine(String.Format("Result: {0}", count));

            /// The End is here...
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Application has hit the end. Press enter to terminate...");
            Console.ReadLine();
        }
    }
}
