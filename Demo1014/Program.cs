namespace Demo1014;

class Program
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        int max = 0,
            left = 0,
            right = 1;
        while (right < values.Length)
        {
            max = Math.Max(max, values[right] + values[left] + left - right);
            if (values[left] - values[right] < right - left)
            {
                left = right;
            }
            right++;
        }
        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
