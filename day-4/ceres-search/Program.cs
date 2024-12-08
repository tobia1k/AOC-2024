using System.Text.RegularExpressions;

namespace day4;

class Program
{
    static void Main(string[] args) 
    {
        try
        {
            Regex regex = new Regex(@"XMAS|SAMX");
            StreamReader sr = new StreamReader("input.txt");
            string? line;
            while((line = sr.ReadLine()) != null) {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches) {
                    Console.WriteLine(match);
                }
            }
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