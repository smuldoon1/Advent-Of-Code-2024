using System;
using System.Reflection;

namespace AdventOfCode
{
    public class Day2 : IDay
    {
        public string Part1()
        {
            var lines = File.ReadAllLines(@"InputFiles\Day2.txt");
            return lines.Count(x => IsSafeLevel(Utils.GetInts(x))).ToString();
        }

        public string Part2()
        {
            var lines = File.ReadAllLines(@"InputFiles\Day2.txt");
            var safeCount = 0;
            foreach (var line in lines)
            {
                var level = Utils.GetInts(line);
                for (int i = 0; i < level.Length; i++)
                {
                    var modifiedLevel = level.ToList();
                    modifiedLevel.RemoveAt(i);
                    if (IsSafeLevel([..modifiedLevel]))
                    {
                        safeCount++;
                        break;
                    }
                }
            }
            return safeCount.ToString();
        }

        private static bool IsSafeLevel(int[] levels)
        {
            return IsSafeIncrements(levels) || IsSafeDecrements(levels);
        }

        private static bool IsSafeIncrements(int[] levels)
        {
            for (int i = 0; i < levels.Length - 1; i++)
            {
                if (!IsSafeIncrement(levels[i], levels[i + 1])) return false;
            }
            return true;
        }

        private static bool IsSafeDecrements(int[] levels)
        {
            for (int i = 0; i < levels.Length - 1; i++)
            {
                if (!IsSafeDecrement(levels[i], levels[i + 1])) return false;
            }
            return true;
        }

        private static bool IsSafeIncrement(int x, int y) => x < y && x + 4 > y;

        private static bool IsSafeDecrement(int x, int y) => x > y && x < y + 4;
    }
}
