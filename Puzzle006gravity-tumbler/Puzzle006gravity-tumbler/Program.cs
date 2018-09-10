using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/ide/puzzle/gravity-tumbler
The program must output the result of tumbling a landscape a certain number of times.

Tumbling entails:
- rotating the landscape counterclockwise by 90°
- letting the hash bits # fall down

The map is composed of . and #.

Input:
    Line 1: two space-separated integers: the map width and height
    Line 2: the number count of tumbling actions to perform
    Next height lines: width characters (empty bits . and heavy bits #)
Output:
    If count is odd: width lines of height characters.
    If count is even: height lines of width characters.

Obviously, in both cases, the # are at the bottom.

Test case 1:
    Input
    17 5
    1
    .................
    .................
    ...##...###..#...
    .####..#####.###.
    #################

    Output
    ....#
    ....#
    ....#
    ....#
    ....#
    ...##
    ...##
    ...##
    ...##
    ...##
    ...##
    ..###
    ..###
    ..###
    ..###
    ..###
    ..###

Test case 2:
    Input
    17 5
    2
    .................
    .................
    ...##...###..#...
    .####..#####.###.
    #################

    .................
    .................
    ...........######
    .....############
    #################
*/

namespace Puzzle006gravity_tumbler
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            int count = int.Parse(Console.ReadLine()) % 4;
            int[] Xcount = new int[width];
            int[] Ycount = new int[height];

            for (int i = 0; i < height; i++)
            {
                string raster = Console.ReadLine();
                int rowCount = 0;
                for (int j = 0; j < raster.Length; j++)
                {
                    if (raster[j] == '#')
                    {
                        rowCount++;
                        Xcount[j] += 1;
                    }
                }
                Ycount[i] = rowCount;
            }

            switch (count)
            {
                case 1:
                case 3:
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            if (Ycount[j] >= width - i)
                                Console.Write('#');
                            else
                                Console.Write('.');
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                case 0:
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            if (Ycount[i] >= width - j)
                                Console.Write('#');
                            else
                                Console.Write('.');
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}

/*
LINQ based solutions for learning

class Solution {
    static void Main(string[] args) {
        string[] inputs = Console.ReadLine().Split(' ');
        int count = int.Parse(Console.ReadLine());
        var landscape = Enumerable.Range(0, int.Parse(inputs[1]))
            .Select(_ => Console.ReadLine().ToCharArray().ToList()).ToList();
            
        landscape = Enumerable.Range(0, count)
            .Aggregate(landscape, (current, _) => Tumble(ApplyGravity(current)));
            
        Console.WriteLine(string.Join(System.Environment.NewLine,
            landscape.Select(row => string.Join("", row))));
    }
    
    private static List<List<char>> ApplyGravity(List<List<char>> landscape) {
        return landscape
            .Select(row => row.OrderBy(_ => _).Reverse().ToList())
            .ToList();
    }
    
    private static List<List<char>> Tumble(List<List<char>> landscape) {
        return Enumerable.Range(0, landscape[0].Count)
            .Select(i => landscape.Select(row => row[i]).ToList())
            .ToList();
    }
} 

class Solution
{
    static void Main(string[] args)
    {
        // Read inputs
        int height = int.Parse(Console.ReadLine().Split(' ')[1]);
        int count = int.Parse(Console.ReadLine());
        var landscape = Enumerable.Range(0, height)
            .Select(h => Console.ReadLine().ToCharArray().OrderByDescending(c => c).ToList())
            .ToList();
        
        // Tumble
        for (int i = 0; i < count; i++) {
            var newLandscape = Enumerable
                .Range(0, landscape[0].Count)
                .Select(w => landscape.Select(l => l[w]).ToList())
                .ToList();
            landscape = newLandscape;
        }
        
        // Output tumbled results
        Console.WriteLine(string.Join("\n", landscape.Select(l => string.Join(string.Empty, l))));
    }
}
*/
