namespace Demo2244;

class Program
{
    public int MinimumRounds(int[] tasks)
    {
        int ret = 0;
        var a = tasks.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        foreach (var (_, value) in a)
        {
            if (value == 1)
            {
                return -1;
            }

            ret += (value + 2) / 3;
        }

        return ret;
    }
    
    public int MinimumRoundsNew(int[] tasks)
    {
        // ERROR 不行还是没有办法判断值为1然后直接跳出来的一行代码 (2024年5月14日 9:03:21)
        return tasks.GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count())
                .Aggregate(0, (acc, piar) => acc + (piar.Value + 2) / 3)
            ;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}