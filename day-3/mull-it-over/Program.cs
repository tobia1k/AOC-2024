using System.Text.RegularExpressions;

namespace day3;

class Program
{
    static void Main(string[] args) {
        try
        {
            // "mul(X,Y)", also captures the two numbers
            Regex regex = new Regex(@"mul\(([0-9]{1,3}),([0-9]{1,3})\)");
            StreamReader sr = new StreamReader("input.txt");
            string? line;
            int total = 0;
            while ((line = sr.ReadLine()) != null) {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches) {
                    total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }
            Console.WriteLine(total);
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
}