using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static partial class Utils
    {
        public static int[] GetInts(string input) => SeperatedNumbers()
            .Matches(input)
            .Select(x => int.Parse(x.Value))
            .ToArray();

        [GeneratedRegex(@"\d+")]
        private static partial Regex SeperatedNumbers();
    }
}
