using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test01_A_Small_Chamber()
        {
            /*
            5 3
            0000#
            #0#00
            00#0#

            1321#
            #2#21
            12#1#
            */
            string testcase = string.Format("5 3{0}0000#{0}#0#00{0}00#0#", Environment.NewLine);
            string expected = string.Format("1322#{0}#2#31{0}12#1#", Environment.NewLine);

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
                    Puzzle011detectivePikaptcha1.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
