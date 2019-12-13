using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace Dag13
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var maze = JsonSerializer.Deserialize<List<List<Room>>>(File.ReadAllText("Input\\Maze.txt"), options);

            var robo1 = Robo1(maze);
            var robo2 = Robo2(maze);

            Console.WriteLine(robo1 > robo2 ? robo1 - robo2 : robo2 - robo1);
        }

        public static int Robo1(List<List<Room>> maze)
        {
            var path = new Stack<Room>();
            path.Push(maze[0][0]);
            var visitedRooms = new HashSet<Room>();

            while (path.Peek().X != 499 || path.Peek().Y != 499)
            {
                var currentRoom = path.Peek();
                visitedRooms.Add(currentRoom);

                if (!currentRoom.Bottom && !visitedRooms.Contains(maze[currentRoom.Y + 1][currentRoom.X]))
                {
                    path.Push(maze[currentRoom.Y + 1][currentRoom.X]);
                }
                else if (!currentRoom.Right && !visitedRooms.Contains(maze[currentRoom.Y][currentRoom.X + 1]))
                {
                    path.Push(maze[currentRoom.Y][currentRoom.X + 1]);
                }
                else if (!currentRoom.Left && !visitedRooms.Contains(maze[currentRoom.Y][currentRoom.X - 1]))
                {
                    path.Push(maze[currentRoom.Y][currentRoom.X - 1]);
                }
                else if (!currentRoom.Top && !visitedRooms.Contains(maze[currentRoom.Y - 1][currentRoom.X]))
                {
                    path.Push(maze[currentRoom.Y - 1][currentRoom.X]);
                }
                else
                {
                    path.Pop();
                }
            }

            return visitedRooms.Count;
        }

        public static int Robo2(List<List<Room>> maze)
        {
            var path = new Stack<Room>();
            path.Push(maze[0][0]);
            var visitedRooms = new HashSet<Room>();

            while (path.Peek().X != 499 || path.Peek().Y != 499)
            {
                var currentRoom = path.Peek();
                visitedRooms.Add(currentRoom);

                if (!currentRoom.Right && !visitedRooms.Contains(maze[currentRoom.Y][currentRoom.X + 1]))
                {
                    path.Push(maze[currentRoom.Y][currentRoom.X + 1]);
                }
                else if (!currentRoom.Bottom && !visitedRooms.Contains(maze[currentRoom.Y + 1][currentRoom.X]))
                {
                    path.Push(maze[currentRoom.Y + 1][currentRoom.X]);
                }
                else if (!currentRoom.Left && !visitedRooms.Contains(maze[currentRoom.Y][currentRoom.X - 1]))
                {
                    path.Push(maze[currentRoom.Y][currentRoom.X - 1]);
                }
                else if (!currentRoom.Top && !visitedRooms.Contains(maze[currentRoom.Y - 1][currentRoom.X]))
                {
                    path.Push(maze[currentRoom.Y - 1][currentRoom.X]);
                }
                else
                {
                    path.Pop();
                }
            }

            return visitedRooms.Count;
        }

        public class Room
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Top { get; set; }
            public bool Left { get; set; }
            public bool Bottom { get; set; }
            public bool Right { get; set; }
        }
    }
}
