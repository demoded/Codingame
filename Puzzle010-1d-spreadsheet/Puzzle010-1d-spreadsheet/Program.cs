using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
https://www.codingame.com/training/easy/1d-spreadsheet
You are given a 1-dimensional spreadsheet. You are to resolve the formulae and give the value of all its cells.

Each input cell's content is provided as an operation with two operands arg1 and arg2.

There are 4 types of operations:
VALUE arg1 arg2: The cell's value is arg1, (arg2 is not used and will be "_" to aid parsing).
ADD arg1 arg2: The cell's value is arg1 + arg2.
SUB arg1 arg2: The cell's value is arg1 - arg2.
MULT arg1 arg2: The cell's value is arg1 × arg2.

Arguments can be of two types:
• Reference $ref: If an argument starts with a dollar sign, it is a interpreted as a reference and its value is equal to the value of the cell by that number ref, 0-indexed.
For example, "$0" will have the value of the result of the first cell.
Note that a cell can reference a cell after itself!

• Value val: If an argument is a pure number, its value is val.
For example: "3" will have the value 3.

There won't be any cyclic references: a cell that reference itself or a cell that references it, directly or indirectly.

Test case:
    Input
        2
        VALUE 3 _
        ADD $0 4
    Output
        3
        7
*/

namespace Puzzle010_1d_spreadsheet
{
    public class Program
    {
        class Cell
        {
            public string command;
            public string arg1;
            public string arg2;
            public string result;
        }

        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Cell> cells = new List<Cell>();

            //read input
            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                var inputs = s.Split(' ');
                Cell c = new Cell();
                c.command = inputs[0];
                c.arg1 = inputs[1];
                c.arg2 = inputs[2];
                c.result = string.Empty;

                if (c.command == "VALUE" && c.arg1[0] != '$')
                    c.result = c.arg1;

                cells.Add(c);
            }

            //cals cells
            do
            {
                Cell c = cells.FirstOrDefault(t => t.result == string.Empty);
                c.result = CalcCell(c, cells).ToString();
            } while (cells.Where(t => t.result == string.Empty).ToList().Count > 0);

            //output result
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(cells[i].result);
            }
        }

        static int CalcCell(Cell c, List<Cell> _cells)
        {
            int op1 = 0;
            int op2 = 0;
            int res = 0;

            if (c.arg1[0] == '$')
            {
                string refCell = c.arg1.Substring(1);
                int.TryParse(refCell, out int refCellInt);
                if (_cells[refCellInt].result == string.Empty)
                {
                    op1 = CalcCell(_cells[refCellInt], _cells);
                }
                else
                {
                    int.TryParse(_cells[refCellInt].result, out op1);
                }
            }
            else
            {
                int.TryParse(c.arg1, out op1);
            }

            if (c.arg2[0] == '$')
            {
                string refCell = c.arg2.Substring(1);
                int.TryParse(refCell, out int refCellInt);
                if (_cells[refCellInt].result == string.Empty)
                {
                    op2 = CalcCell(_cells[refCellInt], _cells);
                }
                else
                {
                    int.TryParse(_cells[refCellInt].result, out op2);
                }
            }
            else
            {
                int.TryParse(c.arg2, out op2);
            }

            if (c.command == "ADD")
            {
                res = op1 + op2;
            }
            else if (c.command == "SUB")
            {
                res = op1 - op2;
            }
            else if (c.command == "MULT")
            {
                res = op1 * op2;
            }
            else if (c.command == "VALUE")
            {
                if (c.result != string.Empty)
                    int.TryParse(c.result, out res);
                else
                    res = op1;
            }

            c.result = res.ToString();
            return res;
        }
    }
}
