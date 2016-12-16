using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day9 {

        public static long Part1(char[] input, long n) {
            long counter = 0;
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == ' ') {
                    continue;
                }
                else if (input[i] == '(') {
                    var marker = new String(input.Skip(i + 1).TakeWhile(x => x != ')').ToArray());
                    var markerSplit = marker.Split('x');

                    int numberOfCharacters = int.Parse(markerSplit[0]);
                    int skipper = i + marker.Length + 2;

                    counter += Part1(input.Skip(skipper).Take(numberOfCharacters).ToArray(), int.Parse(markerSplit[1]));
                    i = skipper + numberOfCharacters - 1;
                }
                else {
                    counter++;
                }
            }
            return counter * n;
        }

        public static List<char> outputStream = new List<char>();

        public static long DecompressString(string input) {
            Console.Clear();
            char[] _input = input.ToCharArray();
            long counter = 0;

            for (int i = 0; i < _input.Length; i++) {
                if (_input[i] == ' ') continue;

                if (_input[i] == '(') {
                    string marker = new String(input.Skip(i + 1).TakeWhile(x => x != ')').ToArray());
                    string[] aMarker = marker.Split('x');

                    int charSelect = int.Parse(aMarker[0]);
                    int repeatTimes = int.Parse(aMarker[1]);
                    
                    string characters = new String(input.Skip(i + (marker.Length + 2)).Take(charSelect).ToArray());
                    
                    
                    string newCharacters = string.Empty;
                    for (int c = 0; c < repeatTimes; c++) {
                        newCharacters += characters;
                    }

                    //outputStream.AddRange(newCharacters.ToCharArray());
                    //counter += newCharacters.ToCharArray().Length;
                    counter += DecompressString(newCharacters);
                    i = (i + marker.Length + 2) + charSelect - 1;
                }
                else {
                    //outputStream.Add(_input[i]);
                    counter++;
                }
            }
            Console.WriteLine(counter);
            return counter;
        }
    }
}
