using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day7 {

        public static void RunPart1(string[] input) {
            long counter = 0;
            foreach (string s in input) {
                string sequence = string.Empty;
                List<string> nonBracketSequences = new List<string>();
                List<string> BracketSequences = new List<string>();
            
                foreach (char c in s.ToCharArray()) {
                    if (c == '[') {
                        nonBracketSequences.Add(sequence);
                        sequence = string.Empty;
                        continue;
                    }
                    else if (c == ']') {
                        BracketSequences.Add(sequence);
                        sequence = string.Empty;
                        continue;
                    }
                    else {
                        sequence += c.ToString();
                    }
                }
                nonBracketSequences.Add(sequence);

                bool check = false;
                foreach (string bSeq in BracketSequences) {
                    if (CheckAbba(bSeq)) {
                        check = true;
                        break;
                    }
                }

                if (!check) {
                    foreach (string nbSeq in nonBracketSequences) {
                        if (CheckAbba(nbSeq)) {
                            counter++;
                            break;
                        }
                    }   
                }
            }
            Console.WriteLine(string.Format("Total Number of TLS IPS: {0}", counter));
        }

        public static void RunPart2(string[] input) {
            long counter = 0;
            foreach (string s in input) {
                string sequence = string.Empty;
                List<string> nonBracketSequences = new List<string>();
                List<string> BracketSequences = new List<string>();

                foreach (char c in s.ToCharArray()) {
                    if (c == '[') {
                        nonBracketSequences.Add(sequence);
                        sequence = string.Empty;
                        continue;
                    }
                    else if (c == ']') {
                        BracketSequences.Add(sequence);
                        sequence = string.Empty;
                        continue;
                    }
                    else {
                        sequence += c.ToString();
                    }
                }
                nonBracketSequences.Add(sequence);

                bool flag = false;
                foreach (string nbSeq in nonBracketSequences) {
                    flag = false;
                    int position = 0;

                    while (position < nbSeq.Length) {
                        string aba = FindABA(nbSeq, ref position, out position);
                        if (aba != null) {
                            string bab = FindBAB(aba);
                            foreach (string bSeq in BracketSequences) {
                                if (bSeq.Contains(bab)) {
                                    flag = true;
                                    counter++;
                                    break;
                                }
                            }
                        }

                        if (flag) break;
                    }
                    if (flag) break;
                }
            }
            Console.WriteLine(string.Format("Total Number of SSL: {0}", counter));
        }

        public static bool CheckAbba(string s) {
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length - 3; i++) {
                if (c[i + 1] == c[i + 2]) {
                    if (c[i] != c[i + 1]) {
                        if (c[i] == c[i + 3]) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static string FindABA(string s, ref int start, out int index) {
            char[] c = s.ToCharArray();
            for (int i = start; i < c.Length - 2; i++) {
                if (c[i] == c[i + 2] && c[i] != c[i + 1]) {
                    index = i + 1;
                    return c[i].ToString() + c[i + 1].ToString() + c[i + 2].ToString();
                }
            }
            index = start + 1;
            return null;
        }

        public static string FindBAB(string aba) {
            char[] c = aba.ToCharArray();
            return c[1].ToString() + c[0].ToString() + c[1].ToString();
        }
    }
}
