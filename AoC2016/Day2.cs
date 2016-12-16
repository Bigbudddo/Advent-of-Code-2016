using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day2 {
        
        public static Point FingerPosition = Point.Empty;
        public static string KeypadCombination = string.Empty;
        //part 1 grid
        public static int[,] Keypad = new int[3,3] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        //part 2 grid
        public static char[,] SuperKeypad = new char[5, 5] {
            { '#', '#', '1', '#', '#' },
            { '#', '2', '3', '4', '#' },
            { '5', '6', '7', '8', '9' },
            { '#', 'A', 'B', 'C', '#' },
            { '#', '#', 'D', '#', '#' }
        };

        //commands are L R U D
        public static void RunPart1(string[] commands) {
            FingerPosition = new Point(1, 1); // 5 
            foreach (string s in commands) {
                char[] commandData = s.ToCharArray();
                foreach (char c in commandData) {
                    switch (c) {
                        case 'L':
                            if ((FingerPosition.X - 1) >= 0) {
                                FingerPosition.X -= 1;
                            }
                            break;
                        case 'R':
                            if ((FingerPosition.X + 1) < 3) {
                                FingerPosition.X += 1;
                            }
                            break;
                        case 'U':
                            if ((FingerPosition.Y - 1) >= 0) {
                                FingerPosition.Y -= 1;
                            }
                            break;
                        case 'D':
                            if ((FingerPosition.Y + 1) < 3) {
                                FingerPosition.Y += 1;
                            }
                            break;
                    }
                }
                KeypadCombination += Keypad[FingerPosition.Y, FingerPosition.X].ToString();
            }
            Console.WriteLine(String.Format("Bathroom Code: {0}", KeypadCombination));
        }

        public static void RunPart2(string[] commands) {
            KeypadCombination = string.Empty;
            FingerPosition = new Point(0, 2); // 5
            foreach (string s in commands) {
                char[] commandData = s.ToCharArray();
                foreach (char c in commandData) {
                    switch (c) {
                        case 'L':
                            if ((FingerPosition.X - 1) >= 0 && SuperKeypad[FingerPosition.Y, (FingerPosition.X - 1)] != '#') {
                                FingerPosition.X -= 1;
                            }
                            break;
                        case 'R':
                            if ((FingerPosition.X + 1) < 5 && SuperKeypad[FingerPosition.Y, (FingerPosition.X + 1)] != '#') {
                                FingerPosition.X += 1;
                            }
                            break;
                        case 'U':
                            if ((FingerPosition.Y - 1) >= 0 && SuperKeypad[(FingerPosition.Y - 1), FingerPosition.X] != '#') {
                                FingerPosition.Y -= 1;
                            }
                            break;
                        case 'D':
                            if ((FingerPosition.Y + 1) < 5 && SuperKeypad[(FingerPosition.Y + 1), FingerPosition.X] != '#') {
                                FingerPosition.Y += 1;
                            }
                            break;
                    }
                }
                KeypadCombination += SuperKeypad[FingerPosition.Y, FingerPosition.X].ToString();
            }
            Console.WriteLine(String.Format("Bathroom Code (Part 2): {0}", KeypadCombination));
        }
    }
}
