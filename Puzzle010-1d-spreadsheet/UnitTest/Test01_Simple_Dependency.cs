using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test01_Simple_Dependency()
        {
            /*
                2
                VALUE 3 _
                ADD $0 4
            */
            string testcase = string.Format("2{0}VALUE 3 _{0}ADD $0 4", Environment.NewLine);
            string expected = string.Format("3{0}7", Environment.NewLine);

            Assert.AreEqual<string>(expected, RunTest(testcase));
        }
        [TestMethod]
        public void Test09_Diamond_Dependency()
        {
            /* Input
            4
            SUB $1 4
            VALUE 3 _
            ADD 8 $1
            MULT $0 $2
            */

            /* Output
            -1
            3
            11
            -11
            */
            string testcase = string.Format("4{0}SUB $1 4{0}VALUE 3 _{0}ADD 8 $1{0}MULT $0 $2", Environment.NewLine);
            string expected = string.Format("-1{0}3{0}11{0}-11", Environment.NewLine);

            Assert.AreEqual<string>(expected, RunTest(testcase));
        }

        [TestMethod]
        public void Test11_Accounting_Hard1()
        {
            string testcase = string.Format("100{0}SUB $47 $9{0}SUB 44 $59{0}ADD $97 $67{0}ADD $1 $1{0}SUB $57 $67{0}ADD $47 $97{0}ADD $59 $59{0}SUB $50 $83{0}SUB $3 $93{0}SUB $4 $74{0}SUB $38 $0{0}ADD $29 $96{0}SUB $46 $97{0}SUB $5 $98{0}SUB $87 $66{0}SUB $86 $25{0}SUB $1 $98{0}SUB $84 $56{0}ADD $38 $78{0}ADD $46 $34{0}ADD $5 $76{0}SUB $3 $93{0}ADD $19 $31{0}ADD $97 $77{0}VALUE $54 _{0}SUB $6 $6{0}ADD $98 $2{0}ADD $59 $67{0}SUB $36 $86{0}SUB $98 $26{0}SUB $16 $7{0}VALUE $67 _{0}ADD $11 $84{0}VALUE $63 _{0}ADD $3 $6{0}VALUE $44 _{0}SUB $68 $5{0}ADD $7 $58{0}ADD $50 $82{0}ADD $88 -936{0}ADD $43 $47{0}ADD $58 842{0}SUB $80 $46{0}SUB $33 $96{0}SUB $43 $46{0}ADD $2 $8{0}ADD $59 $9{0}VALUE $2 _{0}SUB $65 $30{0}ADD 135 $65{0}ADD $71 $93{0}ADD $96 $67{0}ADD $6 $38{0}SUB $5 $8{0}SUB $67 $1{0}ADD $4 $71{0}VALUE $67 _{0}SUB $93 $54{0}SUB $51 $3{0}ADD 993 -871{0}ADD $6 $6{0}SUB $71 $65{0}ADD $25 $60{0}VALUE $59 _{0}ADD $6 $51{0}SUB $63 $97{0}VALUE $67 _{0}SUB 3 $59{0}ADD $88 $3{0}SUB $83 $53{0}SUB $50 $49{0}ADD $60 865{0}VALUE $53 _{0}SUB $29 $44{0}SUB $96 $25{0}ADD $21 $77{0}SUB $14 $30{0}SUB $27 $50{0}ADD $51 $5{0}SUB $40 $72{0}VALUE $90 _{0}ADD $87 $42{0}ADD $9 $47{0}SUB $97 $1{0}ADD $21 $44{0}ADD $78 $94{0}ADD $21 $71{0}ADD -730 $67{0}SUB $21 $89{0}SUB $83 $25{0}ADD $47 $84{0}ADD $6 $65{0}ADD $32 $22{0}ADD $27 $59{0}ADD $63 $11{0}ADD $65 $60{0}ADD $59 $6{0}SUB $1 $27{0}ADD $27 $83{0}SUB $19 $61", Environment.NewLine);
            string expected = string.Format("-119{0}-78{0}-200{0}-156{0}285{0}-281{0}244{0}1481{0}-281{0}-81{0}1316{0}566{0}122{0}-281{0}-730{0}1072{0}-78{0}-447{0}1163{0}129{0}548{0}-281{0}10{0}-1556{0}-41{0}0{0}-200{0}3{0}-1225{0}200{0}-1559{0}-119{0}0{0}122{0}88{0}-285{0}-153{0}1884{0}1197{0}-1214{0}-444{0}1245{0}-807{0}-244{0}-285{0}-481{0}41{0}-200{0}1762{0}338{0}1478{0}247{0}1441{0}0{0}-41{0}1638{0}-119{0}166{0}403{0}122{0}488{0}1150{0}488{0}122{0}491{0}203{0}-119{0}-119{0}-434{0}-3{0}1140{0}1353{0}0{0}485{0}366{0}-1756{0}829{0}-1475{0}-34{0}-444{0}-766{0}-1656{0}-281{0}-3{0}-566{0}654{0}1072{0}-849{0}-278{0}-3{0}-766{0}447{0}10{0}125{0}688{0}691{0}366{0}-81{0}0{0}-1021", Environment.NewLine);
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
                    Puzzle010_1d_spreadsheet.Program.Main(new string[] { });

                    result = sw.ToString().Trim();
                }
            }

            return result;
        }
    }
}
