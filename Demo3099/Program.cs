namespace Demo3099;

class Program
{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        int b = x;
        int sum = 0;
        while (b>0)
        {
            sum += b % 10;
            b /= 10;
        }

        return x % sum == 0 ? sum : -1;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}