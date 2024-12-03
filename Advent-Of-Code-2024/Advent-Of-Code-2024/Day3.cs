using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public partial class Day3 : IDay
    {
        public string Part1() =>
            GetMultiplyInstruction()
            .Matches(File.ReadAllText(@"InputFiles\Day3.txt"))
            .Sum(ExecuteMultiplyInstruction)
            .ToString();

        public string Part2()
        {
            var text = File.ReadAllText(@"InputFiles\Day3.txt");
            var enabled = true;
            var count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i < text.Length - 3 && text[i..(i + 4)] == "do()") enabled = true;
                else if (i < text.Length - 6 && text[i..(i + 7)] == "don't()") enabled = false;
                else if (enabled)
                {
                    var match = GetMultiplyInstructionAtStart().Match(text[i..]);
                    if (match.Success) count += ExecuteMultiplyInstruction(match);
                }
            }
            return count.ToString();
        }

        private static int ExecuteMultiplyInstruction(Match match) => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);

        [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
        private static partial Regex GetMultiplyInstruction();

        [GeneratedRegex(@"^mul\((\d+),(\d+)\)")]
        private static partial Regex GetMultiplyInstructionAtStart();
    }
}
