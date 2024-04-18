namespace Demo48;
public static class MatrixExtensions
{
    public static T[][] Transpose<T>(this T[][] matrix)
    {
        return Enumerable.Range(0, matrix[0].Length)
            .Select(c => Enumerable.Range(0, matrix.Length)
                .Select(r => matrix[r][c])
                .ToArray())
            .ToArray();
    }
}
class Program
{
    public void Rotate(int[][] matrix)
    {
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var i1 = 0; i1 < i; i1++)
            {
                swap(ref matrix[i][i1],ref matrix[i1][i]);
            }
        }
        
        foreach (var t in matrix)
        {
            for (var i1 = 0; i1 < t.Length/2; i1++)
            {
                swap(ref t[i1],ref t[^(i1+1)]);
            }
        }

        return;

        void swap(ref int a,ref int b)
        {
            (a, b) = (b, a);
        }
    }


    public void RotateA(int[][] matrix)
    {
        matrix = matrix.Transpose();
        foreach (var t in matrix)
        {
            Console.WriteLine($"{t.Aggregate("{ ", (current, i1) => current + (i1 + ","))}}}");
        }
    }

    
    static void Main(string[] args)
    {
        int[][] matirx = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        Program program = new Program();
        program.RotateA(matirx);
        Console.WriteLine("Hello, World!");
    }
}