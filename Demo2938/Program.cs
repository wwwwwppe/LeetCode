namespace Demo2938;

class Program
{
    public long MinimumSteps(string s)
    {
        long n = s.Length;
        long sum = s.Select((c, i) => c == '1' ? i : 0).Sum();
        long blackNum = s.Sum(x => x == '1' ? 1 : 0);
        long tartSum = (n - blackNum + n -1) * blackNum / 2;
        return tartSum - sum;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}