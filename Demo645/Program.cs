namespace Demo645;

class Program
{
    public int[] FindErrorNums(int[] nums)
    {
        HashSet<int> a = new HashSet<int>();
        int n = nums.Length;
        int sum = (1+n)*n/2 - nums.Sum();
        
        foreach (var num in nums)
        {
            if (!a.Add(num))
            {
                return [num, num + sum];
            }
        }

        return [];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}