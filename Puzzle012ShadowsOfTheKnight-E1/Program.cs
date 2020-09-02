using System;

namespace Puzzle012ShadowsOfTheKnight_E1
{
    /*
    //https://www.codingame.com/ide/puzzle/shadows-of-the-knight-episode-1
    This is an interactive bot-like task, testing possible only on codingame
    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);
            int minx = 0, miny = 0;  //minimum possible cordinates
            int maxx = W;
            int maxy = H;

            // game loop
            while (N > 0)
            {
                N--;
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
                int dx = 0;
                int dy = 0; //direction of move
                foreach (char c in bombDir)
                {
                    if (c == 'U')
                    {
                        dy = -1;
                        maxy = Y0;
                    }
                    if (c == 'D')
                    {
                        dy = 1;
                        miny = Y0;
                    }
                    if (c == 'R')
                    {
                        dx = 1;
                        minx = X0;
                    }
                    if (c == 'L')
                    {
                        dx = -1;
                        maxx = X0;
                    }
                }

                X0 = X0 + dx * (int)Math.Ceiling((maxx - minx) / 2.0d);
                Y0 = Y0 + dy * (int)Math.Ceiling((maxy - miny) / 2.0d);
                Console.Error.WriteLine($"{X0} {Y0}");

                // the location of the next window Batman should jump to.
                Console.WriteLine($"{X0} {Y0}");
            }
        }
    }
}
