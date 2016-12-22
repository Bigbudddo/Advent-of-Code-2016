using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;

namespace AoC2016 {
    public static class Day13 {

        public static char WALL = '#';
        public static char FLOOR = '0';

        public static int RunPart1(int startX, int startY, int endX, int endY, int favNumber = 1350) {
            // formula: x*x + 3*x + 2*x*y + y + y*y
            // open space, we can continue, otherwise we cannot continue with that path
            Point start = new Point(startX , startY);
            Point end = new Point(endX, endY);

            Queue<Node> queue = new Queue<Node>();
            HashSet<Point> visited = new HashSet<Point>();
            visited.Add(start);

            queue.Enqueue(new Node(start, 0)); //queue up the starting point
            while (queue.Count() > 0) {
                Node x = queue.Dequeue(); //get our node
                // first check if we have reached the end
                if (x.Position == end) {
                    return x.Distance;
                }
                // else get each point surrounding the current point, except diagonals
                // above is -1 on column and 0 on the row
                // below is +1 on column and 0 on the row
                // left is 0 on column and -1 on the row
                // right is 0 on column and +1 on the row
                for (int i = 0; i < 4; i++) {
                    Point p = Point.Empty;
                    switch (i) {
                        case 0: //up
                            p = new Point(x.Position.X, (x.Position.Y - 1));
                            break;
                        case 1: //down
                            p = new Point(x.Position.X, (x.Position.Y + 1));
                            break;
                        case 2: //left
                            p = new Point((x.Position.X - 1), x.Position.Y);
                            break;
                        case 3: //right
                            p = new Point((x.Position.X + 1), x.Position.Y);
                            break;
                    }

                    //double check some things...
                    if (p != Point.Empty && p.X >= 0 && p.Y >= 0) {
                        bool wall = isWall(p, favNumber);
                        DrawToConsole(p, wall);

                        if (!wall && !visited.Contains(p)) {
                            visited.Add(p);
                            Node n = new Node(p, x.Distance + 1);
                            queue.Enqueue(n);

                            if (n.Position == end) {
                                return n.Distance;
                            }
                        }
                    }
                }
            }
            return -1;
        }

        public static int RunPart2(int startX, int startY, int endX, int endY, int distance = 50, int favNumber = 1350) {
            int counter = 1; //1 as we are including the initial coord (1,1)
            Point start = new Point(startX, startY);
            Point end = new Point(endX, endY);

            Queue<Node> queue = new Queue<Node>();
            HashSet<Point> visited = new HashSet<Point>();
            visited.Add(start);

            queue.Enqueue(new Node(start, 0)); //queue up the starting point
            while (queue.Count() > 0) {
                Node x = queue.Dequeue(); //get our node
                // first check if we have reached the end
                if (x.Distance > distance) {
                    break;
                }

                for (int i = 0; i < 4; i++) {
                    Point p = Point.Empty;
                    switch (i) {
                        case 0: //up
                            p = new Point(x.Position.X, (x.Position.Y - 1));
                            break;
                        case 1: //down
                            p = new Point(x.Position.X, (x.Position.Y + 1));
                            break;
                        case 2: //left
                            p = new Point((x.Position.X - 1), x.Position.Y);
                            break;
                        case 3: //right
                            p = new Point((x.Position.X + 1), x.Position.Y);
                            break;
                    }

                    //double check some things...
                    if (p != Point.Empty && p.X >= 0 && p.Y >= 0) {
                        bool wall = isWall(p, favNumber);
                        DrawToConsole(p, wall);

                        if (!wall && !visited.Contains(p)) {
                            visited.Add(p);
                            Node n = new Node(p, x.Distance + 1);
                            queue.Enqueue(n);

                            if (n.Distance <= distance) {
                                counter++;
                            }
                        }
                    }
                }
            }
            return counter;
        }

        public static bool isWall(Point p, int favNumber) {
            var value = Convert.ToString(((p.X * p.X) + (3 * p.X) + (2 * p.X * p.Y) + p.Y + p.Y * p.Y) + favNumber, 2);
            int counter = value.ToCharArray().Where(x => x == '1').ToArray().Length;
            return counter % 2 != 0;
        }

        public static void DrawToConsole(Point p, bool isWall) {
            char writeChar = isWall ? WALL : FLOOR;
            Console.ForegroundColor = (isWall) ? ConsoleColor.Red : ConsoleColor.White;
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(writeChar);
            Thread.Sleep(10);
        }
    }

    public class Node {
        public Point Position { get; set; }
        public int Distance { get; set; }

        public Node(Point p, int distance) {
            Position = p;
            Distance = distance;
        }
    }
}
