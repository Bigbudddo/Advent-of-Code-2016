using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day6 {

        public static void RunPart1(string[] input) {
            string result = string.Empty;
            
            //assuming every line is the same length...
            if (input.Length <= 0) return;
            char[,] grid = new char[input[0].Length, input.Length];
            for (int o = 0; o < input[0].Length; o++) {
                for (int i = 0; i < input.Length; i++) {
                    grid[o, i] = input[i][o];
                }
            }

            //now we can check each column
            for (int o = 0; o < grid.GetLength(0); o++) {
                Dictionary<char, int> counter = new Dictionary<char, int>();
                
                for (int i = 0; i < grid.GetLength(1); i++) {
                    char x = grid[o, i];
                    if (counter.ContainsKey(x)) {
                        counter[x]++;
                    }
                    else {
                        counter.Add(x, 1);
                    }
                }

                // get the most frequent character
                //counter = counter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value); //part 1
                counter = counter.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                result += new string(counter.Take(1).Select(x => x.Key).ToArray()); //take the first in the array
            }

            Console.WriteLine(string.Format("Your message is: {0}", result));
        }
    }
}
