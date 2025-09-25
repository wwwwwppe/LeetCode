namespace Demo1657;

class Program
{
    public bool CloseStrings(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;
        if (word1.Except(word2).Any()) return false;
        var wordOne = word1.GroupBy(x => x)
            .Select(g => g.Count())
            .OrderBy(x => x)
            .ToArray();

        var wordTwo = word2.GroupBy(x => x)
            .Select(g => g.Count())
            .OrderBy(x => x)
            .ToArray();

        return !wordOne.Where((t, i) => t != wordTwo[i]).Any();
    }

    public bool CloseStringsQuick(string word1, string word2)
    {
        if (word1.Length != word2.Length) return false;

        // 字符集合需完全相同
        if (!word1.ToHashSet().SetEquals(word2)) return false;

        // 计数多重集需相同（排序后逐项相等）
        var counts1 = word1.GroupBy(c => c).Select(g => g.Count()).OrderBy(x => x);
        var counts2 = word2.GroupBy(c => c).Select(g => g.Count()).OrderBy(x => x);
        return counts1.SequenceEqual(counts2);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}