// 完成一个TreeNode类
// 1. 有一个属性为int类型的val
// 2. 有一个属性为TreeNode类型的left
// 3. 有一个属性为TreeNode类型的right
// 4. 有一个构造函数，接受一个int类型的参数，将参数赋值给val
// 5. 有一个构造函数，接受一个int类型的参数和两个TreeNode类型的参数，将参数分别赋值给val、left、right
// 6. 有一个方法，接受一个TreeNode类型的参数，将参数赋值给left
// 7. 有一个方法，接受一个TreeNode类型的参数，将参数赋值给right

namespace TreeNode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}