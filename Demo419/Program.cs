namespace Demo419;

public class Program
{
    public int CountBattleships(char[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;
        int num = 0;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'X')
                {
                    num++;
                    if (j < n - 1 && board[i][j + 1] == 'X')
                    {
                        int k = j + 1;
                        while (k < n && board[i][k] == 'X')
                        {
                            board[i][k] = '.';
                            k++;
                        }
                    }
                    else if (i < m - 1)
                    {
                        int k = i + 1;
                        while (k < m && board[k][j] == 'X')
                        {
                            board[k][j] = '.';
                            k++;
                        }
                    }
                }
            }
        }
        
        return num;
    }

    public static void Main(string[] args)
    {
    }
}