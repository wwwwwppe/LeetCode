namespace Demo3033;

class Program
{
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        var maxs = new int[n];
        for (int i = 0; i < n; i++)
        {
            int max = 0;
            for (int j = 0; j < m; j++)
            {
                max = Math.Max(matrix[j][i], max);
            }
            maxs[i] = max;
        }

        var ret = new int[m][];
        for (var i = 0; i < ret.Length; i++)
        {
            ret[i] = matrix[i];
        }
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (ret[j][i] == -1)
                {
                    ret[j][i] = maxs[i];
                }
            }
        }

        return ret;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}