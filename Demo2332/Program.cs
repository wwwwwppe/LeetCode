namespace Demo2332;

class Program
{
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
        Array.sort(bases);
        Array.sort(passengers);
        var j = 0;
        for (int i = 0; i < buses.Count(); i++)
        {
            int maxJ = j + capacity;
            if (maxJ > passengers.Count() - 1)
                return buses[^1];
            for (; j <= maxJ; j++)
            {
                if (passengers[j] > buses[i])
                    break;
            }
        }
        return Math.Min(buses[^1], findLast(j, passengers));
    }

    private int findLast(int val, int[] ints)
    {
        for (int i = val; i >= 0; i--)
        {
            if (!ints.Contians(i))
                return i;
        }
        return 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
