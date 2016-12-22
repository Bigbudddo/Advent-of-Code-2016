using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AoC2016 {
    
    public static class Day15 {
        

        public static void Run(string[] input, bool part2 = false) {
            List<Disk> disks = BuildInputDisks(input, part2);
            int time = 0;
            bool loop = true;

            while (loop) {
                foreach (var disk in disks) {
                    int time1 = time;
                    if (disk.HasCapsule(time1, disk.Id, disk.Positions, disk.CurrentPosition)) {
                        time1++;
                        if (disk.Id == disks.Count()) {
                            loop = false;
                            Console.WriteLine("Complete: {0}", time);
                        }
                    }
                    else {
                        break;
                    }
                }
                time++;
            }
            
        }

        //format: Disc #1 has 17 positions; at time=0, it is at position 1.
        public static List<Disk> BuildInputDisks(string[] input, bool part2 = false) {
            List<Disk> disks = new List<Disk>();
            foreach (string s in input) {
                var _s = s.Split(' ');
                //  3 for no of positions
                // 11 for current position
                disks.Add(new Disk() {
                    Id = int.Parse(_s[1].Substring(1, 1)),
                    Positions = int.Parse(_s[3]),
                    CurrentPosition = int.Parse(_s[11].Substring(0, 1))
                });
            }

            if (part2) {
                disks.Add(new Disk() {
                    Id = disks.Count() + 1,
                    Positions = 11,
                    CurrentPosition = 0
                });
            }

            return disks;
        }

        public class Disk {
            public int Id { get; set; }
            public int Positions { get; set; }
            public int CurrentPosition { get; set; }
            
            public bool HasCapsule(int time, int disknum, int total, int start) {
                if ((time + disknum + start) % total == 0) return true;
                return false;
            }
        }
    }
}
