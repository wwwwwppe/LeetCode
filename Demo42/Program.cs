namespace Demo42;

class Program
{
    public int Trap(int[] height)
    {
        int sum = 0;
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        while (left < right)
        {
            leftMax = Math.Max(leftMax, height[left]);
            rightMax = Math.Max(rightMax, height[right]);
            if (height[left] < height[right])
            {
                sum += leftMax - height[left];
                left++;
            }
            else
            {
                sum += rightMax - height[right];
                right--;
            }
        }
        return sum;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}