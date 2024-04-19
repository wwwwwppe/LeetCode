namespace Demo304;

class Program
{
    static void Main(string[] args)
    {
        int[][] a = [[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]];
        NumMatrix numMatrix = new NumMatrix(a);
        int b = numMatrix.SumRegion(2, 1, 4, 3);
        Console.WriteLine(b);
    }
}