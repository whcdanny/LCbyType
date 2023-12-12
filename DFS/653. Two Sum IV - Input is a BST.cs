//Leetcode 653. Two Sum IV - Input is a BST ez
//题意：给定一个二叉搜索树（BST），以及一个整数 k，判断是否存在两个节点的值之和等于 k。
//思路：DFS, 因为树是BST，可以使用中序遍历得到有序的节点值序列。然后，使用双指针从序列的两端向中间搜索是否存在两个节点的值之和等于目标值。另外，也可以使用DFS递归地遍历BST，并使用一个集合（Set）来记录已经遍历过的节点值，判断目标值减去当前节点值是否在集合中。
//时间复杂度: O(n)，其中 n 是二叉搜索树的节点数。在最坏情况下，需要遍历所有节点。
//空间复杂度：O(n)
        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> set = new HashSet<int>();
            return DFS_FindTarget(root, k, set);
        }

        private bool DFS_FindTarget(TreeNode node, int k, HashSet<int> set)
        {
            if (node == null) return false;

            if (set.Contains(k - node.val))
            {
                return true;
            }

            set.Add(node.val);

            return DFS_FindTarget(node.left, k, set) || DFS_FindTarget(node.right, k, set);
        }