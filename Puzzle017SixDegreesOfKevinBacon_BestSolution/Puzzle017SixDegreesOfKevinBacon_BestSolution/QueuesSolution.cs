using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle017SixDegreesOfKevinBacon_BestSolution
{
    public class QueuesSolution
    {
        public static int Run()
        {
            string actorName = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            // For mapping the graph. Using a HashSet helps avoiding duplicates automatically.
            Dictionary<string, HashSet<string>> graph = new();

            for (int i = 0; i < n; i++)
            {
                string movieCast = Console.ReadLine();
                int titleEnd = movieCast.IndexOf(':');

                List<string> coactors = movieCast.Split(':')[1].Split(',').Select(_ => _.Trim()).ToList();

                foreach (string actor in coactors)
                {
                    if (!graph.ContainsKey(actor))
                    {
                        // Initialize for each actor not already added
                        graph[actor] = new HashSet<string>();
                    }
                    foreach (string coactor in coactors)
                    {
                        // Not adding itself
                        if (actor != coactor)
                        {
                            graph[actor].Add(coactor);
                        }
                    }
                }
            }


            // Graph built. Now to BFS traverse it.
            int degrees = BFS(graph, actorName, "Kevin Bacon");

            if (degrees == -1) Console.WriteLine("BFS unable to find a path.");
            else Console.WriteLine($"{degrees}");

            return degrees;
        }

        public static int BFS(Dictionary<string, HashSet<string>> graph, string startActor, string targetActor)
        {
            Queue<(string, int)> queue = new();
            HashSet<string> visited = new();

            queue.Enqueue((startActor, 0));
            visited.Add(startActor);

            while (queue.Count > 0)
            {
                (string currentActor, int degrees) current = queue.Dequeue();

                if (current.currentActor == targetActor)
                {
                    return current.degrees;
                }

                foreach (string neighbour in graph[current.currentActor])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        queue.Enqueue((neighbour, current.degrees + 1));
                    }
                }
            }

            return -1;
        }
    }
}
