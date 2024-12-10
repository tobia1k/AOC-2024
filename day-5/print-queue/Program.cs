using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace day5;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Regex regex = new Regex(@"([0-9]{2})\|([0-9]{2})");
            StreamReader sr = new StreamReader("input.txt");
            var pairs = new List<Tuple<int,int>>();
            string? line;
            int count = 0;
            while((line = sr.ReadLine()) != null)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    pairs.Add(Tuple.Create(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
                }
                if (!regex.IsMatch(line) && line != "")
                {
                    int[] nums = line.Split(',').Select(int.Parse).ToArray();
                    bool followsRules = true;
                    for (int i = 0; i < nums.Length; i++) 
                    {
                        for (int j = 0; j < nums.Length; j++)
                        {
                            if (j < i)
                            {
                                var tupleToCheck = Tuple.Create(nums[j], nums[i]);
                                if (pairs.Contains(tupleToCheck))
                                {
                                    continue;
                                }
                                else
                                {
                                    followsRules = false;
                                    break;
                                }
                            }
                            else if (j > i)
                            {
                                var tupleToCheck = Tuple.Create(nums[i], nums[j]);
                                if (pairs.Contains(tupleToCheck))
                                {
                                    continue;
                                }
                                else
                                {
                                    followsRules = false;
                                    break;
                                }
                            }
                            continue;
                        }
                    }
                    if (followsRules)
                    {
                        count += nums[nums.Length / 2];
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
            Console.WriteLine("Executing finally block.");
        }
    }
}