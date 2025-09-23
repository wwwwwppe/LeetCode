namespace Demo1732;

class Program
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int height = 0;
        gain.ToList().ForEach(g =>
        {
            height += g;
            max = Math.Max(max, height);
        });
        return max;
    }
    
    public int LargestAltitudeLinqTwo(int[] gain)
    {
        var running = 0;
        return gain.Select(g => running += g).Prepend(0).Max();

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}