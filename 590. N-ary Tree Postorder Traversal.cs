590. N-ary Tree Postorder Traversal
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

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
		public IList<int> Postorder(Node root)
        {            
            List<int> lstResult = new List<int>();
            if (root == null)
                return lstResult;
            Stack<Node> st = new Stack<Node>();
            st.Push(root);
            while (st.Count != 0)
            {
                Node curr = st.Pop();
                lstResult.Add(curr.val);
                foreach (var item in curr.children)
                {
                    st.Push(item);
                }
            }
            lstResult.Reverse();
            return lstResult;
        }
