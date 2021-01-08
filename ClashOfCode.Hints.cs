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
