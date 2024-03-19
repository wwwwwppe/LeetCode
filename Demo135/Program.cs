namespace Demo135;

class Program
{
    public static int Candy(int[] ratings)
    {
        int maxNum = 20001;
        int n = ratings.Length;
        int[] arr = new int[n];
        int[] brr = new int[n + 2];
        List<int> lists = Enumerable.Range(0, ratings.Length).ToList();
        brr[0] = maxNum;
        for (var i = 0; i < ratings.Length; i++)
        {
            brr[i + 1] = ratings[i];
        }

        brr[^1] = maxNum;
        for (var i = brr.Length - 2; i > 0; i--)
        {
            int r = i - 1;
            if (brr[i - 1] >= brr[i] && brr[i + 1] >= brr[i])
            {
                arr[r] = 1;
                lists.Remove(r);
            }
        }

        while (lists.Count != 0)
        {
            for (var j = lists.Count - 1; j >= 0; j--)
            {
                int i = lists[j];
                int l = i + 1;
                if (brr[l - 1] >= brr[l] && brr[l] > brr[l + 1])
                {
                    if (arr[i + 1] != 0)
                    {
                        arr[i] = arr[i + 1] + 1;
                        lists.Remove(i);
                    }
                }
                else if (brr[l - 1] < brr[l] && brr[l] <= brr[l + 1])
                {
                    if (arr[i - 1] != 0)
                    {
                        arr[i] = arr[i - 1] + 1;
                        lists.Remove(i);
                    }
                }else if (brr[l - 1] <= brr[l] && brr[l + 1] <= brr[l])
                {
                    if(arr[i-1]!=0&&arr[i+1]!=0)
                    {
                        arr[i] = Math.Max(arr[i - 1], arr[i + 1]) + 1;
                        lists.Remove(i);
                    }
                }
            }
        }

        return arr.Sum();
    }

    static void Main(string[] args)
    {
        int[] ratings = [1, 2, 2];
        Console.WriteLine(Candy(ratings));
    }
}