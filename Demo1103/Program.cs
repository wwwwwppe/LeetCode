namespace Demo1103;

class Program
{
    public int[] DistributeCandies(int candies, int num_people)
    {
        int a = 1;
        int[] rets = new int[num_people];
        while (candies > 0)
        {
            candies -= a;
            rets[(a-1) % num_people] += candies >0? a: candies + a;
            a++;
        }

        return rets;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}