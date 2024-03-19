namespace Demo238;

class Program
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var leftMul = new int[nums.Length];
        var rightMul = new int[nums.Length];
        var otherMul = new int[nums.Length];
        leftMul[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            leftMul[i] = nums[i] * leftMul[i - 1];
        }

        rightMul[^1] = nums[^1];
        for (var i = rightMul.Length - 2; i >= 0; i--)
        {
            rightMul[i] = nums[i] * rightMul[i + 1];
        }

        otherMul[0] = rightMul[1];
        for (var i = 1; i < nums.Length-1; i++)
        {
            otherMul[i] = leftMul[i - 1] * rightMul[i + 1];
        }

        otherMul[^1] = leftMul[^2];
        
        return otherMul;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}