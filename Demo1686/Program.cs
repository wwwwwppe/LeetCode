namespace Demo1686;

class Program
{
    public int StoneGameVI(int[] aliceValues, int[] bobValues)
    {
        int numA = 0, numB = 0;
        if (aliceValues.Length != bobValues.Length) return 0;
        int[][] arr = new int[aliceValues.Length][];
        for (var i = 0; i < arr.Length; i++)
        {
            // 初始化内层数组
            arr[i] = new int[2]; 
            arr[i][0] = aliceValues[i] + bobValues[i];
            arr[i][1] = i;
        }
        
        Array.Sort(arr,(a,b) => a[0] - b[0]);
        
        for (var i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
                numA += aliceValues[arr[i][1]];
            else
                numB += bobValues[arr[i][1]];
        }

        return numA > numB ? 1 : numA == numB ? 0 : -1;
    }
    
    static void Main(string[] args)
    {
        int[] arr = [1, 3];
        int[] brr = [2, 1];
        Program program = new Program();
        int a = program.StoneGameVI(arr, brr);
        Console.WriteLine(a);
    }
}