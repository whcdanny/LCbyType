//Leetcode 1161. Maximum Level Sum of a Binary Tree med
//题意：给定一个二叉树的根节点 root，找到具有最大和的层。如果两个层具有相同的和，则返回其中最小的层。
//思路：BFS（广度优先搜索）遍历二叉树，计算每一层的节点和，找到具有最大和的层。
//时间复杂度: O(N)，其中 N 是二叉树中的节点数。
//空间复杂度： O(N)，其中 N 是二叉树中的节点数。
        public int MaxLevelSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int maxSum = int.MinValue;
            int maxLevel = 0;
            int currentLevel = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int currentSum = 0;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    currentSum += node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                currentLevel++;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxLevel = currentLevel;
                }
            }

            return maxLevel;
        }