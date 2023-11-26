//Leetcode 404. Sum of Left Leaves ez
//题意：给定一个二叉树，求所有左叶子节点的和。左叶子节点是指该节点的左子节点且没有左子节点和右子节点。
//思路：(BFS)遍历二叉树，从根节点开始逐层遍历，将每一层的左叶子节点的值累加。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度： O(2^(h-1))
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                // Check if the left child of the current node is a leaf node.
                if (node.left != null && node.left.left == null && node.left.right == null)
                {
                    sum += node.left.val;
                }

                // Enqueue left and right children for further traversal.
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return sum;
        }