namespace Demo414;

class Program
{
    public int ThirdMax(int[] nums) {
        var a = nums.ToHashSet();
        return a.Count < 3 ? a.Max() : a.OrderByDescending(x => x).ToList()[2];
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}