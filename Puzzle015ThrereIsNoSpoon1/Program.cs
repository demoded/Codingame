using Puzzle015ThrereIsNoSpoon1;

internal class Program
{
    private static void Main(string[] args)
    {
        //char[,] array = {
        //    { 'a', 'b', 'c' },
        //    { 'd', 'e', 'f' },
        //    { 'g', 'h', 'i' }
        //};

        //Console.WriteLine("Iterating horizontally from position (1, 1):");
        //var rowIterator = new MatrixIterator<char>(array, MatrixIterator<char>.ScanMode.Horizontal, 1, 1);
        //foreach (var ch in rowIterator)
        //{
        //    Console.Write(ch + " "); // Output: e f
        //}

        //Console.WriteLine("\n\nIterating vertically from position (0, 2):");
        //var columnIterator = new MatrixIterator<char>(array, MatrixIterator<char>.ScanMode.Vertical, 0, 2);
        //foreach (var ch in columnIterator)
        //{
        //    Console.Write(ch + " "); // Output: c f i
        //}

        //Console.WriteLine("\n\nIterating over the whole matrix from position (0, 0):");
        //var fullIterator = new MatrixIterator<char>(array, MatrixIterator<char>.ScanMode.Full, 0, 0);
        //foreach (var ch in fullIterator)
        //{
        //    if (ch == 'e')
        //    {
        //        Console.Write($"Found 'e' at {fullIterator.GetColumn()} {fullIterator.GetRow()}");
        //    }
        //}

        //int[,] map = {
        //    { 1, 1 },
        //    { 1, 0 }
        //};

        int[] map = { 1, 0, 1, 0, 1 };

        var fullIterator = new MatrixIterator<int>(map, MatrixIterator<int>.ScanMode.Full, 0, 0);
        foreach (var cell in fullIterator)
        {
            if (cell == 1)
            {
                var root = $"{fullIterator.GetColumn()} {fullIterator.GetRow()}";
                var right = "-1 -1";
                var horizontal = new MatrixIterator<int>(map, MatrixIterator<int>.ScanMode.Horizontal, fullIterator.GetRow(), fullIterator.GetColumn() + 1);
                foreach (var rowCell in horizontal)
                {
                    if (rowCell == 1)
                    {
                        right = $"{horizontal.GetColumn()} {horizontal.GetRow()}";
                        break;
                    }
                }
                //right = string.IsNullOrEmpty(right) ? "-1 -1" : right;

                var down = "-1 -1";
                var vertical = new MatrixIterator<int>(map, MatrixIterator<int>.ScanMode.Vertical, fullIterator.GetRow() + 1, fullIterator.GetColumn());
                foreach (var columnCell in vertical)
                {
                    if (columnCell == 1)
                    {
                        down = $"{vertical.GetColumn()} {vertical.GetRow()}";
                        break;
                    }
                }

                Console.Error.WriteLine($"{root} {right} {down}");


            }
        }
    }
}