namespace Demo2798;

class Program
{
    public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
    {
        return hours.Count(x => x >= target);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}