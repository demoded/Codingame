using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Casablanca’s hippodrome is organizing a new type of horse racing: duals. During a dual, only two horses will participate in the race. In order for the race to be interesting, it is necessary to try to select two horses with similar strength.

Write a program which, using a given number of strengths, identifies the two closest strengths and shows their difference with an integer (≥ 0).
Input
    Line 1: Number N of horses
    The N following lines: the strength Pi of each horse. Pi is an integer.

Output
The difference D between the two closest strengths. D is an integer greater than or equal to 0. 

Test case
Input
    3
    5
    8
    9

Output
    1
*/

namespace Puzzle005horse_racing_duals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> strengthDiff = new List<int>();
            List<int> horses = new List<int>();
            int prev = 0;

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int pi = int.Parse(Console.ReadLine());
                horses.Add(pi);
            }

            horses.Sort();
            for (int i=0; i < horses.Count; i++)
            { 
                if (i == 0)
                {
                    prev = horses[i];
                }
                else
                {
                    strengthDiff.Add(Math.Abs(horses[i] - prev));
                    prev = horses[i];
                }
            }

            strengthDiff.Sort();
            Console.WriteLine(strengthDiff.FirstOrDefault().ToString());
        }
    }

    /**********************************
     Some solutions to learn from

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> pi = new List<int>();   
        for (int i = 0; i < N; i++)
            pi.Add(int.Parse(Console.ReadLine()));
        
        int minDelta = pi.OrderByDescending(x=>x).Zip(pi.OrderByDescending(x=>x).Skip(1),(current,next) => current - next).Min();       
        Console.WriteLine(minDelta);
    }
    ************************************
    static void Main(string[] args)
    {        
        List<int> strengths = Enumerable
                    .Range(0, int.Parse(Console.ReadLine()))
                    .Select(i => int.Parse(Console.ReadLine()))
                    .OrderBy(i => i)
                    .ToList();
                    
        Console.WriteLine(strengths.Select((i, index) => index > 0 ? i - strengths[index - 1] : int.MaxValue).Min());
    }
    */
}
