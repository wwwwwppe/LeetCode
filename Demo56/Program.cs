namespace Demo56;

class Program
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        for (var i = intervals.Length - 1; i >= 1; i--)
        {
            if (intervals[i][0] > intervals[i - 1][^1]) continue;
            intervals[i - 1] = [intervals[i - 1][0],Math.Max(intervals[i-1][^1], intervals[i][^1])];
            intervals[i] = [-1,-1];
        }

        var lists = intervals.Where(interval => interval[0] != -1).ToList();

        var arr = lists.ToArray(); 
        for (var i = 0; i < arr.Length-1; i++)
        {
            if (arr[i][^1] < arr[i + 1][0]) continue;
            arr[i+1] = [arr[i][0],Math.Max(arr[i][^1], arr[i+1][^1])];
            arr[i] = [-1,-1];
        }
        lists = [];
        lists.AddRange(arr.Where(interval => interval[0] != -1));
        return lists.ToArray();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}