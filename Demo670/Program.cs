using System.Globalization;

namespace Demo670;

class Program
{

    public int MaximumSwap(int num)
    {
        var arr = num.ToString().ToCharArray();
        for (var i = 0; i < arr.Length; i++)
        {
            int[] maxIndexNum = [0,0];
            for (int j =  arr.Length-1; j > i; j--)
            {
                if (arr[j] > maxIndexNum[0])
                {
                    maxIndexNum[0] =arr[j];
                    maxIndexNum[1] = j;
                }
            }
            if (arr[i] < maxIndexNum[0])
            {
                (arr[i], arr[maxIndexNum[1]]) = (arr[maxIndexNum[1]], arr[i]);
                break;
            }
        }
        return int.Parse(arr);
    }
    
    public int MaximumSwapOri(int num)
    {
        int[] maxIndexNum = [0,0];
        var stringNum =  num.ToString();
        for (var i = stringNum.Length - 1; i >= 0; i--)
        {
            if (stringNum[i] > maxIndexNum[0])
            {
                maxIndexNum[0] = stringNum[i];
                maxIndexNum[1] = i;
            }
        }
        char[] arr = stringNum.ToCharArray();

        for (var i = 0; i < maxIndexNum[1]; i++)
        {
            if (arr[i] < maxIndexNum[0])
            {
                var temp = arr[i];
                arr[i] = (char)maxIndexNum[0];
                arr[maxIndexNum[1]] = temp;
                break;
            }
        }

        return int.Parse(arr);

    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        int num = 2736;
        var a = program.MaximumSwap(num);
        Console.WriteLine(a);
    }
}