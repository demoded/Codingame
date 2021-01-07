using System;
using System.IO;
using Xunit;

namespace Puzzle014LostChild1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void LostInPlayground()
        {
            string testcase = string.Format("..........{0}M....C....{0}..........{0}..........{0}..........{0}..........{0}..........{0}..........{0}..........{0}..........", Environment.NewLine);
            string expected = string.Format("50km", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void LostInParis()
        {
            string testcase = string.Format("..........{0}M#........{0}#C##......{0}..........{0}..........{0}..........{0}..........{0}..........{0}..........{0}..........", Environment.NewLine);
            string expected = string.Format("120km", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void LostInJungle()
        {
            string testcase = string.Format("##########{0}#...#C...#{0}#...##...#{0}###.#..###{0}#.##M#...#{0}#.....#..#{0}#.....#..#{0}#.....#..#{0}#........#{0}##########", Environment.NewLine);
            string expected = string.Format("160km", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void LostInMazeRunner()
        {
            string testcase = string.Format("##########{0}#..M#C...#{0}#...##...#{0}###..#.###{0}#.##.#...#{0}#.....#..#{0}#.....#..#{0}#.....#..#{0}#........#{0}##########", Environment.NewLine);
            string expected = string.Format("200km", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void LostInSpace()
        {
            string testcase = string.Format("##########{0}#...#....#{0}#.C.#.#..#{0}###.#..###{0}#M#......#{0}#.###.#..#{0}#.#....#.#{0}#..#.##..#{0}#........#{0}##########", Environment.NewLine);
            string expected = string.Format("170km", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        string RunTest(string _in)
        {
            string result;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(_in))
                {
                    Console.SetIn(sr);
                    Puzzle014LostChild1.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
