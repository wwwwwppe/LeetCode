namespace Demo57;

class Program
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> lists = [];
        bool isPlay = false;
        int[] temp = new int[2];
        for (var i = 0; i < intervals.Length; i++)
        {
            if (!isPlay)
            {
                if (intervals[i][0] >= newInterval[0])
                {
                    temp[0] = newInterval[0];
                    isPlay = true;
                }
                else if (intervals[i][0] < newInterval[0] && intervals[i][1] >= newInterval[0])
                {
                    temp[0] = intervals[i][0];
                    isPlay = true;
                }
            }

            if (isPlay  &&  )
            {
                
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}