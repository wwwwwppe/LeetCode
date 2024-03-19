namespace Demo299;

class Program
{
    public string GetHint(string secret, string guess)
    {
        if (secret.Length != guess.Length)
            throw new ArgumentException("Secret and guess must be the same length.");

        int bulls = 0;
        int cows = 0;
        Dictionary<int, int> secretDigitCounts = new Dictionary<int, int>();
        Dictionary<int, int> guessDigitCounts = new Dictionary<int, int>();

        // 计算公牛（数字和位置都猜对）
        for (int i = 0; i < secret.Length; i++)
        {
            int secretDigit = secret[i] - '0';
            int guessDigit = guess[i] - '0';
            if (secretDigit == guessDigit)
            {
                bulls++;
            }
            else
            {
                // 更新秘密数字和猜测数字的计数
                UpdateDigitCounts(secretDigitCounts, secretDigit);
                UpdateDigitCounts(guessDigitCounts, guessDigit);
            }
        }

        // 计算奶牛（数字猜对但位置不对）
        foreach (var pair in secretDigitCounts)
        {
            int secretDigit = pair.Key;
            int secretCount = pair.Value;
            if (guessDigitCounts.ContainsKey(secretDigit))
            {
                int guessCount = guessDigitCounts[secretDigit];
                cows += Math.Min(secretCount, guessCount);
                // 从猜测数字的计数中减去已匹配的奶牛
                guessDigitCounts[secretDigit] -= secretCount;
            }
        }

        // 返回提示
        return $"{bulls}A{cows}B";
    }

    private void UpdateDigitCounts(Dictionary<int, int> digitCounts, int digit)
    {
        if (digitCounts.ContainsKey(digit))
        {
            digitCounts[digit]++;
        }
        else
        {
            digitCounts[digit] = 1;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}