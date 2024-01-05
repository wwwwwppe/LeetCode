namespace Demo2397;

class Program
{
    public int MaximumRows(int[][] matrix, int numSelect)
    {
        List<int> lists = new List<int>();
        for (var i = 0; i < matrix[0].Length; i++)
        {
            for (var i1 = 0; i1 < matrix.Length; i1++)
            {
                if (matrix[i1][i] != 0)
                {
                    lists.Add(i);
                    break;
                } 
            }
        }

        return 0;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}