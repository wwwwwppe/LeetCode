namespace Demo11;

class Program
{
    public int MaxAreaNew(int[] height)
    {
        int[] a = [0,0];
        int left = 0, right = height.Length - 1;
        int n = height.Length;
        int res = 0;
        while (left<right)
        {
            if (height[left] < a[0])
            {
                left++;
                continue;
            }

            if (height[right] < a[1])
            {
                right--;
                continue;
            }

            a[0] = height[left];
            a[1] = height[right];

            res = Math.Max(res, Math.Min(a[0], a[1]) * (right - left + 1));

            if (a[0] > a[1])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return res;
    }
    
    public int MaxArea(int[] height)
    {
        int ret=0;
        int length = height.Length;
        int left = 0, right = length - 1;
        while (left < right)
        {
            if (height[left] * (length-1-left) < height[right] * right)
            {
                ret = Math.Max(ret, height[right] * right);
                left++;
            }
            else
            {
                ret = Math.Max(height[left] * (length - 1 - left), ret);
                right--;
            }
        }

        return ret;
    }

    public int MaxAreaOri(int[] height)
    {
        int ret = 0;
        for (var i = 0; i < height.Length; i++)
        {
            if (height[i] * Math.Max(i, height.Length - 1 - i) < ret) continue;
            int max = 0;
            for (int j = 0; j < i; j++)
            {
                if (height[j] >= height[i])
                {
                    max = height[i] * (i - j);
                    break;
                }
            }

            for (int j = height.Length - 1; j > i; j--)
            {
                if (height[j] >= height[i])
                {
                    max = Math.Max(max, height[i] * (j - i));
                    break;
                }
            }

            ret = Math.Max(ret, max);
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}