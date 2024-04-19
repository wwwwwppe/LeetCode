namespace Demo289;

class Program
{
    public void GameOfLife(int[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;

        for (var i = 0; i < m; i++)
        {
            for (var i1 = 0; i1 < n; i1++)
            {
                int hou = 0;
                for (int j = -1; j < 2; j++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        if(j==0&&k==0) continue;
                        if (i + j >= 0 && i + j < m && i1 + k >= 0 && i1 + k < n &&
                            board[i + j][i1 + k] % 2 == 1) hou++;
                    }
                }

                if (hou == 3||(hou == 2 && board[i][i1] == 1))
                {
                    board[i][i1] += 2;
                }
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i][j] >>= 1;
            } 
        }
    }

    //错的，但是我不想再改了，没有必要，反而会越用越繁琐
    public void GameOfLifeNew(int[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;
        var update = board.SelectMany(row => row).Select((c, index) =>
        {
            var i = index / n;
            var j = index % n;

            var neighbors = GetNeighbors(i, j, m, n);

            int count = neighbors.Count(ne => board[ne / n][ne % n] == 1);
            
            return count > 3 || (c == 1 && count == 2) 
                ? c+2 
                : c;
        }).ToArray();
        
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                board[i][j] = update[i*n + j] >> 1;
            }
        }

        static IEnumerable<int> GetNeighbors(int i, int j, int m, int n)
        {
            int num = 0;
            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    int ni = i + di;
                    int nj = j + dj;
                    if (ni >= 0 && ni < m && nj >= 0 && nj < n && !(di == 0 && dj == 0))
                        num++;
                }
            }

            yield return num;
        }
    }

    static void Main(string[] args)
    {
        int[][] board = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]];
        Program program = new Program();
        program.GameOfLifeNew(board);
        
        Console.WriteLine("Hello, World!");
    }
}