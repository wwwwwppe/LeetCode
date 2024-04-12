namespace Demo661;

class Program
{
    public int[][] ImageSmoother(int[][] img)
    {
        int m = img.Length;
        int n = img[0].Length;
        int[][] a = new int[m][];
        for (int i = 0; i < m; i++)
        {
            a[i] = new int[n];
        }
        for (int i = 0; i <m; i++)
        {
            for (var i1 = 0; i1 < img[m].Length; i1++)
            {
                int num = 0,sum = 0;
                for(int x = i-1;x<=i+1;x++)
                {
                    for(int y = i1-1;y<=i1+1;y++)
                    {
                        if(x>=0&&x<m&&y>=0&&y<n)
                        {
                            num++;
                            sum += img[x][y];
                        }
                    }
                }
                a[i][i1] = sum / num;
            }
        }
        return a;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}