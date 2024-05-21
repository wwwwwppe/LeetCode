namespace Demo1542;

class Program
{
    public int LongestAwesome(string s) {
        var map = new Dictionary<int, int>();
        map[0] = -1;
        var mask = 0;
        var res = 0;
        for (var i = 0; i < s.Length; i++) {
            mask ^= 1 << (s[i] - '0');
            if (map.TryGetValue(mask, out int value)) {
                res = Math.Max(res, i - value);
            }
            for (var j = 0; j < 10; j++) {
                if (map.ContainsKey(mask ^ (1 << j))) {
                    res = Math.Max(res, i - map[mask ^ (1 << j)]);
                }
            }
            map.TryAdd(mask, i);
        }
        return res;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}