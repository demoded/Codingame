Convert.ToString(n, 2)      //To binary
Convert.ToString(n, 8)      //To octal
Convert.ToString(n, 16)     //To hexadecimal

//linq to read from Console
var a = Enumerable.Range(0, N).Select(_ => Console.ReadLine().Split()).ToList();

//count total number of the same charachter in line //100020300001 -> 8
return s.ToCharArray().OrderBy(o => o).GroupBy(g => g).OrderByDescending(oo => oo.Count()).FirstOrDefault().Count();

//find longest consequtive group of '0'  //100020300001 -> 4
return N.Split("123456789".ToCharArray()).OrderByDescending(o => o.Count()).FirstOrDefault().Count();

--------------------------------------------------------------------------------------
public static bool IsPrime(int number)
{
    if (number == 1) return false;
    if (number == 2) return true;

    var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

    for (int i = 2; i <= limit; ++i)
        if (number % i == 0)
            return false;
    return true;
}
--------------------------------------------------------------------------------------

//Mountain task
/*
   /\   
  /  \    /\  
 /    \  /  \  /\ 
/      \/    \/  \/\
*/

for (int i = 0; i < N; i++)
{
    string s = "";
    for (int j = N; j >= N - i; j--)
    {
        s += new string(' ', N - i - 1);
        s += '/' + new string(' ', 2 * i - 2 * (N - j)) + '\\';
        s += new string(' ', N - i - 1);
    }
    Console.WriteLine(s);
}
--------------------------------------------------------------------------------------
//HI = 15
//ZZZZZZ = 150
//AAAA-= = 0

using System;
using System.Linq;

String s = "ZZZZZZ";
var a = s.Where(_ => Char.IsLetter(_)).ToArray();
int res = 0;

foreach (var c in a)
{
    res += c - 64;
}
Console.WriteLine(res - a.Length);
--------------------------------------------------------------------------------------

