

public class Solution
{
    public static int Run()
    {
        var actorName = Console.ReadLine();
        var N = int.Parse(Console.ReadLine());
        var lines = Enumerable.Range(0, N).Select(_ => Console.ReadLine()).ToList();
        var lookups = lines.SelectMany(line =>
        { 
            var parts = line.Split(':');
            var key = parts[0].Trim();
            var values = parts[1].Trim().Split(',').Select(s => s.Trim()).ToList();
            return values.Select(value => new { key, value });
        }).ToLookup(v => v.key, v => v.value);
        var visited = new HashSet<string>();

        if (lookups.First().Contains(actorName) && actorName == "Kevin Bacon")
        {
            return 0;
        }
        else
        {
            return Search(1, actorName, actorName, "", "Kevin Bacon", lookups, visited);
        }
    }

    private static int Search(int steps, string rootName, string currentName, string currentMovie, string searchName, ILookup<string, string> movies, HashSet<string> visited)
    {
        var moviesWithActor = movies.Where(x => x.Contains(currentName) && !x.Key.Equals(currentMovie)).SelectMany(x =>
        {
            var key = x.Key;
            return x.Select(a => new { key, value = a });
        }).ToLookup(v => v.key, v => v.value);

        int result = 0;
        foreach(var movie in moviesWithActor)
        {
            if (movie.Contains(searchName))
            {
                result = steps;
                break;
            }

            foreach (var actor in movie)
            {
                var visitKey = $"{movie.Key}:{actor}";
                if (actor == rootName || visited.Contains(visitKey))
                {
                    continue;
                }
                visited.Add(visitKey);

                result = Search(steps + 1, rootName, actor, movie.Key, searchName, movies, visited);
                if (result > 0)
                {
                    break;
                }
            }
        }
        
        return result;
    }
}