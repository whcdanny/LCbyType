//Leetcode 104. Maximum Depth of Binary Tree ez
//题意：给定一个二叉树，找出其最大深度。二叉树的最大深度是从根节点到最远叶子节点的最长路径上的节点数。
//思路：（BFS）来计算二叉树的最大深度。这里提供一种广度优先搜索的解法。使用队列进行层序遍历，每遍历一层，深度加一，直到遍历完所有层。
//时间复杂度: 遍历每个节点一次，总时间复杂度为 O(n)，其中 n 为二叉树中的节点数量。
//空间复杂度：空间复杂度取决于队列的大小，最坏情况下可能是 O(n)，其中 n 为二叉树中的节点数量。
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                depth++;
            }

            return depth;
        }