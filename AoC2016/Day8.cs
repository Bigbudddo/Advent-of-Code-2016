using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016 {
    
    public sealed class Day8 {

        
        private const int GRID_WIDTH = 50;
        private const int GRID_HEIGHT = 6;
        private const char GRID_ON = '#';
        private const char GRID_OFF = '.';
        private char[,] Grid; // >> [x][y]

        public int LitPixels {
            get {
                int counter = 0;
                for (int x = 0; x < GRID_WIDTH; x++) {
                    for (int y = 0; y < GRID_HEIGHT; y++) {
                        if (Grid[x, y] == GRID_ON) counter++;
                    }
                }
                return counter;
            }
            private set {
                LitPixels = value;
            }
        }
        
        public Day8() {
            Grid = new char[GRID_WIDTH, GRID_HEIGHT];
            for (int x = 0; x < GRID_WIDTH; x++) {
                for (int y = 0; y < GRID_HEIGHT; y++) {
                    Grid[x, y] = GRID_OFF;
                }
            }
            //populate our grid to be all off
            //for (int o = 0; o < Grid.GetLength(0); o++) {
            //    for (int i = 0; i < Grid.GetLength(1); i++) {
            //        Grid[o, i] = GRID_OFF;
            //    }
            //}
        }

        //public void InputCommand(string commandText) {
        //    var aCommand = commandText.Split(' ');
        //    switch (aCommand[0].ToUpper()) {
        //        case "RECT":
        //            Command_Rect(ref this.Grid, aCommand, out this.Grid);
        //            break;
        //        case "ROTATE":
        //            Command_Rotate(ref this.Grid, aCommand, out this.Grid);
        //            break;
        //        default:
        //            WriteMessageToConsole("Unknown Input Command", true);
        //            break;
        //    }

        //    //now draw!
        //    WriteGridToConsole(ref this.Grid);
        //}

        //public int CountOnGridItems() {
        //    int counter = 0;
        //    for (int o = 0; o < Grid.GetLength(0); o++) {
        //        for (int i = 0; i < Grid.GetLength(1); i++) {
        //            if (Grid[o, i] == GRID_ON) {
        //                counter++;
        //            }
        //        }
        //    }
        //    return counter;
        //}

        public void WriteGridToConsole() {
            Console.Clear();
            for (int y = 0; y < GRID_HEIGHT; y++) {
                for (int x = 0; x < GRID_WIDTH; x++) {
                    Console.Write(Grid[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(String.Format("Total Lit: {0}", LitPixels));
        }

        //public void WriteGridToConsole(ref char[,] grid) {
        //    Console.Clear();
        //    for (int o = 0; o < grid.GetLength(0); o++) {
        //        for (int i = 0; i < grid.GetLength(1); i++) {
        //            Console.Write(grid[o, i]);
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public void WriteMessageToConsole(string msg, bool errorMsg) {
            var c = errorMsg ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.ForegroundColor = c;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void Command_Rect(int a, int b) {
            for (int y = 0; y < b; y++) {
                for (int x = 0; x < a; x++) {
                    Grid[x, y] = GRID_ON;
                }
            }
        }

        //private void Command_Rect(ref char[,] grid, string[] commandContents, out char[,] array) {
        //    //this command should look like [rect 1x1] -> we want the [1x1] -> position 1 in array!
        //    var aOnSize = commandContents[1].Split('x');
        //    int x = Convert.ToInt32(aOnSize[0]), y = Convert.ToInt32(aOnSize[1]);
        //    for (int o = 0; o < y; o++) {
        //        for (int i = 0; i < x; i++) {
        //            grid[o, i] = GRID_ON;
        //        }
        //    }
        //    array = grid;
        //}

        //rotate is more like move...

        private void RotateRow(int a, int b) {
            for (int i = 0; i < b; i++) {
                char[] row = Enumerable.Range(0, GRID_WIDTH).Select(x => Grid[a, x]).ToArray();
                //Array.Copy(row, 0, Grid[a], 1, row.Length - 1);
            }
        }

        private void Command_Rotate(ref char[,] grid, string[] commandContents, out char[,] array) {
            //this command has a layout [rotate row y=0 by 5] -> we want the [y=0] as starting AND then [5] to determine how far to move
            //SO.. y=0 by 5 will shift the first row along by 5
            //we also have column, which would be the 2nd word in the command (1 in index)
            Dictionary<int, int> newLocations = new Dictionary<int, int>();
            if (commandContents[1].ToUpper() == "COLUMN") {
                //shift downwards
                int columnPosition = Convert.ToInt32(commandContents[2].Split('=')[1]);
                int numberToPushDown = Convert.ToInt32(commandContents[4]);

                for (int i = 0; i < grid.GetLength(0); i++) {
                    if (grid[i, columnPosition] == GRID_ON) {
                        int i2 = i + numberToPushDown;
                        if (i2 >= GRID_HEIGHT) i2 -= GRID_HEIGHT;
                        newLocations.Add(i, i2);
                    }
                }

                foreach (KeyValuePair<int, int> x in newLocations) {
                    char temp = grid[x.Value, columnPosition];
                    grid[x.Value, columnPosition] = grid[x.Key, columnPosition];
                    grid[x.Key, columnPosition] = temp;
                }
            }
            else {
                //shift right-wards
                int rowPosition = Convert.ToInt32(commandContents[2].Split('=')[1]);
                int numberToPushAlong = Convert.ToInt32(commandContents[4]);

                for (int i = 0; i < grid.GetLength(1); i++) {
                    if (grid[rowPosition, i] == GRID_ON) {
                        int i2 = i + numberToPushAlong;
                        if (i2 >= GRID_WIDTH) i2 -= GRID_WIDTH;
                        newLocations.Add(i, i2);
                    }
                }

                foreach (KeyValuePair<int, int> x in newLocations) {
                    char temp = grid[rowPosition, x.Value];
                    grid[rowPosition, x.Value] = grid[rowPosition, x.Key];
                    grid[rowPosition, x.Key] = temp;
                }
            }
            array = grid;
        }
    }
}
