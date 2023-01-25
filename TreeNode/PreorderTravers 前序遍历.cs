//PreorderTravers 前序遍历
//思路：先存当前的val，然后左边然后右边
	public List<int> preorderTraverse(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null)
            {
                return res;
            }
            // 前序遍历的结果，root.val 在第一个
            res.Add(root.val);
            // 利用函数定义，后面接着左子树的前序遍历结果
            res.AddRange(preorderTraverse(root.left));
            // 利用函数定义，最后接着右子树的前序遍历结果
            res.AddRange(preorderTraverse(root.right));
            return res;
        }