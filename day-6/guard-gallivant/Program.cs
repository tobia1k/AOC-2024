using System.Data;

namespace day6;

class Program 
{
    static void Main(string[] args)
    {
        try
        {
            int row = 0;
            int col = 0;
            int count = 1;
            string[][] input = File.ReadAllLines("input.txt").Select(l => l.Select(c => c.ToString()).ToArray()).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (input[i][j] == "^" || input[i][j] == "<" || input[i][j] == ">" || input[i][j] == "v")
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }
            while (row < input.Length-1 && col < input[0].Length-1)
            {
                // Move up
                if (input[row][col] == "^") {
                    if (input[row - 1][col] != "#")
                    {
                        input[row][col] = "X";
                        row--;
                        if (input[row][col] != "X")
                        {
                            count++;
                        }
                        input[row][col] = "^";
                    }
                    else
                    {
                        input[row][col] = ">";
                    }
                } 
                // Move down
                if (input[row][col] == "v") {
                    if (input[row + 1][col] != "#")
                    {
                        input[row][col] = "X";
                        row++;
                        if (input[row][col] != "X")
                        {
                            count++;
                        }
                        input[row][col] = "v";
                    }
                    else
                    {
                        input[row][col] = "<";
                    }
                } 
                // Move right
                if (input[row][col] == ">") {
                    if (input[row][col + 1] != "#")
                    {
                        input[row][col] = "X";
                        col++;
                        if (input[row][col] != "X")
                        {
                            count++;
                        }
                        input[row][col] = ">";
                    }
                    else
                    {
                        input[row][col] = "v";
                    }
                } 
                // Move left
                if (input[row][col] == "<") {
                    if (input[row][col - 1] != "#")
                    {
                        
                        input[row][col] = "X";
                        col--;
                        if (input[row][col] != "X")
                        {
                            count++;
                        }
                        input[row][col] = "<";
                    }
                    else
                    {
                        input[row][col] = "^";
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
}