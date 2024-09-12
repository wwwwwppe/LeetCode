namespace Demo2806;

class Program
{
    public int AccountBalanceAfterPurchase(int purchaseAmount)
    {
        return (int)(100 - Math.Round((decimal)purchaseAmount / 10, MidpointRounding.AwayFromZero) * 10);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}