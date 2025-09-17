using System.Diagnostics;

namespace Demo345;

class Program
{
    public string ReverseVowels(string s)
    {
        HashSet<char> vowels = [ 'a', 'e', 'i', 'o', 'u','A','E','I','O','U'];
        Char[] chars = s.ToCharArray();
        // List<char> vowelChars = chars.Where(t => vowels.Contains(t)).ToList();
        List<char> vowelChars = new List<char>();
        for (var i = 0; i < chars.Length; i++)
        {
            if(vowels.Contains(chars[i])) 
            {
                vowelChars.Add(chars[i]);
            }
        }
        for (int i = 0,j=vowelChars.Count-1; i < chars.Length; i++)
        {
            if (!vowels.Contains(s[i])) continue;
            chars[i] = vowelChars[j];
            j--;
        }
        return string.Join("", chars);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}