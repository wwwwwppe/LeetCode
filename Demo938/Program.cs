namespace Demo938;

class Program
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root==null){
            return 0;
        }
        if(root.val>high){
            return RangeSumBST(root.left,low,high);
        }
        if(root.val<low){
            return RangeSumBST(root.right,low,high);
        }
        return root.val+RangeSumBST(root.left,low,high)+RangeSumBST(root.right,low,high);;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}