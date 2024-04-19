namespace Demo73;

class Program
{
    public void SetZeroes(int[][] matrix)
    {
        HashSet<int> hen = [];
        HashSet<int> lie = [];

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var i1 = 0; i1 < matrix[i].Length; i1++)
            {
                if (matrix[i][i1] == 0)
                {
                    hen.Add(i);
                    lie.Add(i1);
                }
            }
        }

        foreach (var i in hen)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = 0;
            }
        }


        foreach (var t in matrix)
        {
            foreach (var i in lie)
            {
                t[i] = 0;
            }
        }
    }

    static void Main(string[] args)
    {
        int[][] matrix =
            [[1, 1, 1], [1, 0, 1], [1, 1, 1]];
        Program program = new Program();
        program.SetZeroes(matrix);
        Console.WriteLine("Hello, World!");
    }
}