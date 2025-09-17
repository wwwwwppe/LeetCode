namespace Demo1431;

class Program
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        // var maxNum = candies.Max() - extraCandies;
        // return candies.Select(t => t >= maxNum).ToList();
        int maxNum = candies.Max() - extraCandies;
        List<bool> result = new List<bool>();
        for (int i = 0; i < candies.Length; i++)
        {
            result.Add(candies[i] >= maxNum);
        }
        return result;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}