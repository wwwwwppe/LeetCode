// See https://aka.ms/new-console-template for more information

public class Program
{
    int sum;
    public TreeNode.TreeNode BstToGst(TreeNode.TreeNode root) {
        if (root == null) {
            return null;
        }
        BstToGst(root.right);
        root.val += sum;
        sum = root.val;
        BstToGst(root.left);
        return root;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}