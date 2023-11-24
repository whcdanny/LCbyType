//Leetcode 513. Find Bottom Left Tree Value med
//题意：给定一棵二叉树，找到这棵树最底层、最左边的节点的值。
//思路：（BFS）来遍历树的每一层，最后一个遍历到的节点即为最底层、最左边的节点。
//时间复杂度: O(N)，其中 N 是树的节点数
//空间复杂度：O(M)，其中 M 是树中同一层的节点数的最大值
        public int FindBottomLeftValue(TreeNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root), "The input tree is null.");
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int leftmostValue = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                leftmostValue = queue.Peek().val;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }

            return leftmostValue;
        }