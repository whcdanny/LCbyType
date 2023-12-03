//Leetcode 1932. Merge BSTs to Create Single BST hard
//题意：这个问题给定了n个二叉搜索树（BST）的根节点，存储在数组trees中（从0索引开始）。每个BST在trees中最多有3个节点，并且没有两个根节点具有相同的值。在每次操作中，你可以：
//选择两个不同的索引i和j，使得trees[i] 中的一个叶子节点的值等于trees[j]的根值。
//用trees[j] 替换trees[i]中的叶子节点。
//从trees中移除trees[j]。
//如果在执行n - 1次操作后能够形成一个有效的BST，则返回结果BST的根节点；否则返回null。    
//BST（二叉搜索树）是一种二叉树，其中每个节点满足以下属性：
//节点的左子树中的每个节点的值都严格小于节点的值。
//节点的右子树中的每个节点的值都严格大于节点的值。
//叶子节点是没有子节点的节点。        
//思路：DFS, 先把每个root的val和root做成dictionary，然后根据这个，只要历遍trees，只要在这个dictionary中找到相对应的root，那么就说明可以做成树。最后只再检验是否为BFS
//注：当你完成一个DFS，也就是说你接完接完tree，需要更新，所以先删，再加；
//时间复杂度: O(n)，其中 n 是输入列表中的节点数。这是因为我们需要遍历输入列表一次并检查每个节点以查看其在哈希表中是否有对应的节点。
//空间复杂度：(n)，其中 n 是输入列表中的节点数。这是因为我们需要将所有节点存储在哈希表中。
        public TreeNode CanMerge(IList<TreeNode> trees)
        {
            // Convert the list of root nodes to a dictionary for easy lookup
            Dictionary<int, TreeNode> treeDict = new Dictionary<int, TreeNode>();            
            for (int i = 0; i < trees.Count; i++)
            {
                if (!treeDict.ContainsKey(trees[i].val))
                {
                    treeDict.Add(trees[i].val, trees[i]);
                }                
            }

            TreeNode root = trees[0];

            for (int i = 0; i < trees.Count; i++)
            {
                if (treeDict.ContainsKey(trees[i].val) && DFS_CanMerge(trees[i], treeDict))
                {
                    root = trees[i];
                    treeDict.Remove(root.val);
                    treeDict.Add(root.val, root);
                }
            }

            if (treeDict.Count == 1 && root != null)
            {
                return IsValidBST_CanMerge(root, Int64.MinValue, Int64.MaxValue) ? root : null;
            }

            return null;            
        }
                
        private bool DFS_CanMerge(TreeNode node, Dictionary<int, TreeNode> treeDict)
        {
            bool res = false;

            if (node.left != null)
            {
                //其实一旦右left在dictionary中一定可以组成tree，一定是true；
                if (treeDict.ContainsKey(node.left.val))
                {
                    node.left = treeDict[node.left.val];
                    treeDict.Remove(node.left.val);
                    res |= DFS_CanMerge(node.left, treeDict);
                    res |= true;
                }
            }

            if (node.right != null)
            {
                //其实一旦右left在dictionary中一定可以组成tree，一定是true；
                if (treeDict.ContainsKey(node.right.val))
                {
                    node.right = treeDict[node.right.val];
                    treeDict.Remove(node.right.val);
                    res |= DFS_CanMerge(node.right, treeDict);
                    res |= true;
                }

            }

            return res;
        }

        private bool IsValidBST_CanMerge(TreeNode root, long min, long max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.val <= min || root.val >= max)
            {
                return false;
            }

            return IsValidBST_CanMerge(root.left, min, root.val) && IsValidBST_CanMerge(root.right, root.val, max);
        }
