namespace day1;

class Program
{
    static void Main(string[] args)
    {
        try {
        StreamReader sr = new StreamReader("list.txt");
        string line;
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        while((line = sr.ReadLine()) != null)
        {
            string[] numPair = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            leftList.Add(Convert.ToInt32(numPair[0]));
            rightList.Add(Convert.ToInt32(numPair[1]));
        }
        
        int[] leftArray = leftList.ToArray();
        int[] rightArray = rightList.ToArray();
        Array.Sort(leftArray);
        Array.Sort(rightArray);

        List<int> difference = new List<int>();

        for (int i = 0; i < 1000; i++) {
            if (leftArray[i] >= rightArray[i]) {
                difference.Add(leftArray[i] - rightArray[i]);
            }
            else {
                difference.Add(rightArray[i] - leftArray[i]);
            }
        }

        int[] diffArray = difference.ToArray();
        int total = 0;
        foreach(int num in diffArray) {
            total += num;
        }

        Console.WriteLine(total);

        sr.Close();
        Console.ReadLine();
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