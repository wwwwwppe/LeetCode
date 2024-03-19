namespace Demo136;

class Program
{
    public int SingleNumber(int[] nums)
    {
        return nums.Aggregate(0, (current, num) => current ^ num);
    }
    
    public int SingleNumberOri(int[] nums)
    {
        HashSet<int> hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!hashSet.Add(num)) hashSet.Remove(num);
        }

        return hashSet.ElementAt(0);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}