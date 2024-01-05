namespace Demo27;

class Program
{
    public static int RemoveElement(int[] nums, int val)
    {
        int[] a = nums.Where(x => x != val).ToArray();
        return a.Length;
    }
    
    static void Main(string[] args)
    {
        int[] nums = [3, 2, 2, 3];
        int b =RemoveElement(nums, 3);
        Console.WriteLine(b);
    }
}