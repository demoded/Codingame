namespace Puzzle017SixDegreesOfKevinBacon.Tests
{
    public class SolutionTests
    {
        [Fact]
        public void Test_1()
        {
            string input = @"Elvis Presley
3
Change of Habit: Elvis Presley, Mary Tyler Moore, Barbara McNair, Jane Elliot, Ed Asner
JFK: Kevin Costner, Kevin Bacon, Tommy Lee Jones, Laurie Metcalf, Gary Oldman, Ed Asner
Sleepers: Kevin Bacon, Jason Patric, Brad Pitt, Robert De Niro, Dustin Hoffman";

            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal(2, result);
            }
        }

        [Fact]
        public void Test_2()
        {
            string input = @"Kevin Bacon
4
The Air I Breathe: Brendan Fraser, Sarah Michelle Gellar, Andy Garcia, Kevin Bacon
Balto: Kevin Bacon, Bob Hoskins, Bridget Fonda, Jim Cummings
Grindhouse: Kurt Russell, Zoë Bell, Rosario Dawson, Vanessa Ferlito, Sydney Tamiia Poitier, Tracie Thoms, Rose McGowan, Mary Elizabeth Winstead, Tom Savini
Sleepers: Kevin Bacon, Jason Patric, Brad Pitt, Robert De Niro, Dustin Hoffman";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal(0, result);
            }
        }

        [Fact]
        public void Test_3()
        {
            string input = @"Parnell Lewis
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
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal(6, result);
            }
        }
    }
}
