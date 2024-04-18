namespace Demo59;

public class Program
{
    public int[][] GenerateMatrix(int n)
    {
        int[][] ints = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        var nn = new int[n][];
        for (var i = 0; i < nn.Length; i++)
        {
            nn[i] = new int[n];
        }
        int x,y,a = 0, b = 0,way = 0;
        for (int i = 1; i <= n * n; i++)
        {
            nn[a][b] = i;
            getNextWay();
            a += x;
            b += y;
        }
        return nn;

        void getNextWay()
        {
            way = way switch
            {
                0 when (b >= n - 1 || nn[a][b + 1] != 0) => 1,
                1 when (a >= n - 1 || nn[a + 1][b] != 0) => 2,
                2 when (b <= 0 || nn[a][b - 1] != 0) => 3,
                3 when (a <= 0 || nn[a - 1][b] != 0) => 0,
                _ => way
            };
            x = ints[way][0];
            y = ints[way][1];
        }
    }
    
    public int[][] GenerateMatrixOri(int n) {
        var nn = new int[n][];
        for (var i = 0; i < nn.Length; i++)
        {
            nn[i] = new int[n];
        }

        int x, y;
        int a = 0, b = 0;
        int way = 0;
        for (int i = 1; i <= n * n; i++)
        {
            nn[a][b] = i;
            way = getNextWay(way);
            wayGo(way);
            a += x;
            b += y;
        }

        return nn;
        void wayGo(int num)
        {
            switch (num)
            {
                case 0:
                    x = 0;
                    y = 1;
                    break;
                case 1:
                    x = 1;
                    y = 0;
                    break;
                case 2:
                    x = 0;
                    y = -1;
                    break;
                case 3:
                    x = -1;
                    y = 0;
                    break;
                default:
                    x = 0;
                    y = 0;
                    break;
            }
        }

        int getNextWay(int i)
        {
            i = i switch
            {
                0 when (b >= n - 1 || nn[a][b + 1] != 0) => 1,
                1 when (a >= n - 1 || nn[a + 1][b] != 0) => 2,
                2 when (b <= 0 || nn[a][b - 1] != 0) => 3,
                3 when (a <= 0 || nn[a - 1][b] != 0) => 0,
                _ => i
            };

            return i;
        }
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        int n = 3;
        var a = program.GenerateMatrix(n);
        foreach (var t in a)
        {
            string b = t.Aggregate("{ ", (current, i1) => current + (i1 + ","));
            b += " }";
            Console.WriteLine(b);
        }
    }
}