using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public static class Day3 {

        public static void RunPart1(string[] inputs) {
            int counter = 0;
            foreach (string s in inputs) {
                int[] sides = s.Split(' ').Where(x => x.Length > 0).Select(int.Parse).ToArray();
                /*
                 * Possible combinations?
                 * 1 + 2 = 3
                 * 1 + 3 = 2
                 * 2 + 3 = 1
                 */
                 //Therefore 3 possible combinations to check..
                if ((sides[0] + sides[1]) <= sides[2]) {
                    continue;
                }
                else if ((sides[0] + sides[2]) <= sides[1]) {
                    continue;
                }
                else if ((sides[1] + sides[2]) <= sides[0]) {
                    continue;
                }
                else {
                    counter++;
                }
            }
            Console.WriteLine(String.Format("Total number of possible Triangles: {0}", counter.ToString()));
        }

        public static void RunPart2(string[] input) {
            int counter = 0;
            List<int> colA = new List<int>();
            List<int> colB = new List<int>();
            List<int> colC = new List<int>();

            foreach (string s in input) {
                int[] sides = s.Split(' ').Where(x => x.Length > 0).Select(int.Parse).ToArray();
                colA.Add(sides[0]);
                colB.Add(sides[1]);
                colC.Add(sides[2]);
            }

            for (int i = 0; i < colA.Count() - 2; i += 3) {
                if ((colA[i] + colA[i + 1]) <= colA[i + 2]) continue;
                else if ((colA[i] + colA[i + 2]) <= colA[i + 1]) continue;
                else if ((colA[i + 1] + colA[i + 2]) <= colA[i]) continue;
                else counter++;
            }

            for (int i = 0; i < colB.Count() - 2; i += 3) {
                if ((colB[i] + colB[i + 1]) <= colB[i + 2]) continue;
                else if ((colB[i] + colB[i + 2]) <= colB[i + 1]) continue;
                else if ((colB[i + 1] + colB[i + 2]) <= colB[i]) continue;
                else counter++;
            }

            for (int i = 0; i < colC.Count() - 2; i += 3) {
                if ((colC[i] + colC[i + 1]) <= colC[i + 2]) continue;
                else if ((colC[i] + colC[i + 2]) <= colC[i + 1]) continue;
                else if ((colC[i + 1] + colC[i + 2]) <= colC[i]) continue;
                else counter++;
            }

            Console.WriteLine(String.Format("Total number of possible Triangles in Part 2: {0}", counter.ToString()));
        }
    } 
}
