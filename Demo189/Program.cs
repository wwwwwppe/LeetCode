namespace Demo189;

class Program
{
    public void Rotate(int[] nums, int k)
    {
        int[] b = nums.Clone() as int[] ?? Array.Empty<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            nums[(i + k) % nums.Length] = b[i];
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}