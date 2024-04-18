namespace Demo54;

public class Program
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> list = [];
        int m = matrix.Length;
        int n = matrix[0].Length;
        int mm = 0, nn = 0;
        int way = 0;
        for (int i = 0; i < m * n; i++)
        {
            list.Add(matrix[mm][nn]);
            if (way == 0 && (nn + 1 >= n || matrix[mm][nn+1] == 101))
            {
                way = 1;
            }

            if (way == 1 && (mm + 1 >= m || matrix[mm+1][nn] == 101))
            {
                way = 2;
            }

            if (way == 2 && (nn - 1 < 0 || matrix[mm][nn-1] == 101))
            {
                way = 3;
            }

            if (way == 3 && (mm - 1 < 0 || matrix[mm-1][nn] == 101))
            {
                way = 0;
            }

            matrix[mm][nn] = 101;
            switch (way)
            {
                case 0:
                    nn++;
                    break;
                case 1:
                    mm++;
                    break;
                case 2:
                    nn--;
                    break;
                case 3:
                    mm--;
                    break;
            }
        }
        return list;
    }

    public static void Main(string[] args)
    {
        
    }
}