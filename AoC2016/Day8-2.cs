using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// rewriting this thing in a separate class because it turned out so horribly wrong.
namespace AoC2016 {
    public static class Day8_2 {
        
        public static int GRID_WIDTH = 50;
        public static int GRID_HEIGHT = 6;
        public static char GRID_ON = '#';
        public static char GRID_OFF = '.';

        public static int LitPixels = 0;
        public static char[][] GRID;

        public static void SetupBaseGrid() {
            GRID = new char[GRID_HEIGHT][];
            for (int o = 0; o < GRID_HEIGHT; o++) {
                GRID[o] = new char[GRID_WIDTH];
                for (int i = 0; i < GRID_WIDTH; i++) {
                    GRID[o][i] = GRID_OFF;
                }
            }
        }

        public static void InputCommand(string command) {
            string[] aCommand = command.Split(' ');
            switch (aCommand[0].ToUpper()) {
                case "RECT":
                    int[] xY = aCommand[1].Split('x').Select(int.Parse).ToArray();
                    DrawRectangle(xY[0], xY[1]);
                    break;
                case "ROTATE":
                    if (aCommand[1].ToUpper() == "COLUMN")
                        RotateColumn(aCommand);
                    else
                        RotateRow(aCommand);
                    break;
                default:
                    break;
            }
            OutputGridToScreen();
        }

        public static void OutputGridToScreen() {
            LitPixels = 0;
            Console.Clear(); //!important
            for (int o = 0; o < GRID_HEIGHT; o++) {
                for (int i = 0; i < GRID_WIDTH; i++) {
                    if (GRID[o][i] == GRID_ON) LitPixels++;
                    Console.Write(GRID[o][i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(String.Format("Total Lit: {0}", LitPixels));
        }

        public static void DrawRectangle(int x, int y) {
            for (int o = 0; o < y; o++) {
                for (int i = 0; i < x; i++) {
                    GRID[o][i] = GRID_ON;
                }
            }
        }

        public static void RotateRow(string[] command) {
            //first thing is to get the row and by how many to push it
            int rowPosition = Convert.ToInt32(command[2].Split('=')[1]);
            int pushCounter = Convert.ToInt32(command[4]);

            for (int i = 0; i < pushCounter; i++) {
                char[] gridRow = Enumerable.Range(0, GRID_WIDTH).Select(x => GRID[rowPosition][x]).ToArray();
                Array.Copy(gridRow, 0, GRID[rowPosition], 1, gridRow.Length - 1);
                GRID[rowPosition][0] = gridRow[gridRow.Length - 1];
            }
        }

        public static void RotateColumn(string[] command) {
            int colPosition = Convert.ToInt32(command[2].Split('=')[1]);
            int pushCounter = Convert.ToInt32(command[4]);

            char[] column = Enumerable.Range(0, GRID_HEIGHT).Select(x => GRID[x][colPosition]).ToArray();
            char[] sColumn = new char[column.Length];

            for (int i = 0; i < pushCounter; i++) {
                Array.Copy(column, 0, sColumn, 1, column.Length - 1);
                sColumn[0] = column[column.Length - 1];
                Array.Copy(sColumn, column, column.Length);
            }

            for (int i = 0; i < sColumn.Length; i++) {
                GRID[i][colPosition] = sColumn[i];
            }
        }
    }
}
