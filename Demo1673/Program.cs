namespace Demo1673;

class Program
{
    //这个应该是有问题的，但是没有确定具体是哪里出现了问题，但是应该是有问题的
    public int[] MostCompetitive(int[] nums, int k)
    { 
        int[] res = new int[k]; 
        //这个应该要单调栈的，这个我来想一下，该如何来实现
        Stack<int> stack = new Stack<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            while (stack.Count != 0 && stack.Peek() > num && nums.Length - i + stack.Count > k)
            {
                stack.Pop();
            }
            stack.Push(num);
        }
        while (stack.Count > k) {
            stack.Pop();
        }
        for (int i = k - 1; i >= 0; i--) {
            res[i] = stack.Pop();
        }
        return res;
    }
    
    //超时拉
    public int[] MostCompetitiveOri(int[] nums, int k)
    {
        int[] ret = new int[k];
        int n = 0,left = 0;
        while (n<k)
        {
            int min = Int32.MaxValue;
            int minIndex = left;
            for (int i = left; i <= nums.Length - k + n; i++)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            left = minIndex + 1;
            ret[n] = min;
            n++;
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}