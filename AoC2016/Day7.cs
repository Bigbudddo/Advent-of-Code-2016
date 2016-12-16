using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day7 {

        public static int Run(string[] input) {
            int counter = 0;
            foreach (string s in input) {
                if (CheckLine(s)) counter++;
            }
            return counter;
        }

        public static bool isAbbaSequence(string sequence) {
            char[] c = sequence.ToCharArray();
            for (int i = 0; i < c.Length - 3; i++) {
                if (c[i + 1] == c[i + 3]) return false; //inner ones cannot be the same

                string sequenceA = c[i].ToString() + c[i + 1].ToString();
                string sequenceB = c[i + 3].ToString() + c[i + 2].ToString();
                if (sequenceA == sequenceB) return true;
            }
            return false;
        }

        public static bool CheckLine(string line) {
            bool check = false;
            char[] _line = line.ToCharArray();

            string tempString = string.Empty;
            for (int i = 0; i < _line.Length; i++) {
                if (_line[i] == '[') {
                    string bracketSequence = new String(_line.Skip(i + 1).TakeWhile(x => x != ']').ToArray());

                    if (isAbbaSequence(bracketSequence)) {
                        return false;
                    }
                    else if (isAbbaSequence(tempString)) {
                        check = true;
                    }

                    tempString = string.Empty;
                    i += bracketSequence.Length + 2;
                }
                else {
                    tempString += _line[i];
                }
            }
            return check;
        }
    }
}
