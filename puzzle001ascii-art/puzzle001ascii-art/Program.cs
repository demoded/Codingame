using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 https://www.codingame.com/ide/puzzle/ascii-art
 ​Your mission is to write a program that can display a line of text in ASCII art in a style you are given as input.
 Input
    Line 1: the width L of a letter represented in ASCII art. All letters are the same width.
    Line 2: the height H of a letter represented in ASCII art. All letters are the same height.
    Line 3: The line of text T, composed of N ASCII characters.
    Following lines: the string of characters ABCDEFGHIJKLMNOPQRSTUVWXYZ? Represented in ASCII art.

 Output
    The text T in ASCII art.
    The characters a to z are shown in ASCII art by their equivalent in upper case.
    The characters that are not in the intervals [a-z] or [A-Z] will be shown as a question mark in ASCII art.

 Constraints
    0 < L < 30
    0 < H < 30
    0 < N < 200

Test Case:
    Input
        4
        5
        MANHATTAN
         #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### 
        # # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # 
        ### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## 
        # # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       
        # # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  
    Output
        # #  #  ### # #  #  ### ###  #  ###  
        ### # # # # # # # #  #   #  # # # #  
        ### ### # # ### ###  #   #  ### # #  
        # # # # # # # # # #  #   #  # # # #  
        # # # # # # # # # #  #   #  # # # # 
*/

namespace puzzle001ascii_art
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            string[] charset = new string[H];
            string T = Console.ReadLine();
            for (int i = 0; i < H; i++)
            {
                string ROW = Console.ReadLine();
                charset[i] = ROW;
            }

            List<int> positions = new List<int>(); //list of symbols positions in charset
            
            //loop through line of text
            for (int i = 0; i < T.Length; i++)
            {
                char c = Char.ToUpper(T[i]);

                //letter index in alphabet
                int letterIdx = c - 'A';

                //add letters positions in charset
                if (letterIdx >= 0 && letterIdx < 26)
                {
                    for (int l = 0; l < L; l++)
                    {
                        positions.Add(L * letterIdx + l);
                    }
                }
                else
                {
                    //add positions for questionmark    
                    for (int l = 0; l < L; l++)
                    {
                        positions.Add(L * 26 + l);
                    }
                }
            }
            for (int h = 0; h < H; h++)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    Console.Write(charset[h][positions[i]]);
                }
                Console.WriteLine("");
            }
        }
    }
}
