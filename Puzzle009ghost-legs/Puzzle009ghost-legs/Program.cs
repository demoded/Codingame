using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/ide/puzzle/ghost-legs
Ghost Legs is a kind of lottery game common in Asia. It starts with a number of vertical lines. 
Between the lines there are random horizontal connectors binding all lines into a connected diagram, 
like the one below.

A  B  C
|  |  |
|--|  |
|  |--|
|  |--|
|  |  |
1  2  3

To play the game, a player chooses a line in the top and follow it downwards. When a horizontal connector is encountered, 
he must follow the connector to turn to another vertical line and continue downwards. 
Repeat this until reaching the bottom of the diagram.

In the example diagram, when you start from A, you will end up in 2. Starting from B will end up in 1. 
Starting from C will end up in 3. It is guaranteed that every top label will map to a unique bottom label.

Given a Ghost Legs diagram, find out which top label is connected with which bottom label. List all connected pairs.

*/

namespace Puzzle009ghost_legs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]);
            int H = int.Parse(inputs[1]);
            Dictionary<char, int> header = new Dictionary<char, int>();
            char[] footer = { };
            for (int i = 0; i < H; i++)
            {
                string line = Console.ReadLine();

                if (i == 0)
                {
                    //read header indexes
                    var h = line.Except(" ");
                    header = h.Select((value, index) => new { value, index }).ToDictionary(pair => pair.value, pair => pair.index);
                }

                //take header state snapshot to skip double move in some cases
                var headerState = new Dictionary<char, int>(header);

                //loop through line, picking every 3rd character
                for (int c = 0; c < line.Length; c += 3)
                {
                    //if right symbol is '-' move index to the next column
                    if (c < line.Length - 1 && line[c + 1] == '-')
                    {
                        var headerLoop = headerState.Where(t => t.Value == c / 3).ToList();
                        foreach (var h in headerLoop)
                        {
                            header.Remove(h.Key);
                            header.Add(h.Key, h.Value + 1);
                        }
                    }
                    //if left symbol is '-' move index to the previous column
                    else if (c > 0 && line[c - 1] == '-')
                    {
                        var headerLoop = headerState.Where(t => t.Value == c / 3).ToList();
                        foreach (var h in headerLoop)
                        {
                            header.Remove(h.Key);
                            header.Add(h.Key, h.Value - 1);
                        }
                    }
                }

                if (i == H - 1)
                {
                    //read footer indexes
                    footer = line.Except(" ").ToArray();
                }
            }

            //for every heder letter show footers character in calculated position
            foreach (var h in header)
            {
                Console.WriteLine(h.Key + footer[h.Value].ToString());
            }
        }
    }
}
