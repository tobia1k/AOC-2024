using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace day4;

class Program
{
    static void Main(string[] args) 
    {
        try
        {
            int count = 0;
            Regex regex = new Regex(@"(?=(XMAS|SAMX))");
            string[][] input = File.ReadAllLines("input.txt").Select(l => l.Select(c => c.ToString()).ToArray()).ToArray();
            Console.WriteLine(input.Length);
            
            // Find all matches horizontally
            foreach (var row in input)
            {
                MatchCollection matchesRow = regex.Matches(string.Join("", row));
                foreach (Match match in matchesRow)
                {
                    count++;
                }
            }

            // Find all matches vertically
            for (int col = 0; col < input[0].Length; col++)
            {
                string vertical = "";
                for (int row = 0; row < input.Length; row++)
                {
                    vertical += input[row][col];
                }
                MatchCollection matchesCol = regex.Matches(vertical);
                foreach(Match match in matchesCol) 
                {
                    count++;
                }
            }

            // Find all matches diagonally (top-left to bottom-right)
            
            for (int col = 0; col < input.Length; col++)
            {
                string diagonal = "";
                int row = 0;
                for (int col2 = col; col2 < input.Length; col2++)
                {
                    diagonal += input[row][col2];
                    row++;
                }
                MatchCollection matchesDiagonal = regex.Matches(diagonal);
                foreach(Match match in matchesDiagonal)
                {
                    count++;
                }
            }

            for (int row = 1; row < input.Length; row++)
            {
                string diagonal = "";
                int col = 0;
                for (int row2 = row; row2 < input.Length; row2++)
                {
                    diagonal += input[row2][col];
                    col++;
                }
                MatchCollection matchesDiagonal = regex.Matches(diagonal);
                foreach(Match match in matchesDiagonal)
                {
                    count++;
                }
            }

            // Find all matches diagonally (top-right to bottom-left)
            
            for (int col = input.Length - 1; col >= 0; col--)
            {
                string diagonal = "";
                int row = 0;
                for (int col2 = col; col2 >= 0; col2--)
                {
                    diagonal += input[row][col2];
                    row++;
                }
                MatchCollection matchesDiagonal = regex.Matches(diagonal);
                foreach(Match match in matchesDiagonal)
                {
                    count++;
                }
            }

            for (int row = 1; row < input.Length; row++)
            {
                string diagonal = "";
                int col = input.Length - 1;
                for (int row2 = row; row2 < input.Length; row2++)
                {
                    diagonal += input[row2][col];
                    col--;
                }
                MatchCollection matchesDiagonal = regex.Matches(diagonal);
                foreach(Match match in matchesDiagonal)
                {
                    count++;
                }
                
            }
            Console.WriteLine(count);

            // Part Two
            count = 0;
            Regex aRegex = new Regex(@"(?=(MAS|SAM))");
            for (int row = 1; row < input.Length - 1; row++)
            {
                for (int col = 1; col < input.Length - 1; col++)
                {
                    string xMas = "";
                    if (input[row][col] == "A") 
                    {
                        if (IsValidXPattern(input, row, col)){
                            count++;
                        }
                    }
                }
            }
            
            Console.WriteLine(count);
        }
        catch (Exception e) 
        {
            Console.WriteLine("Exception: " + e);
        }
        finally 
        {
            Console.WriteLine("Executing finally block");
        }
    }

    static bool IsValidXPattern(string[][] grid, int row, int col) 
    {
        return (grid[row - 1][col - 1] == "M" && grid[row + 1][col + 1] == "S" ||
                grid[row - 1][col - 1] == "S" && grid[row + 1][col + 1] == "M") &&
               (grid[row - 1][col + 1] == "M" && grid[row + 1][col - 1] == "S" ||
                grid[row - 1][col + 1] == "S" && grid[row + 1][col - 1] == "M");
    }
}