namespace Demo2786;

class Program
{
    public long MaxScore(int[] nums, int x)
    {
        List<long> longs = [];
        bool isZero = nums[0] % 2 == 0;
        long sum = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            bool b = nums[i] % 2 == 0;
            if (b == isZero)
            {
                sum += nums[i];
            }
            else
            {
                isZero = b;
                longs.Add(sum);
                sum = nums[i];
            }
        }
        longs.Add(sum);
        long[] newLongs = new long[longs.Count + 1];
        newLongs[0] = Int64.MinValue;
        newLongs[1] = longs[0];
        for (var i = 1; i < longs.Count; i++)
        {
            newLongs[i + 1] = Math.Max(longs[i] + newLongs[i - 1], longs[i] + newLongs[i] - x);
        }

        return newLongs.Max();
    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        program.MaxScore([38,92,23,30,25,96,6,71,78,77,33,23,71,48,87,77,53,28,6,20,90,83,42,21,64,95,84,29,22,21,33,36,53,51,85,25,80,56,71,69,5,21,4,84,28,16,65,7], 52);
        Console.WriteLine("Hello, World!");
    }
}