namespace Demo167;

class Program
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0, right=numbers.Length-1;
        while (left<right)
        {
            var a = numbers[left] + numbers[right];
            if (a == target)
            {
                return [++left, ++right];
            }else if (a > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return [];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}