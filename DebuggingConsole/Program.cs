using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using AoC2016;

namespace DebuggingConsole {
    class Program {
        
        private static Day8 day8Puzzler;
        
        static void Main(string[] args) {

            string _dResource = DebuggingConsole.Properties.Resources.Day8_Input;
            _dResource = _dResource.Replace("\r", "");
            string[] a_dResource = _dResource.Split('\n');

            Day8_2.SetupBaseGrid();
            Day8_2.OutputGridToScreen();
            foreach (string command in a_dResource) {
                Day8_2.InputCommand(command);
            }

            /// The End is here...
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Application has hit the end. Press enter to terminate...");
            Console.ReadLine();
        }
    }
}
