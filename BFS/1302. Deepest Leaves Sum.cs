//Leetcode 1302. Deepest Leaves Sum med
//题意：给定一个二叉树，求二叉树最深叶子节点的和。
//思路：BFS 通过层次遍历二叉树，每一层结束后将该层叶子节点的和保存下来，最终得到最深叶子节点的和。
//时间复杂度: O(N)，其中 N 是二叉树的节点数。
//空间复杂度：O(N)
        public int DeepestLeavesSum(TreeNode root)
        {
            if (root == null) return 0;

            int sum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                sum = 0;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return sum;
        }