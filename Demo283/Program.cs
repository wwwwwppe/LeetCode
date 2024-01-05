namespace Demo283;

class Program
{

    public void MoveZeroes(int[] nums)
    {
        var slow = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue;
            nums[slow] = nums[i];
            if (slow != i) nums[i] = 0;
            slow++;
        }
    }
    
    public void MoveZeroesOri(int[] nums)
    {
        int zeroNum = 0;
        int[] zeroNums = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroNum++;
                zeroNums[i] = -1;
            }
            else
            {
                zeroNums[i] = zeroNum;
            }
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (zeroNums[i] == -1 || zeroNums[i] == 0) continue;
            nums[i - zeroNums[i]] = nums[i];
            nums[i] = 0;
        }
        

        void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
    
     
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}