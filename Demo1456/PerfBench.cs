using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Demo1456;

public static class PerfBench
{
    // 元音集合（仅小写）
    private static readonly HashSet<char> Vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsVowelHashSet(char c) => Vowels.Contains(c);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsVowelIndexOf(char c) => "aeiou".IndexOf(c) >= 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsVowelSwitch(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';

    // 三种 MaxVowels 实现（避免委托开销，分别实现）
    public static int MaxVowels_HashSet(string s, int k)
    {
        if (k <= 0 || string.IsNullOrEmpty(s)) return 0;
        if (k > s.Length) k = s.Length;

        int cnt = 0;
        for (int i = 0; i < k; i++) if (IsVowelHashSet(s[i])) cnt++;
        int best = cnt;

        for (int r = k; r < s.Length; r++)
        {
            if (IsVowelHashSet(s[r])) cnt++;
            if (IsVowelHashSet(s[r - k])) cnt--;
            if (cnt > best) best = cnt;
        }
        return best;
    }

    public static int MaxVowels_IndexOf(string s, int k)
    {
        if (k <= 0 || string.IsNullOrEmpty(s)) return 0;
        if (k > s.Length) k = s.Length;

        int cnt = 0;
        for (int i = 0; i < k; i++) if (IsVowelIndexOf(s[i])) cnt++;
        int best = cnt;

        for (int r = k; r < s.Length; r++)
        {
            if (IsVowelIndexOf(s[r])) cnt++;
            if (IsVowelIndexOf(s[r - k])) cnt--;
            if (cnt > best) best = cnt;
        }
        return best;
    }

    public static int MaxVowels_Switch(string s, int k)
    {
        if (k <= 0 || string.IsNullOrEmpty(s)) return 0;
        if (k > s.Length) k = s.Length;

        int cnt = 0;
        for (int i = 0; i < k; i++) if (IsVowelSwitch(s[i])) cnt++;
        int best = cnt;

        for (int r = k; r < s.Length; r++)
        {
            if (IsVowelSwitch(s[r])) cnt++;
            if (IsVowelSwitch(s[r - k])) cnt--;
            if (cnt > best) best = cnt;
        }
        return best;
    }

    // 仅判定函数的计数（用来隔离判定自身的开销）
    private static int CountVowels_HashSet(string s)
    {
        int cnt = 0;
        for (int i = 0; i < s.Length; i++) if (IsVowelHashSet(s[i])) cnt++;
        return cnt;
    }
    private static int CountVowels_IndexOf(string s)
    {
        int cnt = 0;
        for (int i = 0; i < s.Length; i++) if (IsVowelIndexOf(s[i])) cnt++;
        return cnt;
    }
    private static int CountVowels_Switch(string s)
    {
        int cnt = 0;
        for (int i = 0; i < s.Length; i++) if (IsVowelSwitch(s[i])) cnt++;
        return cnt;
    }

    // 防止 JIT 消除
    private static volatile int _sink;

    // 取 best-of-N，降低抖动
    private static (double nsPerChar, TimeSpan total) MeasureSliding(string s, int k, Func<string, int, int> algo, int rounds = 3)
    {
        // 预热
        _sink ^= algo(s, k);

        var best = TimeSpan.MaxValue;
        for (int i = 0; i < rounds; i++)
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            var sw = Stopwatch.StartNew();
            _sink ^= algo(s, k);
            sw.Stop();
            if (sw.Elapsed < best) best = sw.Elapsed;
        }
        double nsPerChar = best.Ticks * (1_000_000_000.0 / Stopwatch.Frequency) / Math.Max(1, s.Length);
        return (nsPerChar, best);
    }

    private static (double nsPerChar, TimeSpan total) MeasurePredicateOnly(string s, Func<string, int> func, int rounds = 3)
    {
        // 预热
        _sink ^= func(s);

        var best = TimeSpan.MaxValue;
        for (int i = 0; i < rounds; i++)
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            var sw = Stopwatch.StartNew();
            _sink ^= func(s);
            sw.Stop();
            if (sw.Elapsed < best) best = sw.Elapsed;
        }
        double nsPerChar = best.Ticks * (1_000_000_000.0 / Stopwatch.Frequency) / Math.Max(1, s.Length);
        return (nsPerChar, best);
    }

    // 构造测试用例
    private static string MakeRandomString(int length, int seed = 42)
    {
        var rng = new Random(seed);
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        var arr = new char[length];
        for (int i = 0; i < arr.Length; i++) arr[i] = letters[rng.Next(letters.Length)];
        return new string(arr);
    }

    private static string MakeRepeated(string alphabet, int length)
    {
        var sb = new StringBuilder(length);
        while (sb.Length < length)
        {
            int toCopy = Math.Min(alphabet.Length, length - sb.Length);
            sb.Append(alphabet, 0, toCopy);
        }
        return sb.ToString();
    }

    public static void Run()
    {
        // 数据规模可按需调整
        int n = 200_000;
        var cases = new (string name, string s)[]
        {
            ("Random",     MakeRandomString(n, 42)),
            ("AllVowels",  MakeRepeated("aeiou", n)),
            ("NoVowels",   MakeRepeated("bcdfghjklmnpqrstvwxyz", n)),
        };
        int[] ks = [1, 5, 20, 100];

        Console.WriteLine("=== Sliding Window: MaxVowels 对比（时间为 best-of-3） ===");
        foreach (var (name, s) in cases)
        {
            foreach (var k in ks)
            {
                var m1 = MeasureSliding(s, k, MaxVowels_HashSet);
                var m2 = MeasureSliding(s, k, MaxVowels_IndexOf);
                var m3 = MeasureSliding(s, k, MaxVowels_Switch);
                Console.WriteLine($"{name}, k={k}: HashSet {m1.total.TotalMilliseconds:F2} ms ({m1.nsPerChar:F2} ns/char), " +
                                  $"IndexOf {m2.total.TotalMilliseconds:F2} ms ({m2.nsPerChar:F2} ns/char), " +
                                  $"switch {m3.total.TotalMilliseconds:F2} ms ({m3.nsPerChar:F2} ns/char)");
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== Predicate Only: 判定函数对比（时间为 best-of-3） ===");
        foreach (var (name, s) in cases)
        {
            var p1 = MeasurePredicateOnly(s, CountVowels_HashSet);
            var p2 = MeasurePredicateOnly(s, CountVowels_IndexOf);
            var p3 = MeasurePredicateOnly(s, CountVowels_Switch);
            Console.WriteLine($"{name}: HashSet {p1.total.TotalMilliseconds:F2} ms ({p1.nsPerChar:F2} ns/char), " +
                              $"IndexOf {p2.total.TotalMilliseconds:F2} ms ({p2.nsPerChar:F2} ns/char), " +
                              $"switch {p3.total.TotalMilliseconds:F2} ms ({p3.nsPerChar:F2} ns/char)");
        }
    }
}
