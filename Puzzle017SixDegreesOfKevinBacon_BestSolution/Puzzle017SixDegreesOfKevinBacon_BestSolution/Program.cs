using Puzzle017SixDegreesOfKevinBacon_BestSolution;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = @"Parnell Lewis
10
Mr. 3000: Bernie Mac, Angela Bassett, Brian J. White, Chris Noth, Tony Lee Gratz
Wasted: David Kopriva, Alex Wilder, A.J. Laird, Oliver Grant, Natalie Matthai, Michael Oilar
My One and Only: Renée Zellweger, Logan Lerman, Kevin Bacon, Chris Noth
Slice: Asha Coy, Francis Faye, David Kopriva, Barrett Lione-Seaton
Chained to a Cowboy: Monty Kane, Tyree Jensen, Tony Lee Gratz, Michael Oilar
True to Form: Parnell Lewis, Kelly Higgs, Asha Coy, Kiera Knightley
Cop Car: Kevin Bacon, James Freedson-Jackson, Hays Wellford, Shea Whigham
Apollo 13: Tom Hanks, Bill Paxton, Kevin Bacon, Gary Sinise
Crazy, Stupid, Love.: Steve Carell, Ryan Gosling, Julianne Moore, Emma Stone, Kevin Bacon
The Notebook: Rachel McAdams, Ryan Gosling, James Garner, Gena Rowlands";

        using (var reader = new StringReader(input))
        {
            Console.SetIn(reader);
            Console.WriteLine(QueuesSolution.Run());
        }        
    }
}