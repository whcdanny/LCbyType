//Leetcode 530. Minimum Absolute Difference in BST ez
//题意：给定一个二叉搜索树（BST）的根节点，找到树中任意两个不同节点的最小绝对差值。
//思路：使用 BFS 层级遍历二叉树，将每个节点的值存储在列表中。对值列表进行排序，然后计算相邻值之间的最小差值。
//时间复杂度: 遍历所有节点的过程中，每个节点都会被访问一次，因此时间复杂度为 O(n)，其中 n 是二叉树的节点数。对值列表进行排序的时间复杂度为 O(nlogn)。总体时间复杂度为 O(n + nlogn) = O(nlogn)。
//空间复杂度：使用了一个队列来进行 BFS 层级遍历，队列中的节点个数不会超过二叉树的宽度，最坏情况下为 n/2。因此，空间复杂度为 O(n)。使用了一个列表来存储节点的值，空间复杂度为 O(n)。排序过程中可能需要额外的 O(n) 空间。
        public int GetMinimumDifference(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<int> values = new List<int>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                values.Add(current.val);

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            values.Sort();

            int minDiff = int.MaxValue;
            for (int i = 1; i < values.Count; i++)
            {
                minDiff = Math.Min(minDiff, values[i] - values[i - 1]);
            }

            return minDiff;
        }