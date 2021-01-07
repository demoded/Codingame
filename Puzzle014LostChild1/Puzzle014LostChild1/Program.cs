using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

//https://www.codingame.com/ide/puzzle/the-lost-child-episode-1

namespace Puzzle014LostChild1
{
    public class Program
    {
        public class Waypoint
        {
            public int x;
            public int y;
            public int distance;
        }

        public static void Main(string[] args)
        {
            List<Waypoint> path = new List<Waypoint>();
            char[,] field = new char[10, 10];
            int res = -1;

            for (int i = 0; i < 10; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 10; ++j)
                {
                    field[i, j] = row[j];
                    if (row[j] == 'C')
                    {
                        var w = new Waypoint { x = j, y = i, distance = 0 };
                        path.Add(w);
                    }
                }
            }

            while (res < 0)
            {
                var tempWaypoints = new List<Waypoint>();
                foreach (var w in path)
                {
                    //Mother found
                    if (field[w.y, w.x] == 'M')
                    {
                        res = w.distance;
                        break;
                    }

                    //skip walls and processed elements
                    if (field[w.y, w.x] == '#' || field[w.y, w.x] == '*')
                    {
                        continue;
                    }

                    //check left cell
                    if (w.x > 0)
                    {
                        tempWaypoints.Add(new Waypoint { x = w.x - 1, y = w.y, distance = w.distance + 10 });
                    }

                    //check right cell
                    if (w.x < 9)
                    {
                        tempWaypoints.Add(new Waypoint { x = w.x + 1, y = w.y, distance = w.distance + 10 });
                    }

                    //check cell above
                    if (w.y > 0)
                    {
                        tempWaypoints.Add(new Waypoint { x = w.x, y = w.y - 1, distance = w.distance + 10 });
                    }

                    //check cell below
                    if (w.y < 9)
                    {
                        tempWaypoints.Add(new Waypoint { x = w.x, y = w.y + 1, distance = w.distance + 10 });
                    }

                    field[w.y, w.x] = '*';
                }
                if (res < 0)
                {
                    //Mother not found, add new waypoints to list
                    foreach (var w in tempWaypoints)
                    {
                        path.Add(w);
                    }
                }
                else
                {
                    //Mother found
                    Console.WriteLine($"{res}km");
                }
            }
        }
    }
}