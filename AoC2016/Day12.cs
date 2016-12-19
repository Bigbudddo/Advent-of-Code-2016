using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day12 {

        public static int RegA = 0;
        public static int RegB = 0;
        public static int RegC = 1;
        public static int RegD = 0;

        public static void RunPart1(string[] input) {
            for (int i = 0; i < input.Length; i++) {
                var _s = input[i].Split(' ');
                switch (_s[0]) {
                    case "cpy":
                        int value = 0;
                        if (!int.TryParse(_s[1], out value)) {
                            switch (_s[1]) {
                                case "a":
                                    value = RegA;
                                    break;
                                case "b":
                                    value = RegB;
                                    break;
                                case "c":
                                    value = RegC;
                                    break;
                                case "d":
                                    value = RegD;
                                    break;
                            }
                        }
                        switch (_s[2]) {
                            case "a":
                                RegA = value;
                                break;
                            case "b":
                                RegB = value;
                                break;
                            case "c":
                                RegC = value;
                                break;
                            case "d":
                                RegD = value;
                                break;
                        }
                        break;
                    case "inc":
                        switch (_s[1]) {
                            case "a":
                                RegA++;
                                break;
                            case "b":
                                RegB++;
                                break;
                            case "c":
                                RegC++;
                                break;
                            case "d":
                                RegD++;
                                break;
                        }
                        break;
                    case "dec":
                        switch (_s[1]) {
                            case "a":
                                RegA--;
                                break;
                            case "b":
                                RegB--;
                                break;
                            case "c":
                                RegC--;
                                break;
                            case "d":
                                RegD--;
                                break;
                        }
                        break;
                    case "jnz":
                        int jump = int.Parse(_s[2]);
                        int valueToCompare = 0;
                        if (!int.TryParse(_s[1], out valueToCompare)) {
                            switch (_s[1]) {
                                case "a":
                                    valueToCompare = RegA;
                                    break;
                                case "b":
                                    valueToCompare = RegB;
                                    break;
                                case "c":
                                    valueToCompare = RegC;
                                    break;
                                case "d":
                                    valueToCompare = RegD;
                                    break;
                            }
                        }
                        if (valueToCompare > 0) {
                            i += (jump - 1);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Format("Value of Register A after execute is: {0}", RegA));
        }
    }
}
