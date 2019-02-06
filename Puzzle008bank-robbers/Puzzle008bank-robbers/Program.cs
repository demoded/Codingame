using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
A gang of R foolish robbers decides to heist a bank. In the bank there are V vaults (indexed from 0 to V - 1). 
The robbers have managed to extract some information from the bank's director:
- The combination of a vault is composed of C characters (digits/vowels).
- The first N characters consist of digits from 0 to 9.
- The remaining characters consist of vowels (A, E, I, O, U).
- C and N may be the same or different for different vaults.

All the robbers work at the same time. A robber can work on one vault at a time, and a vault can be worked on by only one robber. 
Robbers deal with the different vaults in increasing order.
A robber tries the combinations at the speed of 1 combination per second. He tries all the possible combinations, 
i.e. he continues to try the untried combinations even after he has found the correct combination. 
Once he finishes one vault, he moves on to the next available vault, 
that is the vault with the smallest index among all the vaults that have not been worked on yet. 
The heist is finished when the robbers have worked on all the vaults.

Assume it takes no time to move from one vault to another.
You have to output the total time the heist takes. 

Test case:
    Input
    1
    1
    3 1

    Output:
    250
*/

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
