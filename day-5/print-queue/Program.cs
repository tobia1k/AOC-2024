using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
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
            int count2 = 0;
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
                    
                    // Adds together only updates that do not initially follow the rules
                    bool addToCount2 = false;
                    do {
                        followsRules = true;
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
                                        int temp = nums[i];
                                        nums[i] = nums[j];
                                        nums[j] = temp;
                                        followsRules = false;
                                        addToCount2 = true;
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
                                        int temp = nums[i];
                                        nums[i] = nums[j];
                                        nums[j] = temp;
                                        followsRules = false;
                                        addToCount2 = true;
                                        break;
                                    }
                                }
                                continue;
                            }
                        }
                        
                    }
                    while (followsRules == false);
                    if (!addToCount2)
                    {
                        count += nums[nums.Length / 2];
                    }
                    else
                    {
                        count2 += nums[nums.Length / 2];
                    }
                }
                
            }
            Console.WriteLine(count);
            Console.WriteLine(count2);
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