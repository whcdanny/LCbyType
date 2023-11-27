//Leetcode 101. Symmetric Tree ez
//题意：给定一个二叉树，检查它是否是镜像对称的。
//思路：BFS解法需要借助队列，每次将一对对称的节点加入队列，然后依次出队两个节点进行比较。如果这两个节点的值相等，并且它们的子节点满足对称关系，则将子节点按对称的顺序加入队列。
//时间复杂度: O(n)，其中 n 为二叉树中的节点数量
//空间复杂度：O(n)，其中 n 为二叉树中的节点数量
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode left = queue.Dequeue();
                TreeNode right = queue.Dequeue();

                if (left == null && right == null)
                {
                    continue;
                }

                if (left == null || right == null)
                {
                    return false;
                }

                if (left.val != right.val)
                {
                    return false;
                }

                // 将左节点的左子树和右节点的右子树按对称的顺序加入队列
                queue.Enqueue(left.left);
                queue.Enqueue(right.right);

                // 将左节点的右子树和右节点的左子树按对称的顺序加入队列
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }

            return true;
        }