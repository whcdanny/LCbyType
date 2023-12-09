//Leetcode 872. Leaf-Similar Trees ez
//题意：给定两棵二叉树，判断它们的叶子结点序列是否相同。如果两棵树的叶子结点序列相同，则认为这两棵树是叶相似的。    
//思路：定义一个辅助函数用于 DFS 遍历树，获取叶子结点序列。对两棵树分别调用 DFS 函数，得到它们的叶子序列。比较两棵树的叶子序列是否相同。      
//时间复杂度: O(max(N1, N2))，其中 N1 和 N2 分别为两棵树的节点数量。
//空间复杂度：O(max(L1, L2))，其中 L1 和 L2 分别为两棵树的叶子结点数量。
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leaves1 = new List<int>();
            List<int> leaves2 = new List<int>();

            DFS_LeafSimilar(root1, leaves1);
            DFS_LeafSimilar(root2, leaves2);

            return leaves1.SequenceEqual(leaves2);
        }

        private void DFS_LeafSimilar(TreeNode root, List<int> leaves)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                return;
            }

            DFS_LeafSimilar(root.left, leaves);
            DFS_LeafSimilar(root.right, leaves);
        }