namespace Node;

public class Program
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}