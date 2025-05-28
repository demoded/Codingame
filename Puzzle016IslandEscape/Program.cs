struct Point2D
{
    public int x;
    public int y;
}

internal class Program
{
    private static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        var field = new int[N, N];

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                int elevation = int.Parse(inputs[j]);
                field[i, j] = elevation;
            }
        }

        var start = new Point2D { x = N / 2, y = N / 2 };
        var queue = new Queue<Point2D>();
        var visited = new HashSet<(Point2D, Point2D)>() { (start, start) };

        queue.Enqueue(start);
        bool isOcean = false;

        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            var adjacentCells = new List<Point2D>{
                new Point2D{x = p.x + 1, y = p.y},
                new Point2D{x = p.x, y = p.y + 1},
                new Point2D{x = p.x - 1, y = p.y},
                new Point2D{x = p.x, y = p.y - 1}
            };

            foreach (var c in adjacentCells)
            {
                var canStep = Math.Abs(field[p.x, p.y] - field[c.x, c.y]) <= 1;
                var isEdge = c.x == 0 || c.y == 0 || c.x == N - 1 || c.y == N - 1;
                if (canStep)
                {
                    if (isEdge)
                    {
                        isOcean = true;
                        break;
                    }
                    else if (!visited.Contains((p, c)))
                    {
                        queue.Enqueue(c);
                    }
                }
                visited.Add((p, c));
            }
            if (isOcean)
            {
                break;
            }
        }

        Console.WriteLine(isOcean ? "yes" : "no");
    }
}