namespace Demo2706;

class Program
{
    public int BuyChoco(int[] prices, int money)
    {
        prices = prices.Order().ToArray();
        //Array.Sort(prices);
        return money - prices[0] - prices[1] > 0 ? money - prices[0] - prices[1] : money;
    } 
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}