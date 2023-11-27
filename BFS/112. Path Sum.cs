//Leetcode 112. Path Sum med
//题意：给定一个二叉树的根节点 root 和一个表示目标和的整数 targetSum，判断该树中是否存在根到叶子节点的路径，这条路径上所有节点值相加等于目标和 targetSum。
//思路：（BFS）遍历二叉树，逐层遍历节点，更新节点的值为从根节点到当前节点的路径和。如果遇到叶子节点，检查路径和是否等于目标和。
//时间复杂度: 遍历二叉树的每个节点一次，总时间复杂度为 O(n)，其中 n 为二叉树中的节点数量。
//空间复杂度：空间复杂度取决于队列的大小，最坏情况下可能是 O(n)，其中 n 为二叉树中的节点数量。
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            Queue<int> sumQueue = new Queue<int>();

            nodeQueue.Enqueue(root);
            sumQueue.Enqueue(root.val);

            while (nodeQueue.Count > 0)
            {
                TreeNode node = nodeQueue.Dequeue();
                int currentSum = sumQueue.Dequeue();

                if (node.left == null && node.right == null && currentSum == sum)
                {
                    return true;
                }

                if (node.left != null)
                {
                    nodeQueue.Enqueue(node.left);
                    sumQueue.Enqueue(currentSum + node.left.val);
                }

                if (node.right != null)
                {
                    nodeQueue.Enqueue(node.right);
                    sumQueue.Enqueue(currentSum + node.right.val);
                }
            }

            return false;
        }