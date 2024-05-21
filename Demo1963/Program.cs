namespace Demo1963;

class Program
{
    public long NumberOfWeeks(int[] milestones)
    {
        long a = milestones.Sum( x => (long)x);
        int maxLength = milestones.Max();
        if (maxLength > a - maxLength)
        {
            return 2 * (a - maxLength) + 1;
        }
        return a;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}