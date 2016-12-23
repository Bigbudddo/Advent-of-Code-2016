using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day16 {

        public static void Run(string input, int length, bool outputfile = true) {
            string _filledInput = Fill(input, length);
            string filledInput = new string(_filledInput.ToCharArray().Take(length).ToArray());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Filled output before trim is: {0}", _filledInput);
            Console.WriteLine("Filled Input String is: {0}", filledInput);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Generating Checksum for the Input...");

            string checksum = filledInput;
            do {
                checksum = GenerateChecksum(checksum);
                Console.WriteLine("Checksum Generated: {0}", checksum);
            } while(CheckSumEven(checksum));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Checksum for this Input: {0}", checksum);
            Console.ForegroundColor = ConsoleColor.DarkGray;

            OutputToFile(checksum);
        }

        public static void OutputToFile(string checksum, string filepath = "d://output.txt") {
            using (StreamWriter writer = new StreamWriter(filepath)) {
                writer.WriteLine(checksum);
            }
        }

        public static string Fill(string input, int length) {
            string filledInput = input;
            //we will let filledInput = a
            while (filledInput.Length < length) {
                string b = new string(filledInput.ToCharArray().Reverse().ToArray());
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < b.Length; i++) {
                    if (b[i] == '0') 
                        builder.Append('1');
                    else 
                        builder.Append('0');
                }
                filledInput = filledInput + "0" + builder.ToString();
                //below is the older and much slow method
                /*string a = filledInput;

                //reverse a and place it into b
                string b = string.Empty;
                for (int i = a.Length - 1; i >= 0; i--) {
                    if (a[i] == '1') {
                        b += '0';
                    }
                    else {
                        b += '1';
                    }
                }

                string ab = String.Format("{0}0{1}", a, b);
                filledInput = ab;*/
            }
            return filledInput;
        }

        public static string GenerateChecksum(string input) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.Length - 1; i += 2) {
                if (input[i] == input[i + 1])
                    builder.Append('1');
                else
                    builder.Append('0');
            }
            return builder.ToString();
        }

        public static bool CheckSumEven(string checksum) {
            return checksum.Length % 2 == 0;
        }
    }
}
