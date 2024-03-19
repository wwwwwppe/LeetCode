namespace Demo122;

class Program
{
    public int MaxProfit(int[] prices)
    {
        int Sum = 0;
        int left = prices[0];
        foreach (var price in prices)
        {
            if(price>left)
            {
                Sum += price - left;
            }
            left = price;
        }

        return Sum;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}