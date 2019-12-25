using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test01_Simple_Sample()
        {
            string testcase = string.Format("7 7{0}A  B  C{0}|  |  |{0}|--|  |{0}|  |--|{0}|  |--|{0}|  |  |{0}1  2  3", Environment.NewLine);
            string expected = string.Format("A2{0}B1{0}C3", Environment.NewLine);

            Assert.AreEqual<string>(expected, RunTest(testcase));
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
                    Puzzle009ghost_legs.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
