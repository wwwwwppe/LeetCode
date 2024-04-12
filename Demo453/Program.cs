namespace Demo453;

class Program
{
    public int MinMoves(int[] nums)
    {
        int minNum = nums.Min();
        return nums.Sum(num => num - minNum);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}