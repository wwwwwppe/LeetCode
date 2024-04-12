namespace Demo119;

class Program
{
    public IList<int> GetRow(int numRows) {
        if (numRows == 1) return [1];
        if (numRows == 2) return [1, 1];

        IList<IList<int>> ret = [[1], [1, 1]];
        List<int> a = [1];
        for (int i = 3; i <= numRows; i++)
        {
            a = [1];
            for (int j = 1; j <i-1; j++)
            {
                a.Add(ret[i - 2][j-1] + ret[i-2][j]);
            }
            a.Add(1);
            ret.Add(a);
        }

        return a;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}