using System;
using System.IO;
using Xunit;

namespace Puzzle013target_firing_Tests
{
    public class UnitTests
    {

        [Fact]
        public void StrongestFirst()
        {
            //2
            //FIGHTER 10 0 500
            //FIGHTER 10 0 800
            //3200

            string testcase = string.Format("2{0}FIGHTER 10 0 500{0}FIGHTER 10 0 800", Environment.NewLine);
            string expected = string.Format("3200", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void TankiestLast()
        {
            /*
             2
            CRUISER 50 5 150
            CRUISER 60 0 150
            1700
             */
            string testcase = string.Format("2{0}CRUISER 50 5 150{0}CRUISER 60 0 150", Environment.NewLine);
            string expected = string.Format("1700", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void StrongestAndTankiest()
        {
            /*
             2
            FIGHTER 36 2 60
            CRUISER 50 3 200
            2880
             */
            string testcase = string.Format("2{0}FIGHTER 36 2 60{0}CRUISER 50 3 200", Environment.NewLine);
            string expected = string.Format("2880", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void TheSwarm()
        {
            string testcase = string.Format("50{0}FIGHTER 26 6 1{0}CRUISER 14 3 3{0}CRUISER 25 6 4{0}CRUISER 13 5 4{0}CRUISER 19 7 3{0}FIGHTER 12 7 2{0}FIGHTER 21 0 2{0}FIGHTER 15 3 3{0}FIGHTER 26 1 1{0}CRUISER 21 4 3{0}FIGHTER 18 5 3{0}FIGHTER 30 0 2{0}CRUISER 20 8 3{0}FIGHTER 22 3 4{0}FIGHTER 6 6 3{0}CRUISER 13 5 2{0}CRUISER 11 2 3{0}CRUISER 14 1 4{0}FIGHTER 9 6 3{0}CRUISER 14 2 4{0}CRUISER 5 2 1{0}FIGHTER 9 3 2{0}FIGHTER 6 0 3{0}FIGHTER 13 0 1{0}CRUISER 19 1 1{0}FIGHTER 15 3 4{0}FIGHTER 8 1 4{0}CRUISER 9 7 1{0}CRUISER 14 5 2{0}FIGHTER 19 4 3{0}FIGHTER 15 0 1{0}FIGHTER 8 7 3{0}FIGHTER 26 0 4{0}FIGHTER 21 3 1{0}CRUISER 10 2 3{0}FIGHTER 20 6 2{0}FIGHTER 28 1 1{0}CRUISER 19 8 4{0}FIGHTER 14 8 3{0}CRUISER 24 1 4{0}CRUISER 17 4 2{0}FIGHTER 20 1 1{0}FIGHTER 23 4 3{0}FIGHTER 18 3 2{0}FIGHTER 17 3 4{0}CRUISER 5 3 4{0}CRUISER 18 2 2{0}FIGHTER 11 0 1{0}CRUISER 27 1 2{0}FIGHTER 19 0 3", Environment.NewLine);
            string expected = string.Format("212", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void NotTheShinyPaint()
        {
            string testcase = string.Format("10{0}FIGHTER 40 2 25{0}FIGHTER 40 2 25{0}FIGHTER 20 2 15{0}CRUISER 60 4 10{0}FIGHTER 25 0 20{0}FIGHTER 5 5 30{0}CRUISER 40 5 30{0}CRUISER 70 8 60{0}FIGHTER 25 6 10{0}FIGHTER 25 6 10", Environment.NewLine);
            string expected = string.Format("FLEE", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void CloseCall()
        {
            string testcase = string.Format("20{0}FIGHTER 35 10 10{0}FIGHTER 35 5 8{0}FIGHTER 25 5 10{0}CRUISER 10 5 6{0}CRUISER 45 5 8{0}CRUISER 75 0 6{0}CRUISER 60 5 8{0}FIGHTER 75 10 2{0}FIGHTER 60 0 4{0}FIGHTER 40 10 10{0}FIGHTER 80 0 12{0}FIGHTER 25 0 10{0}CRUISER 35 0 4{0}CRUISER 50 0 8{0}CRUISER 105 5 8{0}CRUISER 70 5 4{0}FIGHTER 45 5 6{0}CRUISER 30 0 4{0}FIGHTER 60 10 4{0}CRUISER 30 5 6", Environment.NewLine);
            string expected = string.Format("0", Environment.NewLine);

            Assert.Equal(expected, RunTest(testcase));
        }

        [Fact]
        public void TickleWars()
        {
            string testcase = string.Format("2{0}FIGHTER 15 20 1{0}CRUISER 20 15 1", Environment.NewLine);
            string expected = string.Format("4950", Environment.NewLine);

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
                    Puzzle013target_firing.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
