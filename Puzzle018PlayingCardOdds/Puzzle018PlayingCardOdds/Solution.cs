
using System.Text.RegularExpressions;

public class Solution
{
    const string _ranks = "23456789TJQKA";
    const string _suits = "CDHS";

    public static string Run()
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int R = int.Parse(inputs.First());
        int S = int.Parse(inputs.Last());
        var excludedCards = new HashSet<string>();
        var handCards = new HashSet<string>();

        for (int i = 0; i < R; i++)
        {
            var s = Console.ReadLine();
            excludedCards.UnionWith(ParseCards(s));
        }
        for (int i = 0; i < S; i++)
        {
            var s = Console.ReadLine();
            handCards.UnionWith(ParseCards(s));
        }

        handCards.ExceptWith(excludedCards);

        return $"{(int)(100 * handCards.Count / (52 - excludedCards.Count))}%";
    }

    public static HashSet<string> ParseCards(string handString)
    {
        if (string.IsNullOrEmpty(handString))
            return new HashSet<string>();

        var result = new HashSet<string>();

        if (handString.All(c => _suits.Contains(c)))
        {
            foreach (char suit in handString)
            {
                foreach (char rank in _ranks)
                {
                    result.Add($"{rank}{suit}");
                }
            }
            return result;
        }

        var pattern = @"([2-9TJQKA]+)([CDHS]*)";
        var matches = Regex.Matches(handString, pattern);

        if (matches.Count == 0)
            return result;

        foreach (Match match in matches)
        {
            var ranks = match.Groups[1].Value;
            var suits = match.Groups[2].Value;

            if (string.IsNullOrEmpty(suits))
            {
                suits = new string(_suits);
            }

            foreach (char rank in ranks)
            {
                if (!_ranks.Contains(rank))
                    continue;

                foreach (char suit in suits)
                {
                    if (!_suits.Contains(suit))
                        continue;

                    result.Add($"{rank}{suit}");
                }
            }
        }

        return result;
    }
}