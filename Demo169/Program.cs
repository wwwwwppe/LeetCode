namespace Demo169;

class Program
{
    public int MajorityElement(int[] nums) {
        Random random = new Random();
  
        int randomIndex = random.Next(0, nums.Length);
  
        return nums[randomIndex];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}