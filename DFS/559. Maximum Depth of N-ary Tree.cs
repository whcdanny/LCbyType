//Leetcode 559. Maximum Depth of N-ary Tree ez
//题意：给定一个 N 叉树，找到其最大深度。 N 叉树是一棵树，其中每个节点最多有 N 个子节点。
//思路：（DFS）遍历 N 叉树。对于每个节点，递归计算其所有子节点的最大深度，并返回最大深度加 1（加 1 是因为要包括当前节点）。
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(w)，其中 w 为树的最大宽度
        public class Node_MaxDepth
        {
            public int val;
            public IList<Node_MaxDepth> children;

            public Node_MaxDepth() { }

            public Node_MaxDepth(int _val)
            {
                val = _val;
            }

            public Node_MaxDepth(int _val, IList<Node_MaxDepth> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public int MaxDepth(Node_MaxDepth root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxChildDepth = 0;
            foreach (Node_MaxDepth child in root.children)
            {
                maxChildDepth = Math.Max(maxChildDepth, MaxDepth(child));
            }

            return maxChildDepth + 1;
        }