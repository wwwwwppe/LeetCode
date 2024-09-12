namespace Demo3115;

class Program
{
    public int MaximumPrimeDifference(int[] nums)
    {
        HashSet<int> prime = [];
        HashSet<int> noPrime = [];
        prime.Add(2);
        List<int> lists = [];
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (prime.Contains(num))
            {
                if (lists.Count == 0)
                {
                    lists.Add(i);
                    lists.Add(i);
                }
                else
                {
                    lists[1] = i;
                }
                continue;
            }

            if (noPrime.Contains(num)||num == 1)
            {
                continue;
            }
            
            int a = (int)Math.Sqrt(num);
            var isPrime = true;
            for (int j = 2; j <= a; j++)
            {
                if (num%j==0)
                {
                    noPrime.Add(num);
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                prime.Add(num);
                if (lists.Count == 0)
                {
                    lists.Add(i);
                    lists.Add(i);
                }
                else
                {
                    lists[1] = i;
                } 
            }
        }

        return lists[1] - lists[0];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}