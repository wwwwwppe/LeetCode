using System.Text;

namespace Demo49;

class Program
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            int[] ints = new int[26];
            foreach (var c in str)
            {
                ++ints[c - 'a'];
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (var i = 0; i < ints.Length; i++)
            {
                if (ints[i] != 0)
                {
                    char cc = (char)(i + 'a');
                    stringBuilder.Append(cc);
                    stringBuilder.Append(ints[i]);
                } 
            }

            if (!dictionary.TryAdd(stringBuilder.ToString(), [str]))
            {
                dictionary[stringBuilder.ToString()].Add(str);
            }
        }

        return dictionary.Values.Cast<IList<string>>().ToList();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}