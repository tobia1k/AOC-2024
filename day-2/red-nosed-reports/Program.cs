namespace day2;

class Program
{
    static void Main(string[] args) 
    {
        try 
        {
            StreamReader sr = new StreamReader("input.txt");
            string line;
            int safeCount = 0;
            
            while((line = sr.ReadLine()) != null)
            {
                int[] report = line.Split(' ').Select(int.Parse).ToArray();
                bool increasing = true;
                bool safe = true;

                if (report[0] > report[1]) 
                {
                    increasing = false;
                }

                for (int i = 1; i < report.Length; i++)
                {
                    int diff = report[i] - report[i-1];

                    if (increasing && report[i - 1] < report[i] && diff <= 3 && diff >= 1) 
                    {
                        continue;
                    }
                    else if (!increasing && report[i - 1] > report[i] && diff >= -3 && diff <= -1) 
                    {
                        continue;
                    }
                    else 
                    {
                        safe = false;
                        break;
                    }
                }

                if (safe) 
                {
                    safeCount++;
                }
                
            }

            Console.WriteLine(safeCount);
            sr.Close();


            // Part Two
            StreamReader sr2 = new StreamReader("input.txt");
            safeCount = 0;
            while((line = sr2.ReadLine()) != null)
            {
                int[] report = line.Split(' ').Select(int.Parse).ToArray();
                bool increasing = true;
                bool safe = true;
                bool dampener = false;

                if (report[0] > report[1]) 
                {
                    increasing = false;
                }

                for (int i = 1; i < report.Length; i++)
                {
                    int diff = report[i] - report[i-1];

                    if (increasing && report[i - 1] < report[i] && diff <= 3 && diff >= 1) 
                    {
                        continue;
                    }
                    else if (!increasing && report[i - 1] > report[i] && diff >= -3 && diff <= -1) 
                    {
                        continue;
                    }
                    else if (!dampener) {
                        dampener = true;
                        continue;
                    }
                    else 
                    {
                        safe = false;
                        break;
                    }
                }

                if (safe) 
                {
                    safeCount++;
                }
                
            }
            Console.WriteLine(safeCount);
        }
        catch(Exception e) 
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
}