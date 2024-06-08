namespace Demo3040;

class Program
{
    private int[] nums;
    private int[][] memo;
    
    public int MaxOperations(int[]? nums)
    {
        int n = nums.Length;
        this.nums = nums;
        this.memo = new int[n][];
        for (int i = 0; i < n; i++)
        {
            memo[i] = new int [n];
        }

        int res = 0;
        res = Math.Max(res, Helper(0, n - 1, nums[0] + nums[n - 1]));
        res = Math.Max(res, Helper(0, n - 1, nums[0] + nums[1]));
        res = Math.Max(res, Helper(0, n - 1, nums[n - 2] + nums[n - 1]));
        return res;

    }

    public int Helper(int i, int j, int target)
    {
        for (var i1 = 0; i1 < nums.Length; i1++)
        {
           Array.Fill(memo[i1],-1 ); 
        }

        return DFS(i, j, target);

    }


    int DFS(int i,int j,int target)
    {
        if (i >= j)
        {
            return 0;
        }

        if (memo[i][j] != -1)
        {
            return memo[i][j];
        }

        int ans = 0;
        
        if(nums[i] + nums[i + 1] == target)
        {
            ans = Math.Max(ans, DFS(i + 2, j, target));
        }

        if (nums[j - 1] + nums[j] == target)
        {
            ans = Math.Max(ans, DFS(i, j - 2, target) + 1);
        }

        if (nums[i] + nums[j] == target)
        {
            ans = Math.Max(ans, DFS(i + 1, j - 1, target) + 1);
        }

        memo[i][j] = ans;
        return ans;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}