using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC2016 {

    public static class Day1 {

        public enum Direction {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public static class Position {
            public static int PreviousX = 0;
            public static int PreviousY = 0;
            public static int X = 0;
            public static int Y = 0;
            public static Direction Facing = Direction.NORTH;
            public static List<Point> PointsVisited = new List<Point>();
            public static Point FirstPointRevisited = Point.Empty;
        }

        public static void Run(string input) {
            string[] _input = input.Split(',').Select(x => x.Trim()).ToArray();

            foreach (string s in _input) {
                var _s = int.Parse(new String(s.ToCharArray().Skip(1).ToArray()));
                RotatePosition(s[0]);
                MovePosition(_s);
            }

            Console.WriteLine(String.Format("After running commands, output is as: X:{0} Y:{1} Facing:{2}", Position.X, Position.Y, Position.Facing.ToString()));
            // Assume previous position: X: 0, Y: 0
            // taxicab (p1, p2) and (q1, q2) IS (p1 - q1) + (p2 - q2)
            // .. therefore
            //int shortestDistance = (0 - Position.X) + (0 - Position.Y);
            int shortestDistance = Math.Abs(Position.X) + Math.Abs(Position.Y);
            Console.WriteLine(String.Format("Shortest Distance: {0}", shortestDistance.ToString())); 
        }

        public static void RunPart2(string input) {
            string[] _input = input.Split(',').Select(x => x.Trim()).ToArray();

            foreach (string s in _input) {
                var _s = int.Parse(new String(s.ToCharArray().Skip(1).ToArray()));
                RotatePosition(s[0]);
                MovePosition(_s);
            }

            if (!Position.FirstPointRevisited.IsEmpty) {
                int shortestDistance = Math.Abs(Position.FirstPointRevisited.X) + Math.Abs(Position.FirstPointRevisited.Y);
                Console.WriteLine(String.Format("After running commands, output is as: X:{0} Y:{1}", Position.FirstPointRevisited.X, Position.FirstPointRevisited.Y));
                Console.WriteLine(String.Format("Shortest Distance: {0}", shortestDistance.ToString()));
            }
            else {
                Console.WriteLine("Part 2 failed, there was no point visited twice. Check code or input");
            }
        }

        public static void AllPointsBetweenPositions() {
            switch (Position.Facing) {
                case Direction.NORTH:
                    for (int i = Position.PreviousY; i < Position.Y; i++) {
                        Point p = new Point(Position.X, i);
                        CheckPoint(p);
                    }
                    break;
                case Direction.SOUTH:
                    //x has changed all points between previous x and this x
                    for (int i = Position.Y; i > Position.PreviousY; i--) {
                        Point p = new Point(Position.X, i);
                        CheckPoint(p);
                    }
                    break;
                case Direction.EAST:
                    //y has changed
                    for (int i = Position.PreviousX; i < Position.X; i++) {
                        Point p = new Point(i, Position.Y);
                        CheckPoint(p);
                    }
                    break;
                case Direction.WEST:
                    for (int i = Position.X; i > Position.PreviousX; i--) {
                        Point p = new Point(i, Position.Y);
                        CheckPoint(p);
                    }
                    break;
            }
        }

        public static void CheckPoint(Point p) {
            Position.PointsVisited.Add(p);
            if (Position.FirstPointRevisited.IsEmpty && Position.PointsVisited.Contains(p)) {
                Position.FirstPointRevisited = p;
            }
        }

        public static void MovePosition(int s) {
            switch (Position.Facing) {
                case Direction.NORTH:
                    for (int i = 0; i < s; i++) {
                        Point p = new Point(Position.X, (Position.Y + i));
                        if (Position.PointsVisited.Contains(p) && Position.FirstPointRevisited.IsEmpty) {
                            Position.FirstPointRevisited = p;
                            Position.PointsVisited.Add(p);
                        }
                        else {
                            Position.PointsVisited.Add(p);
                        }
                    }
                    Position.Y += s;
                    break;
                case Direction.EAST:
                    for (int i = 0; i < s; i++) {
                        Point p = new Point((Position.X + i), Position.Y);
                        if (Position.PointsVisited.Contains(p) && Position.FirstPointRevisited.IsEmpty) {
                            Position.FirstPointRevisited = p;
                            Position.PointsVisited.Add(p);
                        }
                        else {
                            Position.PointsVisited.Add(p);
                        }
                    }
                    Position.X += s;
                    break;
                case Direction.SOUTH:
                    for (int i = 0; i < s; i++) {
                        Point p = new Point(Position.X, (Position.Y - i));
                        if (Position.PointsVisited.Contains(p) && Position.FirstPointRevisited.IsEmpty) {
                            Position.FirstPointRevisited = p;
                            Position.PointsVisited.Add(p);
                        }
                        else {
                            Position.PointsVisited.Add(p);
                        }
                    }
                    Position.Y -= s;
                    break;
                case Direction.WEST:
                    for (int i = 0; i < s; i++) {
                        Point p = new Point((Position.X - i), Position.Y);
                        if (Position.PointsVisited.Contains(p) && Position.FirstPointRevisited.IsEmpty) {
                            Position.FirstPointRevisited = p;
                            Position.PointsVisited.Add(p);
                        }
                        else {
                            Position.PointsVisited.Add(p);
                        }
                    }
                    Position.X -= s;
                    break;
            }
        }

        public static void RotatePosition(char d) {
            if (d == 'R') {
                switch (Position.Facing) {
                    case Direction.NORTH:
                        Position.Facing = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Position.Facing = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Position.Facing = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Position.Facing = Direction.NORTH;
                        break;
                }
            }
            else {
                switch (Position.Facing) {
                    case Direction.NORTH:
                        Position.Facing = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Position.Facing = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Position.Facing = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Position.Facing = Direction.NORTH;
                        break;
                }
            }
        }
    }
}
