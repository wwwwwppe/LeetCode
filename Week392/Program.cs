namespace Week392;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Gram3 gram3 = new Gram3();

        int[] a = [1000000000,1000000000,1000000000];
        int k = 1;
        Console.WriteLine(gram3.MinOperationsToMakeMedianK(a, k));
    }
}