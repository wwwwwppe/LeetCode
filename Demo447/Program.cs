namespace Demo447;

class Program
{

    public int NumberOfBoomerangs(int[][] points)
    {
        int ans = 0;
        foreach (var point in points)
        {
            foreach (var ints in points)
            {
                
            }
        }

        return 0;
    }
    
    // 原来的这个会超时
    public int NumberOfBoomerangsOri(int[][] points)
    {
        if (points.Length < 3) return 0;
        int sum = 0;
        for (var i = 0; i < points.Length - 2; i++)
        {
            for (var i1 = i + 1; i1 < points.Length - 1; i1++)
            {
                for (var i2 = i1 + 1; i2 < points.Length; i2++)
                {
                    sum += JudgeEqual([points[i],points[i1],points[i2]]);
                }
            }
        }

        return sum;


        int JudgeEqual(int[][] point)
        {
            long a = (long)(Math.Pow(point[0][0] - point[1][0], 2) + Math.Pow(point[0][1] - point[1][1], 2));
            long b = (long)(Math.Pow(point[0][0] - point[2][0], 2) + Math.Pow(point[0][1] - point[2][1], 2));
            long c = (long)(Math.Pow(point[1][0] - point[2][0], 2) + Math.Pow(point[1][1] - point[2][1], 2));
            int res = 0;
            if (a == b) res++;
            if (a == c) res++;
            if (b == c) res++;
            return res * 2;
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}