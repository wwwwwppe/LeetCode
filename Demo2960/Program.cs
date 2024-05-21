namespace Demo2960;

class Program
{
    public int CountTestedDevices(int[] batteryPercentages)
    {
        int ret = 0, demo = 0;
        foreach (var batteryPercentage in batteryPercentages)
        {
            if (batteryPercentage - demo <= 0) continue;
            ret++;
            demo++;
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}