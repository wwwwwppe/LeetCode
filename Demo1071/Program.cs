namespace Demo1071;

class Program
{
    public string GcdOfStrings(string str1, string str2) {
        if (str1 + str2 != str2 + str1) return "";
        int gcdLength = Gcd(str1.Length, str2.Length);
        return str1[..gcdLength];
    }

    int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
