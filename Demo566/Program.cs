namespace Demo566;

class Program
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        // 如果原矩阵大小和目标矩阵大小不匹配,则直接返回原矩阵
        if (m * n != r * c)
            return mat;
        var lists = mat.SelectMany(x => x).ToList();

        int total = lists.Count;

        return Enumerable.Range(0, r)
            .Select(i => {
                var start = i * c;  
                var end = Math.Min(start + c, total);

                return Enumerable.Range(start, end - start)
                    .Select(j => lists[j])
                    .ToArray();
            })
            .ToArray();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}