//Leetcode 589. N-ary Tree Preorder Traversal ez
//题意：给定一个 N 叉树，返回其前序遍历。       
//思路：DFS）进行后序遍历，递归或迭代都可以。
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(h)，其中 h 为二叉树的高度。
        public class Node_Preorder
        {
            public int val;
            public IList<Node_Preorder> children;

            public Node_Preorder() { }

            public Node_Preorder(int _val)
            {
                val = _val;
            }

            public Node_Preorder(int _val, IList<Node_Preorder> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public IList<int> Preorder(Node_Preorder root)
        {
            List<int> result = new List<int>();
            PreorderDFS(root, result);
            return result;
        }

        private void PreorderDFS(Node_Preorder node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.val);

            foreach (var child in node.children)
            {
                PreorderDFS(child, result);
            }
        }