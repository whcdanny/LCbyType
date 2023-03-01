//450. Delete Node in a BST med
//删除一个数从二叉搜索树；
//思路：当你删除的时候分三种情况，第一刚好你没有子数直接删，第二个你刚好有一侧没有子树，也直接删；这里指的直接删就是上一级的root的left或者right等于被删除的left或者right；
//第三种比较复杂：如果左右都有子树，那么当我删除这个root的时候，我们需要先找到root的右子树中的最小值，为什么因为我们要保证二叉搜索数的定义，那就是root左边都小于右边都大于，然后删除这个最小值，然后把找到的最小值赋予删除的root的位置；
		public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                // 这两个 if 把情况 1 和 2 都正确处理了
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;
                // 处理情况 3
                // 获得右子树最小的节点
                TreeNode minNode = getMin(root.right);
                // 删除右子树最小的节点
                root.right = DeleteNode(root.right, minNode.val);
                // 用右子树最小的节点替换 root 节点
                minNode.left = root.left;
                minNode.right = root.right;
                root = minNode;
            }
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }
            return root;
        }
        public TreeNode getMin(TreeNode node)
        {
            // BST 最左边的就是最小的
            while (node.left != null) node = node.left;
            return node;
        }