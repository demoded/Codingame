using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///     Final task from https://www.codingame.com/playgrounds/345/c-linq-background-topics/welcome
/// </summary>
namespace Linq_CustomMethod
{
    public delegate int TransformationFunction(int n);

    public static class LinqTriaining
    {
        public static IEnumerable<int> Transform(this IEnumerable<int> input, TransformationFunction tf)
        {
            foreach (var n in input)
            {
                yield return tf(n);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 10, 20, 30 };
            var res = list.Transform(x => x / 10);

            Console.WriteLine("Source: " + string.Join(",", list.ToArray()));
            Console.WriteLine("Result: " + string.Join(",", res.ToArray()));
        }
    }
}
