589. N-ary Tree Preorder Traversal		
//C#	
	/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
		public List<int> preorder(Node root)
        {
            List<int> preorderTraversal = new List<int>();

            if (root == null)
            {
                return preorderTraversal;
            }

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count!=0)
            {
                Node node = stack.Pop();
                preorderTraversal.Add(node.val);

                for (int i = node.children.Count - 1; i >= 0; i--)
                {
                    Node child = node.children[i];
                    if (child != null)
                    {
                        stack.Push(node.children[i]);
                    }
                }
            }

            return preorderTraversal;
        }