using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle017SixDegreesOfKevinBacon_BestSolution
{
    public class CrazyForSolution
    {
        public static int Run()
        {
            string actorName = Console.ReadLine();
            var Movies = Enumerable.Range(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split(": ")[1].Split(", ").ToList()).ToList();
            int degrees = 0;

            // original for loop
            for (var Actors = new HashSet<string>() { "Kevin Bacon" }; !Actors.Contains(actorName); degrees++, Actors = Movies.Where(m => Actors.Any(a => m.Contains(a))).SelectMany(m => m).ToHashSet()) ;

            // decomposed for loop
            //var Actors = new HashSet<string>() { "Kevin Bacon" };
            //while (!Actors.Contains(actorName))
            //{
            //    // Find all movies that have at least one actor from the current set
            //    var moviesWithCurrentActors = Movies
            //        .Where(m => Actors.Any(a => m.Contains(a)))
            //        .ToList();

            //    // Collect all actors from those movies into a single list
            //    var allActorsInTheseMovies = moviesWithCurrentActors
            //        .SelectMany(m => m)
            //        .ToList();

            //    // Create a new set of actors for the next degree
            //    Actors = allActorsInTheseMovies.ToHashSet();

            //    degrees++;
            //}

            return degrees;
        }
    }
}
