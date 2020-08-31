using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /* 
            Input:
            5 3
            >000#
            #0#00
            00#0#
            L

            Result:
            1322#
            #2#31
            12#1#
            */
            string testcase = string.Format("5 3{0}>000#{0}#0#00{0}00#0#{0}L", Environment.NewLine);
            string expected = string.Format("1322#{0}#2#31{0}12#1#", Environment.NewLine);

            Assert.AreEqual<string>(expected, RunTest(testcase));
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
            9 3
            #00###000
            0000<0000
            000##0000
            R

            #11###000
            112210000
            111##0000
            */
            string testcase = string.Format("9 3{0}#00###000{0}0000<0000{0}000##0000{0}R", Environment.NewLine);
            string expected = string.Format("#11###000{0}112210000{0}111##0000", Environment.NewLine);

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
                    Puzzle011detectivePikaptcha2.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
