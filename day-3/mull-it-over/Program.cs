using System.Text.RegularExpressions;

namespace day3;

class Program
{
    static void Main(string[] args) {
        try
        {
            Regex regex = new Regex(@"mul\([0-9]{1,3},[0-9]{1,3}\)");
            StreamReader sr = new StreamReader("input.txt");
            string line;
            while ((line = sr.ReadLine()) != null) {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches) {
                    GroupCollection groups = match.Groups;
                    Console.WriteLine(groups[0].Value);
                }
            }
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