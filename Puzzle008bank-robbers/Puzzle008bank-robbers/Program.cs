using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle008bank_robbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int R = int.Parse(Console.ReadLine());
            int V = int.Parse(Console.ReadLine());
            int[] VaultCombinations = new int[V];
            int vaultIterator = 0;
            List<Int32> RobberTime = new List<Int32>();
            int total = 0, time = 0;

            RobberTime.InsertRange(0, new int[R].ToList());
            for (int i = 0; i < V; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int C = int.Parse(inputs[0]);
                int N = int.Parse(inputs[1]);

                VaultCombinations[i] = (int)Math.Pow(5, C - N) * (int)Math.Pow(10, N);
            }

            while (vaultIterator < V)
            {
                int zeroIndex = RobberTime.IndexOf(0);

                if (zeroIndex >= 0)
                {
                    //free robber available to take next vault
                    RobberTime[zeroIndex] = VaultCombinations[vaultIterator];
                    vaultIterator++;
                }
                else
                {
                    //all robbers are busy, count time and free the fastest robber
                    RobberTime.Sort();
                    time = RobberTime.First();
                    total += time;
                    RobberTime = RobberTime.Select(x => x - time).ToList(); //moment when I realised that LINQ not working with plain data types
                }
            }
            Console.WriteLine(total+RobberTime.Max());
        }
    }
}
