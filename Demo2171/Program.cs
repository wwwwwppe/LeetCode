namespace Demo2171;

class Program
{
    public long MinimumRemoval(int[] beans)
    {
        Array.Sort(beans);
        long minSum = long.MaxValue;
        int left = 0, right = beans.Length - 1;
        while (left <= right)
        {
        }

        return 0;
    }

    public long MinimumRemovalOri(int[] beans)
    {
        Array.Sort(beans);
        long minSum = long.MaxValue;
        int down = 0;
        int limitR = beans.Length - 1;
        QuickSortEt(0, limitR);
        return minSum;

        void QuickSortEt(int left, int right)
        {
            int might = left + (right - left) / 2;
            long leftSum = 0, rightSum = 0;
            for (int i = 0; i < might; i++)
            {
                leftSum += beans[i];
            }

            for (int i = limitR; i > might; i--)
            {
                rightSum += beans[i] - beans[might];
            }

            if (leftSum >= minSum) return;
            if (rightSum >= minSum) return;

            if (leftSum + rightSum < minSum)
            {
                minSum = leftSum + rightSum;
                down = might;
            }

            if (left < might)
            {
                QuickSortEt(left, might);
            }

            if (might < right)
            {
                QuickSortEt(might + 1, right);
            }
        }
    }


    static void Main(string[] args)
    {
        Program program = new Program();
        int[] beans = [7, 77, 99, 100, 22, 53, 19];
        var a = program.MinimumRemovalOri(beans);
        Console.WriteLine(a);
    }
}