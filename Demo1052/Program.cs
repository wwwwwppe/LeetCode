namespace Demo1052;

class Program
{
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        int nums = 0;
        if (customers.Length != grumpy.Length)
        {
            return 0;
        }

        for (var i = 0; i < customers.Length; i++)
        {
            if (grumpy[i] == 1) continue;
            nums += customers[i];
            customers[i] = 0;
        }

        int left = 0, right = minutes-1;
        int max = 0,trueMax = 0;
        for (int i = 0; i <= right; i++)
        {
            max += customers[i];
        }

        trueMax = max;
        while (right<customers.Length-1)
        {
            max -= customers[left];
            right++;
            left++;
            max += customers[right];
            trueMax = Math.Max(trueMax, max);
        }

        return nums + trueMax;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}