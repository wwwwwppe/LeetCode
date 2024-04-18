namespace Demo498;

class Program
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int[][] ints = [[-1, 1], [1, -1]];
        int m = mat.Length;
        int n = mat[0].Length;
        int[] ret = new int [m * n];
        int x = 0, y = 0;
        int way = 0;
        for (int i = 0; i < m * n; i++)
        {
            ret[i] = mat[x][y];
            if (way == 0)
            {
                if (x == 0 && y != n - 1)
                {
                    y++;
                    way = 1;
                }
                else if (y == n - 1)
                {
                    x++;
                    way = 1;
                }
                else
                {
                    x += ints[0][0];
                    y += ints[0][1];
                }
            }else if (way == 1)
            {
                if (y == 0 & x != m - 1)
                {
                    x++;
                    way = 0;
                }else if (x == m - 1)
                {
                    y++;
                    way = 0;
                }
                else
                {
                    x += ints[1][0];
                    y += ints[1][1];
                }
            }
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        // int[][] a = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        int[][] a = [[2, 3]];
        program.FindDiagonalOrder(a);
        Console.WriteLine("Hello, World!");
    }
}