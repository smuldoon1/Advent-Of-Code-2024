namespace AdventOfCode
{
    public class Day1 : IDay
    {
        public string Part1()
        {
            var lines = File.ReadAllLines(@"InputFiles\Day1.txt");
            var (left, right) = GetLists(lines);

            left.Sort();
            right.Sort();

            return left.Zip(right).Sum(x => Math.Abs(x.First - x.Second)).ToString();
        }

        public string Part2()
        {
            var lines = File.ReadAllLines(@"InputFiles\Day1.txt");
            var (left, right) = GetLists(lines);

            return left.Sum(x => x * right.Count(y => x == y)).ToString();
        }

        private static (List<int> Left, List<int> Right) GetLists(string[] lines)
        {
            var left = new List<int>();
            var right = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                var numbers = Utils.GetInts(lines[i]);
                left.Add(numbers[0]);
                right.Add(numbers[1]);
            }
            return (left, right);
        }
    }
}
