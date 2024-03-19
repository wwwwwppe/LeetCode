namespace Demo121;

class Program
{
    public int MaxProfit(int[] prices)
    {
        int max = 0;
        int left = prices[0];
        foreach (var price in prices)
        {
            if (price - left > max) max = price - left;
            if (price < left) left = price;
        }

        return max;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}