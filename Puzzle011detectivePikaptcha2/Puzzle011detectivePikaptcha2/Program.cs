using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Puzzle011detectivePikaptcha2
{
    public class Program
    {
        public static List<Vector> DirectionVectors = new List<Vector>
        {
            new Vector(0,-1),
            new Vector(1,0),
            new Vector(0,1),
            new Vector(-1,0),
        };

        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            char[][] field = new char[height][];

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine();
                field[i] = line.ToCharArray();
            }
            string followSide = Console.ReadLine();
            for (int i = 0; i < height; i++)
            {

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                Console.WriteLine("#####");
            }
        }
    }
}
