namespace Demo2352;

class Program
{
    public int EqualPairs(int[][] grid)
    {
        int n = grid.Length;
        int ret = 0;
        List<int[]> rows = [];
        List<int[]> columns = [];
        for (int row = 0; row < grid.Length; row++)
        {
            var row1 = grid[row];
            rows.Add(row1);
        }

        for (int column = 0; column < grid[0].Length; column++)
        {
            int[] column1 = new int[grid[column].Length];
            for (int row = 0; row < grid.Length; row++)
            {
               column1[row] = grid[row][column]; 
            }
            columns.Add(column1);
        }

        for (int row = 0; row < rows.Count; row++)
        {
            for (int column = 0; column < columns.Count; column++)
            {
                var a = true;
                for (int k = 0; k < n; k++)
                {
                    if (rows[row][k] != columns[column][k])
                    {
                        a = false;
                        break;
                    }
                }
                if (a) ret++;
            }
        }
        
        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}