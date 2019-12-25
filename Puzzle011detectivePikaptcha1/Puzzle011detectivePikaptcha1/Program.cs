using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
You're given a grid filled with 0 and #, where 0 represents a passage, and # represents a wall: an impassable cell.
We're considering the 4-adjacency, meaning a cell has a maximum of 4 adjacent cells (a diagonal cell is not adjacent).
You must analyze the given grid and return it with a small transformation: 
for each empty cell, instead of a 0, you must return the number of its adjacent passable cells. 
For each impassable cell, you change nothing: you still return #. 
*/

namespace Puzzle011detectivePikaptcha1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string firstline = Console.ReadLine();
            //Console.Error.WriteLine(firstline);
            string[] inputs = firstline.Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            char[][] map = new char[height][];

            //read map
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                map[i] = line.ToCharArray();
                //Console.Error.WriteLine(line);
            }

            //count adjacent and print out every line
            for (int h = 0; h < height; h++)
            {
                string tempStr = string.Empty;
                for (int w = 0; w < width; w++)
                {
                    if (map[h][w] == '#')
                        tempStr += '#';
                    else
                        tempStr += CountAdjucentCells(h, w, map);
                }
                Console.WriteLine(tempStr);
            }
        }

        private static char CountAdjucentCells(int h, int w, char[][] map)
        {
            int count = 0;

            var maxh = map.Count()-1;
            var maxw = map[0].Count()-1;

            if (h > 0 && h < maxh)
            {
                count += map[h - 1][w] == '0' ? 1 : 0;
                count += map[h + 1][w] == '0' ? 1 : 0;
            }
            else if (h == 0)
                count += map[h + 1][w] == '0' ? 1 : 0;
            else
                count += map[h - 1][w] == '0' ? 1 : 0;

            if (w > 0 && w < maxw)
            {
                count += map[h][w - 1] == '0' ? 1 : 0;
                count += map[h][w + 1] == '0' ? 1 : 0;
            }
            else if (w == 0)
                count += map[h][w + 1] == '0' ? 1 : 0;
            else
                count += map[h][w - 1] == '0' ? 1 : 0;

            return count == 0 ? '#' : Convert.ToChar(count+48);
        }
    }
}
