﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/ide/puzzle/the-river-i-
A digital river is a sequence of numbers where every number is followed by the same number plus the sum of its digits. 
In such a sequence 123 is followed by 129 (since 1 + 2 + 3 = 6), which again is followed by 141.
We call a digital river river K, if it starts with the value K.
For example, river 7 is the sequence beginning with {7, 14, 19, 29, 40, 44, 52, ... } 
       and river 471 is the sequence beginning with {471, 483, 498, 519, ... }.
Digital rivers can meet. This happens when two digital rivers share the same values. River 32 meets river 47 at 47, while river 471 meets river 480 at 519.
Given two meeting digital rivers print out the meeting point. 

Test case:
    Input
    32
    47

    Output
    47
*/

namespace Puzzle007the_river
{
    class Program
    {
        static void Main(string[] args)
        {
            long r1 = long.Parse(Console.ReadLine());
            long r2 = long.Parse(Console.ReadLine());

            while (r1 != r2)
            {
                if (r1 < r2)
                    r1 = nextRiverValue(r1);
                else
                    r2 = nextRiverValue(r2);
            }

            Console.WriteLine(r1.ToString());
        }

        static long nextRiverValue(long _r)
        {
            long ret = 0;
            string s = _r.ToString();
            foreach (char c in s)
                ret += c - 48;

            return ret + _r;
        }
    }
}

// sum via LINQ r1.ToString().ToList().ForEach(d => r1 += d - '0');