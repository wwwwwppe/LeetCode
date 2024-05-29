namespace Demo2018;

class Program
{
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int m = rolls.Length;
        int sumRolls = rolls.Sum();
        if (sumRolls + n > mean * (m + n) || mean * (m + n) > sumRolls + 6 * n) return [];
        int temp = mean * (m + n) - sumRolls;
        int a = temp / n;
        int b = temp % n;
        var ret = new int[n];
        Array.Fill(ret, a);
        for (int i = 0; i < b; i++)
        {
            ret[i]++;
        }

        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}