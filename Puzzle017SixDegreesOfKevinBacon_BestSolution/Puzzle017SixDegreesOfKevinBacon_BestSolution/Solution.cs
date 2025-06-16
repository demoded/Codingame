
public class Solution
{
    public static int Run()
    {
        string actorName = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        var movies = new Movie[n];
        for (int i = 0; i < n; i++)
        {
            movies[i] = new Movie(Console.ReadLine());
        }

        int degrees = 0;
        var actors = new List<string>() { "Kevin Bacon" };

        while (!actors.Contains(actorName))
        {
            actors = movies
                .Where(m => m.HasActors(actors))
                .SelectMany(m => m.Actors)
                .ToList();
            degrees++;
        }

        return degrees;
    }

    class Movie
    {
        public readonly string Title;
        public readonly List<string> Actors;
        public int DegreesKB;
        public Movie NearestKB;

        public Movie(string line)
        {
            string[] s1 = line.Split(':');
            string[] s2 = s1[1].Split(',');
            Title = s1[0].Trim();
            Actors = s2.Select(s => s.Trim()).ToList();
        }
        public bool HasActors(IEnumerable<string> actors)
        {
            return actors.Any(a => Actors.Contains(a));
        }
    }
}