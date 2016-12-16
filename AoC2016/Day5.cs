using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AoC2016 {
    
    public static class Day5 {

        public static int PasswordLength = 8;
        public static char[] GeneratedPassword;

        public static void RunPart1(string input) {
            GeneratedPassword = new char[PasswordLength];
            for (int i = 0; i < GeneratedPassword.Length; i++) {
                GeneratedPassword[i] = '#';
            }

            using (MD5 md5Hash = MD5.Create()) {
                long counter = 0;
                do {
                    string inputHash = input + counter.ToString();
                    byte[] inputData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputHash));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < inputData.Length; i++) {
                        builder.Append(inputData[i].ToString("x2"));
                    }
                    string thisHash = builder.ToString();

                    if (thisHash.StartsWith("00000")) {
                        //Console.WriteLine(String.Format("Index: {0} Produces Password Character: {1} with HASH: {2}", counter, thisHash[5], thisHash));
                        char whatINeed = thisHash[6];

                        if (char.IsDigit(thisHash[5])) {
                            //int currentPosition = GeneratedPassword.ToList().IndexOf('#'); //part 1
                            int currentPosition = int.Parse(thisHash[5].ToString()); // part 2
                            if (currentPosition < 8 && GeneratedPassword[currentPosition] == '#') { // if statement for part 2
                                GeneratedPassword[currentPosition] = whatINeed;
                            }
                        }
                    }

                    //Console.Clear();
                    //Console.WriteLine(String.Format("{0}", new string(GeneratedPassword.ToArray())));
                    counter++;
                }
                while (GeneratedPassword.Contains('#'));
            }

            Console.WriteLine();
            Console.WriteLine(String.Format("Your password: {0}", new string(GeneratedPassword.ToArray())));
        }
    }
}
