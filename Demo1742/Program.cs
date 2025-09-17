namespace Demo1742;

class Program
{
    /*
     *  想一下思路
     *  这是一个简单题，所以不难，但是现在的我太久没写了，所以需要来想一想
     *  2025-2-13 9:56
     *  最简单的方法，写一个方法，单独算出的方法，然后再一个循环
     *  我先来考一下
     *  2025-2-13 11:00
     *  错了一次，之前没有考虑abb的范围，直接取当前值的长度去了。
     * */
    public int CountBalls(int lowLimit, int highLimmit)
    {
        int a = highLimmit;
        int b = 1;
        while (a > 0)
        {
            b *= 10;
            a /= 10;
        }
        int[] abb = new int[b];
        for (int i = lowLimit; i <= highLimmit; i++)
        {
            abb[getSameNums(i)]++;
        }

        return abb.Max();
    }

    int getSameNums(int nums)
    {
        int ret = 0;
        while (nums > 0)
        {
            ret += nums % 10;
            nums /= 10;
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}