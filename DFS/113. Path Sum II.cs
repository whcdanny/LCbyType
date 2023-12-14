//Leetcode 113. Path Sum II  med
//题意：给定一个二叉树和一个目标和，找出所有从根节点到叶子节点的路径，使得路径上节点值之和等于给定的目标和。
//思路：深度优先搜索（DFS）从根节点开始进行深度优先搜索，递归地查找满足条件的路径。在递归过程中，记录当前路径上的节点值之和，当到达叶子节点时，判断是否等于给定的目标和。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public IList<IList<int>> PathSum1(TreeNode root, int sum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            List<int> cur = new List<int>();
            sumPath1(root, sum, cur, res);
            return res;
        }

        private void sumPath1(TreeNode root, int sum, List<int> cur, IList<IList<int>> res)
        {
            if (root == null)
                return;
            cur.Add(root.val);
            if (root.left == null && root.right == null)
            {
                if (sum == root.val)// 当到达叶子节点且路径和等于目标和时，将当前路径添加到结果列表
                {
                    res.Add(new List<int>(cur));
                }
            }
            sumPath1(root.left, sum - root.val, cur, res);
            sumPath1(root.right, sum - root.val, cur, res);
            cur.RemoveAt(cur.Count - 1);// 回溯，将当前节点从路径中移除
        }