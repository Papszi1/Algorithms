namespace BinaryTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TreeNode root = new TreeNode(4);

        }

    }
    
    public class TreeNode
    {
        public TreeNode? left;
        public TreeNode? right;
        public int value;
        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }


    public class Tree
    {
        public TreeNode root;
        public Tree(TreeNode root)
        {
            this.root = root;
        }

        public void Insert(int number)
        {
            root = InsertRec(root, number);
        }

        public TreeNode InsertRec(TreeNode? node, int number)
        {
            if (node == null)
            {
                TreeNode treeNode = new TreeNode(number);
                node = treeNode;
                return node;
            }
            if (number == node.value)
            {
                return node;
            }
            if (number > node.value)
            {
                node.right = InsertRec(node.right, number);
            }
            else
            {
                node.left = InsertRec(node.left, number);
            }

            return node;
        }
    }
}
