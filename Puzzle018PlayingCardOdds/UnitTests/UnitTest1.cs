namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("7H", 1)]
        [InlineData("45C", 2)]
        [InlineData("7", 4)]
        [InlineData("H", 13)]
        [InlineData("7CDHS", 4)]
        [InlineData("JQKA", 16)]
        public void CalcNumberOfCards(string cards, int expected)
        {
            var result = Solution.ParseCards(cards).Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test1()
        {
            string input = @"1 1
45C
7H";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("2%", result);
            }
        }

        [Fact]
        public void Test2()
        {
            string input = @"1 2
45C
7
H";

            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("32%", result);
            }
        }

        [Fact]
        public void Test3_CrazyEights()
        {
            string input = @"1 1
JQKA
8";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("11%", result);
            }
        }

        [Fact]
        public void Test4_Impossible()
        {
            string input = @"2 3
7
H
7H
7D
KH";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("0%", result);
            }
        }
        [Fact]
        public void Test5_A_Lock()
        {
            string input = @"3 2
CH
23456789
TDS
ADS
JQK";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("100%", result);
            }
        }

        [Fact]
        public void Test6_Mixture()
        {
            string input = @"7 3
234C
567H
89TCH
JQKD
25JS
369D
A
JQKAS
2469H
4TCD";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("22%", result);
            }
        }
        [Fact]
        public void Test7_Decimation()
        {
            string input = @"4 2
23456789T
CD
ACHS
23KH
KCS
TQH";
            using (var sr = new StringReader(input))
            {
                Console.SetIn(sr);
                var result = Solution.Run();
                Assert.Equal("40%", result);
            }
        }
    }
}
