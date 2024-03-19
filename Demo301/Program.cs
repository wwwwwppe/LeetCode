namespace Demo301;

class Program
{
    
    
    static void Main(string[] args)
    {
        int n = 10; // 假设我们要生成前10个斐波那契数
        long[] fibonacciSeries = new long[n];

        // 初始化前两个斐波那契数
        fibonacciSeries[0] = 0;
        fibonacciSeries[1] = 1;

        // 使用迭代生成斐波那契数列
        for (int i = 2; i < n; i++)
        {
            fibonacciSeries[i] = fibonacciSeries[i - 1] + fibonacciSeries[i - 2];
        }

        // 打印斐波那契数列
        foreach (var num in fibonacciSeries)
        {
            Console.Write(num + " ");
        }

        Console.ReadLine(); 
        
    }
}