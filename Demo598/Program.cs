namespace Demo598;

public class Program {

    public int MaxCount(int m, int n, int[][] ops)
    {
        if(ops.Length==0) return m*n;
        int a = ops.Min(x => x[0]);
        int b = ops.Min(x => x[1]);
        return a *b;
        
//        int max = a.Max(x => x.Max());
//        return a.Sum(x => x.Count(c => c==max));
    }
    
    public static void Main(string[] args)
    {
        
    }
}