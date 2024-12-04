using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public partial class Day4 : IDay
    {
        private string[] grid;

        private const string xmas = "XMAS";

        public string Part1()
        {
            grid = File.ReadAllLines(@"InputFiles\Day4.txt");
            var count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    count += GetDiagonalMatches(i, j);
                }
            }
            return count.ToString();
        }

        public string Part2()
        {
            grid = File.ReadAllLines(@"InputFiles\Day4.txt");
            var count = 0;
            for (int i = 1; i < grid.Length - 1; i++)
            {
                for (int j = 1; j < grid[i].Length - 1; j++)
                {
                    if (grid[i][j] == 'A' && GetXMatch(i, j)) count++;
                }
            }
            return count.ToString();
        }

        private int GetDiagonalMatches(int x, int y)
        {
            var count = 0;
            if (TraverseDiagonal(x, y, 1, 0)) count++;
            if (TraverseDiagonal(x, y, 1, 1)) count++;
            if (TraverseDiagonal(x, y, 0, 1)) count++;
            if (TraverseDiagonal(x, y, -1, 0)) count++;
            if (TraverseDiagonal(x, y, -1, -1)) count++;
            if (TraverseDiagonal(x, y, 0, -1)) count++;
            if (TraverseDiagonal(x, y, 1, -1)) count++;
            if (TraverseDiagonal(x, y, -1, 1)) count++;
            return count;
        }

        private bool TraverseDiagonal(int x, int y, int xDir, int yDir, int index = 0)
        {
            if (index == xmas.Length) return true;
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid.First().Length || grid[x][y] != xmas[index]) return false;
            return TraverseDiagonal(x + xDir, y + yDir, xDir, yDir, index + 1);
        }

        private bool GetXMatch(int x, int y)
        {
            var diagonals = new List<char>
            {
                grid[x - 1][y - 1], // Upper left
                grid[x + 1][y - 1], // Upper right
                grid[x - 1][y + 1], // Lower left
                grid[x + 1][y + 1]  // Lower right
            };

            // True if there are 2 M's, 2 S's and not opposite themselves
            return diagonals.First() != diagonals.Last() &&
                diagonals.Count(x => x == 'M') == 2 &&
                diagonals.Count(x => x == 'S') == 2;
        }
    }
}
