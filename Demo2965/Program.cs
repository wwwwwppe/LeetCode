namespace Demo2965;

class Program
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        long sum = grid.Sum(x => x.Sum());
        long tarSum = (1 + n * n) * n * n / 2;
        //int a = grid.SelectMany(x => x).GroupBy(g => g).Where(w => w.Count() == 2).Select(s => s.Key).ToArray()[0];
        //这个可以改成first
        int a = grid.SelectMany(x => x).GroupBy(g => g).Where(w => w.Count() == 2).Select(s => s.Key).First();
        long b =a + tarSum - sum;
        return [a, (int)b];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}