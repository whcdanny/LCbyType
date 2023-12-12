//Leetcode 590. N-ary Tree Postorder Traversal  ez
//题意：给定一个 N 叉树，返回其后序遍历。
//思路：DFS）进行后序遍历，递归或迭代都可以。
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(h)，其中 h 为二叉树的高度。
        public class Node_Postorder
        {
            public int val;
            public IList<Node_Postorder> children;

            public Node_Postorder() { }

            public Node_Postorder(int _val)
            {
                val = _val;
            }

            public Node_Postorder(int _val, IList<Node_Postorder> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public IList<int> Postorder(Node_Postorder root)
        {
            List<int> result = new List<int>();
            PostorderDFS(root, result);
            return result;
        }

        private void PostorderDFS(Node_Postorder node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            foreach (var child in node.children)
            {
                PostorderDFS(child, result);
            }

            result.Add(node.val);
        }