namespace Demo1017;

class Program
{
  public string BaseNeg2(int n)
  {
    if (n == 0) return "0";
    int length = 1;
    string s = "";
    double a = 0;
    while (n > Math.Pow(4, length) - 3)
    {
      length++;
    }

    return s.Trim();
  }

  static void Main(string[] args)
  {
    Console.WriteLine("Hello, World!");
  }
}
