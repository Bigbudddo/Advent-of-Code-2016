using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2016 {
    
    // I do not recommend using this method unless you have a lot of time to kill.
    // Took severl hours to get through it using this way, I recommend cach'ing the results
    // to speed everything up!
    public static class Day14 {
        
        public static List<string> FoundPotentialKeys = new List<string>();
        public static Dictionary<int, string> OneTimePads = new Dictionary<int,string>();

        public static void Run(string inputSalt = "ihaygndm", int keyPadPosition = 64, bool part2 = false) {
            using (MD5 md5Hash = MD5.Create()) {
                int index = 0;
                while (OneTimePads.Count() < keyPadPosition) {
                    Console.WriteLine("Checking Index: {0}", index);

                    string hash = string.Empty;
                    if (part2) {
                        hash = RepeatHashing(md5Hash, inputSalt + index.ToString());
                    }
                    else {
                        hash = ComputeHash(md5Hash, inputSalt + index.ToString());
                    }

                    Match m = CheckSequence(hash, 3);
                    if (m.Success) {
                        FoundPotentialKeys.Add(hash);
                        char character = m.ToString()[0]; //the character we will look for 5* of
                        //Console.WriteLine(String.Format("Found a potential keypad value at index: {0} with character: {1}... checking for one-time pad", index, character));

                        if (CheckLoop(md5Hash, inputSalt, index, index + 1000, character)) {
                            OneTimePads.Add(index, hash);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(String.Format("Found a one-time pad at index: {0}", index));
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                    }                    
                    index++;
                }
            }

            int positionIndex = OneTimePads.Count() - 1;
            int keyWeNeed = OneTimePads.Keys.ToList()[positionIndex];

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(String.Format("{0} one-time pad value is: {1} at Index: {2}", keyPadPosition, OneTimePads[keyWeNeed], keyWeNeed));
        }

        public static string ComputeHash(MD5 md5Hash, string input) {
            byte[] hashData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++) {
                builder.Append(hashData[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool CheckLoop(MD5 md5Hash, string salt, int start, int finish, char character) {
            for (int i = (start + 1); i < finish; i++) {
                //string hash = ComputeHash(md5Hash, salt + i.ToString());
                string hash = RepeatHashing(md5Hash, salt + i.ToString());

                Match m = CheckSequence(hash, 5);
                if (m.Success && m.ToString()[0] == character) {
                    return true;
                }
            }
            return false;
        }

        public static Match CheckSequence(string hash, int length) {
            return Regex.Match(hash, "(.)\\1{" + (length - 1) + "}");
        }

        //for part 2
        public static string RepeatHashing(MD5 md5Hash, string currentHash, int timesToHash = 2016) {
            string result = currentHash;
            for (int i = 0; i < timesToHash + 1; i++) {
                result = ComputeHash(md5Hash, result);
            }
            return result;
        }
    }
}
