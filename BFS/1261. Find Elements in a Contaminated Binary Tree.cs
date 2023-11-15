//Leetcode 1261. Find Elements in a Contaminated Binary Tree med
//题意：这是一个关于二叉树的问题，题目描述为：给定一个二叉树，其中节点值为 0 或 1，但是树中的节点已经被修改过。现在，树中所有节点的修改被反映在节点的 val 属性上，而不是 left 或 right 指针。需要实现 FindElements 类：
//FindElements(TreeNode* root)，用无效的 root 节点初始化该类。
//bool Find(int target)，判断值为 target 的节点是否存在于二叉树中。
//这里的二叉树被修改为满足以下条件：root.val == 0;如果 TreeNode.val == x 且 TreeNode.left != null，那么 TreeNode.left.val == 2 * x + 1;如果 TreeNode.val == x 且 TreeNode.right != null，那么 TreeNode.right.val == 2 * x + 2
//思路：BFS 的思路是在遍历二叉树的同时，修改每个节点的值，并使用 HashSet 存储修改后的值，以便在 Find 方法中进行快速查询。
//时间复杂度: FindElements: O(n), HashSet: O(1)。
//空间复杂度：FindElements: O(n), HashSet: O(1)。
        public class FindElements
        {
            private HashSet<int> values;

            public FindElements(TreeNode root)
            {
                values = new HashSet<int>();
                Queue<TreeNode> queue = new Queue<TreeNode>();
                root.val = 0;
                queue.Enqueue(root);
                values.Add(0);
                while (queue.Count > 0)
                {
                    TreeNode current = queue.Dequeue();
                    values.Add(current.val);

                    if (current.left != null)
                    {
                        current.left.val = 2 * current.val + 1;
                        values.Add(current.left.val);
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        current.right.val = 2 * current.val + 2;
                        values.Add(current.right.val);
                        queue.Enqueue(current.right);
                    }
                }
            }

            public bool Find(int target)
            {
                return values.Contains(target);
            }
        }

        /**
         * Your FindElements object will be instantiated and called as such:
         * FindElements obj = new FindElements(root);
         * bool param_1 = obj.Find(target);
         */