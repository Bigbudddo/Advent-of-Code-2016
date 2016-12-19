using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AoC2016 {
    
    public static class Day14 {
        
        public static List<string> Keys = new List<string>();
        public static List<string> OneTimePads = new List<string>();

        public static void RunPart1(string inputSalt = "ihaygndm", int keyPadPosition = 64) {
            using (MD5 md5Hash = MD5.Create()) {
                int index = 0;
                while (OneTimePads.Count() < keyPadPosition) {
                    string x = inputSalt + index.ToString();
                    byte[] hashData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(x));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashData.Length; i++) {
                        builder.Append(hashData[i].ToString("x2"));
                    }
                    string thisHash = builder.ToString();

                    index++;
                }
            }
        }
    }
}
