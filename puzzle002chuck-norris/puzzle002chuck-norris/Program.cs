using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
