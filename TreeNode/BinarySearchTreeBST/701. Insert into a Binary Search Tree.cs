//701. Insert into a Binary Search Tree med
//插入一个数在BST
//思路：根据比较root大小来确定方向，当null时插入；
		public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            // 找到空位置插入新节点
            if (root == null) return new TreeNode(val);
            // if (root.val == val)
            //     BST 中一般不会插入已存在元素
            if (root.val < val)
                root.right = InsertIntoBST(root.right, val);
            if (root.val > val)
                root.left = InsertIntoBST(root.left, val);
            return root;
        }