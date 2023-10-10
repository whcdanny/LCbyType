//Leetcode 1110 Delete Nodes And Return Forest med
//题意：给定一棵二叉树和一个整数数组 to_delete，数组中的元素表示需要删除的节点的值，要求将这些节点删除，并返回删除节点后的森林（即多棵二叉树的集合）
//思路：深度优先搜索（DFS）根据是否是根节点和当前节点的值是否需要删除，进行相应的处理：如果是根节点并且当前节点的值不在删除集合中，将当前节点添加到结果中。将当前节点的左子树和右子树分别重新连接。如果当前节点的值在删除集合中，将左子树和右子树分别加入结果中，并将当前节点置为 null
//时间复杂度:   n 是二叉树中节点的个数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            HashSet<int> toDeleted = new HashSet<int>(to_delete);
            List<TreeNode> res = new List<TreeNode>();
            TreeNode DelNodes_DFS(TreeNode node, bool isRoot)
            {
                if (node == null)
                    return null;
                bool toDelete = toDeleted.Contains(node.val);
                if(isRoot && !toDelete)
                {
                    res.Add(node);
                }

                node.left = DelNodes_DFS(node.left, toDelete);
                node.right = DelNodes_DFS(node.right, toDelete);

                return toDelete ? null : node;
            }
            DelNodes_DFS(root, true);

            return res;
        }


		private List<TreeNode> res = new List<TreeNode>();
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            HashSet<int> toDeleted = new HashSet<int>(to_delete);
                        
            DelNodes_DFS(root, true, toDeleted);

            return res;
        }

        public TreeNode DelNodes_DFS(TreeNode node, bool isRoot, HashSet<int> toDeleted)
        {
            if (node == null)
                return null;
            bool toDelete = toDeleted.Contains(node.val);
            if (isRoot && !toDelete)
            {
                res.Add(node);
            }

            node.left = DelNodes_DFS(node.left, toDelete, toDeleted);
            node.right = DelNodes_DFS(node.right, toDelete, toDeleted);

            return toDelete ? null : node;
        }