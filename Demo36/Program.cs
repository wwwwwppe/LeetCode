namespace Demo36;

class Program
{
    public bool IsValidSudoku(char[][] board)
    {
        if (!isBig())
        {
            return false;
        }

        if (!isNine())
        {
            return false;
        }

        return true;
        bool isBig()
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> hashSet = [];
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        continue;
                    }

                    if (!hashSet.Add(board[i][j]))
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                HashSet<char> hashSet = [];
                for (int j = 0; j < 9; j++)
                {
                    if (board[j][i] == '.') continue;
                    if (!hashSet.Add(board[j][i])) return false;
                }
            }

            return true;
        }

        bool isNine()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    HashSet<int> hashSet = [];
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (board[3*i+k][j+3*i] == '.')
                            {
                                continue;
                            }
                            if(!hashSet.Add(board[k + 3 * i][l + 3 * j]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}