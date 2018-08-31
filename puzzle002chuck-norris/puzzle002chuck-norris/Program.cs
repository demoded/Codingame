using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/ide/puzzle/chuck-norris
Here is the encoding principle:
    The input message consists of ASCII characters (7-bit)
    The encoded output message consists of blocks of 0
    A block is separated from another block by a space
    Two consecutive blocks are used to produce a series of same value bits (only 1 or 0 values):
    - First block: it is always 0 or 00. If it is 0, then the series contains 1, if not, it contains 0
    - Second block: the number of 0 in this block is the number of bits in the series

Example 1:
    Let’s take a simple example with a message which consists of only one character: Capital C. C in binary is represented as 1000011, so with Chuck Norris’ technique this gives:
    0 0 (the first series consists of only a single 1)
    00 0000 (the second series consists of four 0)
    0 00 (the third consists of two 1)
    So C is coded as: 0 0 00 0000 0 00

Example 2:
    Encode the message CC (i.e. the 14 bits 10000111000011) :
    0 0 (one single 1)
    00 0000 (four 0)
    0 000 (three 1)
    00 0000 (four 0)
    0 00 (two 1)
    So CC is coded as: 0 0 00 0000 0 000 00 0000 0 00
*/

namespace puzzle002chuck_norris
{
    class Program
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();
            //string MESSAGE = "C"; DEBUG PURPOSES
            string binary = "";

            for (int i = 0; i < MESSAGE.Length; i++)
            {
                binary += Convert.ToString((int)MESSAGE[i], 2).PadLeft(7, '0');
            }

            char prev = (char)0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == prev)
                {
                    Console.Write("0");
                }
                else
                {
                    Console.Write(i==0 ? "" : " ");
                    if (binary[i] == '0')
                    {
                        Console.Write("00 0");
                    }
                    else if (binary[i] == '1')
                    {
                        Console.Write("0 0");
                    }
                }                    

                prev = binary[i];
            }

            Console.WriteLine("");
        }
    }
}
