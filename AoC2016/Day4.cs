using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day4 {

        public static char[] Alaphabet = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        public static void RunPart1(string[] input) {
            int counter = 0;
            foreach (string s in input) {
                var _input = s.ToCharArray();
                //Get the Sector Name
                string sectorName = new string(_input.TakeWhile(x => !Char.IsDigit(x)).ToArray());
                sectorName = sectorName.Remove(sectorName.Length - 1);

                //Get the Sector ID
                string sectorID = new string(_input.Where(x => Char.IsDigit(x)).ToArray());
                
                //Get the Checksum
                int start = (s.IndexOf('[') + 1);
                string checksum = new string(_input.Skip(start).TakeWhile(x => x != ']').ToArray());
                
                Dictionary<char, int> encryptionCounter = new Dictionary<char,int>();
                foreach (char c in sectorName.ToCharArray()) {
                    if (c == '-') continue;
                    if (encryptionCounter.ContainsKey(c)) {
                        encryptionCounter[c]++;
                    }
                    else {
                        encryptionCounter.Add(c, 1);
                    }
                }

                encryptionCounter = encryptionCounter.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).ToDictionary(x => x.Key, x => x.Value);
                var stringResult = new string(encryptionCounter.Select(x => x.Key).ToArray());
                if (stringResult == checksum) {
                    counter += int.Parse(sectorID);
                }
            }
            Console.WriteLine("Part 1 Results in value of: {0}", counter.ToString());
        }

        public static void RunPart2(string[] input) {
            int result = 0;
            List<string> nonDecoyData = new List<string>();

            foreach (string s in input) {
                var _input = s.ToCharArray();
                //Get the Sector Name
                string sectorName = new string(_input.TakeWhile(x => !Char.IsDigit(x)).ToArray());
                sectorName = sectorName.Remove(sectorName.Length - 1);

                //Get the Sector ID
                string sectorID = new string(_input.Where(x => Char.IsDigit(x)).ToArray());

                //Get the Checksum
                int start = (s.IndexOf('[') + 1);
                string checksum = new string(_input.Skip(start).TakeWhile(x => x != ']').ToArray());

                Dictionary<char, int> encryptionCounter = new Dictionary<char, int>();
                foreach (char c in sectorName.ToCharArray()) {
                    if (c == '-') continue;
                    if (encryptionCounter.ContainsKey(c)) {
                        encryptionCounter[c]++;
                    }
                    else {
                        encryptionCounter.Add(c, 1);
                    }
                }

                encryptionCounter = encryptionCounter.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).ToDictionary(x => x.Key, x => x.Value);
                var stringResult = new string(encryptionCounter.Select(x => x.Key).ToArray());
                if (stringResult == checksum) {
                    nonDecoyData.Add(String.Format("{0}|{1}", sectorName, sectorID));
                }
            }

            foreach (string s in nonDecoyData) {
                string[] _s = s.Split('|');
                string encodedSectorName = _s[0];
                string decodedSectorName = string.Empty;
                int sectorID = int.Parse(_s[1]);

                foreach (char c in encodedSectorName.ToCharArray()) {
                    if (c == '-') {
                        decodedSectorName += ' ';
                    }
                    else {
                        char tempChar = c;
                        for (int i = 0; i < sectorID; i++) {
                            if (tempChar == 'z') {
                                tempChar = 'a';
                            }
                            else {
                                tempChar++;
                            }
                        }
                        decodedSectorName += tempChar;
                    }
                }

                Console.WriteLine(decodedSectorName);
                if (decodedSectorName.Contains("northpole")) {
                    result = sectorID;
                }
            }

            if (result > 0) {
                //we found it!
                Console.WriteLine("The sector ID of the North Pole objects is: {0}", result.ToString());
            }
            else {
                Console.WriteLine("Oops! Must be a mistake because I couldn't find the sector ID...");
            }
        }
    }
}
