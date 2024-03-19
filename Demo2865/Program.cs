namespace Demo2865;

class Program
{
    public long MaximumSumOfHeights(IList<int> maxHeights)
    {
        long ret = 0;
        
        for (var i = 0; i < maxHeights.Count; i++)
        {
            int leftMaxTower = Int32.MaxValue,rightMaxTower=Int32.MaxValue;
            long sum = 0;
            for (int j = i-1; j >= 0; j--)
            {
                leftMaxTower = MinInThree(maxHeights[i], maxHeights[j], leftMaxTower);
                sum += leftMaxTower;
            }

            for (int j = i+1; j < maxHeights.Count; j++)
            {
                rightMaxTower = MinInThree(maxHeights[i], maxHeights[j], rightMaxTower);
                sum += rightMaxTower;
            }

            sum += maxHeights[i];
            ret = Math.Max(sum, ret);
        }

        return ret;

        int MinInThree(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), Math.Min(a, c));
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}