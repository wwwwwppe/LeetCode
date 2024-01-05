namespace Demo2022;

class Program
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (original.Length != m * n) return [];
        int[][] lists = new int[m][];
        for (int i = 0; i < m; i++)
        {
            lists[i] = new int[n];
            for (int i1 = 0; i1 < n; i1++)
            {
                lists[i][i1] = original[i*n+i1];
            }
        }

        return lists;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}