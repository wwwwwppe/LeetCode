namespace Demo2332;

class Program
{
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
        Array.Sort(buses);
        Array.Sort(passengers);
        var j = 0;
        for (int i = 0; i < buses.Length; i++)
        {
            int maxJ = j + capacity;
            if (maxJ > passengers.Length)
                return findLast(buses[^1],passengers);
            for (; j <maxJ; j++)
            {
                if (passengers[j] > buses[i]){
                    break;
                }
            }
            if (i == buses.Length - 1 && j == maxJ) j--;
        }
        return findLast(Math.Min(buses[^1],passengers[j]), passengers);
    }

    private int findLast(int val, int[] ints)
    {
        for (int i = val; i >= 0; i--)
        {
            if (!ints.Contains(i))
                return i;
        }
        return 0;
    }

    static void Main(string[] args)
    {
        Program p = new Program();
        var buses = Array.Empty<int>();
        var passengers = Array.Empty<int>();
        var capacity = 2;
        
        // buses = new int[] { 10,20 };
        // passengers = new int[] { 2,17,18,19 };
        // Console.WriteLine(p.LatestTimeCatchTheBus(buses, passengers, capacity));
        buses = [20, 30, 10];
        passengers = [19, 13, 26, 4, 25, 11, 21];
        Console.WriteLine(p.LatestTimeCatchTheBus(buses, passengers, capacity));
    }
}
