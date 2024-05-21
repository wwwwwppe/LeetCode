namespace Demo1146;

class Program
{
    static void Main(string[] args)
    {
        SnapshotArrayTwo a = new SnapshotArrayTwo(4);
        a.Snap();
        a.Snap();
        a.Get(3, 1);
        a.Set(2,4);
        a.Snap();
        a.Set(1,4);
        Console.WriteLine("Hello, World!");
    }
}